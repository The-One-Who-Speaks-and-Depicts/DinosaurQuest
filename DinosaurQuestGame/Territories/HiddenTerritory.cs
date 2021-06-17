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

        }
        public void CloseTerritory(Character character)
        {

        }

        public void EnterTerritory(Character character)
        {

        }

        public void LeaveTerritory(Character character)
        {
            
        }

        public void Generate()
        {
        }

        public bool isAccessible {get; private set;}

        public HiddenTerritory()
        {

        }
	}
}