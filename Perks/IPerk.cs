using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialGame
{
    public interface IPerk
    {
        string name { get; }
        string desc { get; }
        int branch { get; }
        int coolDownTime { get; }
        int coolDown { get; set; }
        bool isGettable { get; set; }
        
        void OnTile(Character character, ITile tile);
        void OnMovement(Character character, ITile departingTile, ITile destinationTile);
        void OnPartner(Character character, ICreature partner, ITile tile);

        void OnFriend(Character character, ICreature friend, ITile tile);

        void OnRival(Character character, ICreature rival, ITile tile);

        void OnPrey(Character character, ICreature prey, ITile tile);

        void OnEnemy(Character character, ICreature enemy, ITile tile);

        void OnBreeding(Character character, Character partner, Character descendant);

        void CoolDownSet();

        void UnBlock();

        void Refresh();
    }

}
