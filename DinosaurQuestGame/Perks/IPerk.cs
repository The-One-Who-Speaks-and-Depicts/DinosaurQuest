using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinosaurQuest.Territories;
using DinosaurQuest.Creatures;

namespace DinosaurQuest.Perks
{
    public interface IPerk
    {
        string name { get; }
        string desc { get; }
        int branch { get; }
        int coolDownTime { get; }
        int coolDown { get; set; }
        bool isGettable { get; set; }
        bool isAcquired { get; set; }

        void OnTile(Character character, ITerritory territory);
        ITerritory OnMovement(Character character, ITerritory department, ITerritory destination, ICreature.direction direction);
        void OnUs(Character character, Anchiornis us, ITerritory territory);
        void OnThem(Character character, ICreature them, ITerritory territory);

        void Call();
        void CoolDownSet();
        // test when not only Archaeopteryx is implemented
        void UnBlock();

        string ToString();
    }

}
