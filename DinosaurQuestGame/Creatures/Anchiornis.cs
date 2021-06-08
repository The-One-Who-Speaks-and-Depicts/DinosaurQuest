using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinosaurQuest.Territories;

namespace DinosaurQuest.Creatures
{
    public class Anchiornis : ICreature
    {
        public string name { get; private set; }
        public int health { get; private set; }
        public int maxHealth => new Random().Next(200, 400);
        public int stamina { get; private set; }
        public int maxStamina => new Random().Next(200, 400);
        public int friendliness { get; private set; }
        public int maxFriendliness => 100;
        public int attackCoefficient => new Random().Next(7, 14);
        public int defenceCoefficient => new Random().Next(7,14);

        public void Frighten (int coefficient)
        {
            
        }

        public void Move(ITerritory source, ITerritory target, bool directed = false)
        {
            source.creatures.Remove(this);
            if (directed)
            {
                target.creatures.Add(this);
            }
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

        public Anchiornis()
        {

        }
    }
}
