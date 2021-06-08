using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinosaurQuest.Creatures;
using DinosaurQuest.Stages;
using DinosaurQuest.Landscapes;

namespace DinosaurQuest.Territories
{
    public class Tile : ITerritory
    {
        public Character character {get; private set;}
        public List<ICreature> creatures {get; private set;}


        public ILevel currentLevel {get; private set;}

        public int X { get; private set; }
        public int Y { get; private set; }
        public List <ITerritory> connectedTerritories {get; private set;}

        public Landscape landscape { get; private set; }

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
    }
}