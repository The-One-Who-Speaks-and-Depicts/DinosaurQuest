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
        public Character character {get; set;}
        public List<ICreature> creatures {get; set;}


        public ILevel currentLevel {get; set;}

        public int X { get; set; }
        public int Y { get; set; }
        public List <ITerritory> connectedTerritories {get; set;}

        Landscape landscape { get; set; }

        public void OpenTerritory(Character character)
        {

        }
        public void CloseTerritory(Character character)
        {

        }

        public void Generate()
        {

        }

        public bool isAccessible() 
        {
            if (this.X > this.currentLevel.X_length || this.X < 0 || this.Y > this.currentLevel.Y_length || this.Y < 0)
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