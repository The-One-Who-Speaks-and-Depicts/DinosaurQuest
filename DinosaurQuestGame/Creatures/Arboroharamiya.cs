using DinosaurQuest.Creatures;
using DinosaurQuest.Territories;
using System;

namespace DinosaurQuest.Creatures
{
    public class Arboroharamiya : ICreature
    {
        public string name => "Arboroharamiya";
        public int health {get; private set;}
        public int maxHealth => new Random().Next(40, 60);
        public int stamina {get; private set;}
        public int maxStamina => new Random().Next(20, 30);
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
            int arboroharamiyaThreshold = 27;
            if (coefficient > arboroharamiyaThreshold)
            {
                Console.WriteLine($"{name} is running in fear!");
                currentTerritory.creatures.Remove(this);
                return;
            }
            Console.WriteLine($"{name} is not going to retreat.");
        }

        public Arboroharamiya()
        {

        }


    }
}