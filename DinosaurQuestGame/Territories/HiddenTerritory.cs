using DinosaurQuest.Creatures;
using System.Collections.Generic;


namespace DinosaurQuest.Territories
{
	public class HiddenTerritory : ITerritory
	{
		public int X { get; private set; }
        public int Y { get; private set; }

        public void SetX(int previousX, int step)
        {

        }

        public void SetY(int previousY, int step)
        {
            
        }
		
		public Character character { get; set; }
        

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
            creatures = new List<ICreature>();
        }        
        public bool isAccessible ()
        {
            return false;
        }
	}
}