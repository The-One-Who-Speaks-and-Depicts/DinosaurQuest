using System;
using DinosaurQuest.Territories;

namespace DinosaurQuest.Creatures
{
    public class ShortLeggedLizard : ICreature
    {
        public string name => "Short-legged lizard";
        public int health { get; private set; }
        public int maxHealth => new Random().Next(20, 30);
        public int stamina { get; private set; }
        public int maxStamina => new Random().Next(30, 45);
        public int attackCoefficient => 1;
        public int defenceCoefficient => 0;

        public void Move(ITerritory source, ITerritory target, bool directed = false)
        {
            source.creatures.Remove(this);
            if (directed)
            {
                target.creatures.Add(this);
            }
        }

        public void Frighten(ITerritory currentTerritory, int coefficient)
        {
            int shortLeggedLizardThreshold = 15;
            if (coefficient > shortLeggedLizardThreshold)
            {
                Console.WriteLine($"{name} is running in fear!");
                currentTerritory.creatures.Remove(this);
                return;
            }
            Console.WriteLine($"{name} is not going to retreat.");
        }
        public ShortLeggedLizard()
        {

        }
    }
}