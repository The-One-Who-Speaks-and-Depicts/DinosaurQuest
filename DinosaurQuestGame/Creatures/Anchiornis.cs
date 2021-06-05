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
        public string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int maxHealth => new Random().Next(200, 400);
        public int stamina { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int maxStamina => new Random().Next(200, 400);
        public int friendliness { get; set; }
        public int maxFriendliness => 100;
        public int attackCoefficient { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int defenceCoefficient { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
    }
}
