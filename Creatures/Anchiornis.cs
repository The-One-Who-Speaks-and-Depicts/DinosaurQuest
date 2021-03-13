using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinosaurQuest.Tiles;

namespace DinosaurQuest.Creatures
{
    public class Anchiornis : ICreature
    {
        public string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int maxHealth
        {
            get
            {
                return new Random().Next(200, 400);
            }
        }
        public int stamina { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int maxStamina 
        {
            get 
            {
                return new Random().Next(200, 400);
            }
        }
        public int friendliness { get; set; }
        public int maxFriendliness { get => 100; }
        public int attackCoefficient { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int defenceCoefficient { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Move (ITile tileSource, int direction)
        {
            direction = (int) ICreature.direction.NE;
            /*tileSource.creaturesOnTile.Remove(this);
            tileTarget.creaturesOnTile.Add(this);*/
        }

        public void Frighten ()
        {
            
        }

        public void IncreaseFriendliness (int coefficient)
        {
            int increase = 10 + 2 * coefficient;
            if (friendliness < maxFriendliness)
            {
                if ((maxFriendliness - friendliness) > increase)
                {
                    friendliness += increase;
                }
                else
                {
                    friendliness = maxFriendliness;
                }
            }
            
        }
    }
}
