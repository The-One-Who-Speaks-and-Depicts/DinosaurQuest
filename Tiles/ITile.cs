using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinosaurQuest.Creatures;
using DinosaurQuest.Landscapes;

namespace DinosaurQuest.Tiles
{
    public interface ITile
    {
        Character character { get; set; }

        ILandscape landscape { get; set; }

        List<ICreature> creaturesOnTile { get; set; }

        void OpenTerritory(Character character);
        void CloseTerritory(Character character);
    }
}
