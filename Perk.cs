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
        
        void OnTile();
        void OnMovement();
        void OnPartner();

        void OnFriend();

        void OnRival();

        void OnPrey();

        void OnEnemy();

        void OnBreeding();

        void CoolDownSet();

        void UnBlock();

        void Refresh();
    }

}
