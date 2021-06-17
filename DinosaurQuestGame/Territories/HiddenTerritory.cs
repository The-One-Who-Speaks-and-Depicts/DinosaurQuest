using DinosaurQuest.Creatures;
using DinosaurQuest.Stages;
using System.Collections.Generic;


namespace DinosaurQuest.Territories
{
	public class HiddenTerritory : IHiddenTerritory
	{
		public Character character { get; set; }

        public ILevel currentLevel {get; set;}
        

        public List <ITerritory> connectedTerritories {get; set;}

        public List<ICreature> creatures { get; set; }

        public void OpenTerritory(Character character)
        {
            isAccessible = true;
            Console.WriteLine($"Access to territory is no longer restricted for {character.name}");
        }
        public void CloseTerritory(Character character)
        {
            isAccessible = false;
            Console.WriteLine($"Access to territory is now restricted for {character.name}");
        }

        public void EnterTerritory(Character character)
        {
            if (isAccessible)
            {
                connectedTerritories[0].creatures.Remove(character);
                creatures.Add(character);
                if (character.pack != null)
                {
                    for (int i = 0; i < character.pack.Count; i++)
                    {
                        connectedTerritories[0].creatures.Remove(character.pack[i]);
                        creatures.Add(character.pack[i]);
                    }
                }
            }           
            else
            {
                Console.WriteLine($"This territory is not accessible for {character.name}");
            }
        }

        public void LeaveTerritory(Character character)
        {
            connectedTerritories[0].creatures.Add(character);
            creatures.Remove(character);
            if (character.pack != null)
            {
                for (int i = 0; i < character.pack.Count; i++)
                {
                    connectedTerritories[0].creatures.Add(character.pack[i]);
                    creatures.Remove(character.pack[i]);
                }
            }
        }

        public void Generate()
        {
        }

        public bool isAccessible {get; private set;}

        public HiddenTerritory()
        {
            creatures = new List<ICreature>();
            Generate();
            isAccessible = false;
        }
	}
}