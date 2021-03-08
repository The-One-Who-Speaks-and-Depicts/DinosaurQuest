using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinosaurQuest.Creatures;
using DinosaurQuest.Landscapes;
using DinosaurQuest.Stages;

namespace DinosaurQuest.Tiles
{
    public interface ITile
    {
        ILevel level { get; set; }

        int X { get; set; }
        int Y { get; set; }

        Character character { get; set; }

        ILandscape landscape { get; set; }

        List <ITile> connectedTiles {get; set;}

        List<ICreature> creaturesOnTile { get; set; }

        void Generate();
        void OpenTerritory(Character character);
        void CloseTerritory(Character character);
        bool isAccessible ()
        {
            if (this.X > this.level.X_length || this.X < 0 || this.Y > this.level.Y_length || this.Y < 0)
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
