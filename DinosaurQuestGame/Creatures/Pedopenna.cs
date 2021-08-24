using System;
using DinosaurQuest.Territories;

namespace DinosaurQuest.Creatures
{
    public class Pedopenna : ICreature
    {
        public string name => "Pedopenna";
        public int health {get; set;}
        public int maxHealth => new Random().Next(250, 350);
        public int stamina {get; set;}
        public int maxStamina => new Random().Next(200, 400);
        public int attackCoefficient => 12;
        public int defenceCoefficient => 10;

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
            int pedopennaThreshold = 77;
            if (coefficient > pedopennaThreshold)
            {
                Console.WriteLine($"{name} is running in fear!");
                currentTerritory.creatures.Remove(this);
                return;
            }
            Console.WriteLine($"{name} is not going to retreat.");
        }
        public Pedopenna()
        {

        }
    }
}