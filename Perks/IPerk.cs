using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinosaurQuest.Tiles;
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
        
        void OnTile(Character character, ITile tile);
        void OnMovement(Character character, ITile departingTile, ITile destinationTile, ICreature.direction direction);
        void OnUs(Character character, Anchiornis us, ITile tile);
        void OnThem(Character character, ICreature them, ITile tile);
        void CoolDownSet();
        void UnBlock();
    }

}
