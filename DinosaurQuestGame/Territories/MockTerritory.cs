using System.Collections.Generic;
using DinosaurQuest.Stages;
using DinosaurQuest.Creatures;

namespace DinosaurQuest.Territories
{
	public class MockTerritory : ITerritory
	{
        public Character character { get; private set;}
        
        public int X {get; private set;}
        public int Y {get; private set;}

        public List <ITerritory> connectedTerritories {get;}

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

        public void SetX(int previousX, int step)
        {
            X = previousX + step;
        }

        public void SetY(int previousY, int step)
        {
            Y = previousY + step;
        }

        public bool isAccessible() 
        {
            if (X > currentLevel.X_length || X < 1 || Y > currentLevel.Y_length || Y < 1)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
        public ILevel currentLevel {get; set;}

        public MockTerritory(Character _character, int _level_X_length, int _level_Y_length, int _X, int _Y)
        {
            character = _character;
            creatures = new List<ICreature>();
            creatures.Add(character);
            SetX(_X, 0);
            SetY(_Y, 0);
        	currentLevel = new MockLevel(_level_X_length, _level_Y_length);
        }
	}
}
