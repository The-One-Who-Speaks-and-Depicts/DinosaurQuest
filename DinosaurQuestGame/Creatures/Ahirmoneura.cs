using System;
using DinosaurQuest.Territories;

namespace DinosaurQuest.Creatures
{
    public class Ahirmoneura : ICreature
    {
        public string name => "Ahirmoneura";
        public int health {get; private set;}
        public int maxHealth => new Random().Next(10, 15);
        public int stamina {get; private set;}
        public int maxStamina => new Random().Next(70, 100);
        public int attackCoefficient => 0;
        public int defenceCoefficient => 0;

        public void Move(ITerritory source, ITerritory target, bool directed = false)
        {
            source.creatures.Remove(this);
            if (directed)
            {
                target.creatures.Add(this);
            }
        }

        public void Frighten (ITerritory currentTerritory, int coefficient)
        {
            int ahimoneuraThreshold = 5;
            if (coefficient > ahimoneuraThreshold)
            {
                Console.WriteLine($"{name} is running in fear!");
                currentTerritory.creatures.Remove(this);
                return;
            }
            Console.WriteLine($"{name} is not going to retreat.");
        }

        public Ahirmoneura()
        {

        }

    }
}