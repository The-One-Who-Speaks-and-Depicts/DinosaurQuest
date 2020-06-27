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
        int coolDownTime { get; }
        int coolDown { get; set; }
        bool isGettable { get; set; }
        
        void OnTile(Character character, Tile tile);
        void OnMovement(Character character, Tile departingTile, Tile destinationTile);
        void OnPartner(Character character, ICreature partner, Tile tile);

        void OnFriend(Character character, ICreature friend, Tile tile);

        void OnRival(Character character, ICreature rival, Tile tile);

        void OnPrey(Character character, ICreature prey, Tile tile);

        void OnEnemy(Character character, ICreature enemy, Tile tile);

        void OnBreeding(Character character, ICreature partner, Character descendant);

        void CoolDownSet();

        void UnBlock();

        void Refresh();
    }

}
