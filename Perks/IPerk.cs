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
        void OnMovement(Character character, ITile departingTile, ITile destinationTile);
        void OnFriend(Character character, ICreature friend, ITile tile);
        void OnRival(Character character, ICreature rival, ITile tile);
        void OnEnemy(Character character, ICreature enemy, ITile tile);
        void CoolDownSet();
        void UnBlock();
    }

}
