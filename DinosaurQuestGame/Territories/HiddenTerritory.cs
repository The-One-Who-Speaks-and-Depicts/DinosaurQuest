using DinosaurQuest.Creatures;
using System.Collections.Generic;


namespace DinosaurQuest.Territories
{
	public class HiddenTerritory : ITerritory
	{
		public int X { get; set; }
        public int Y { get; set; }

		
		public Character character { get; set; }
        

        public List <ITerritory> connectedTerritories {get; set;}

        public List<ICreature> creatures { get; set; }

        public void OpenTerritory(Character character)
        {

        }
        public void CloseTerritory(Character character)
        {

        }

        public void Generate()
        {

        }        
        public bool isAccessible ()
        {
        	return false;
        }
	}
}