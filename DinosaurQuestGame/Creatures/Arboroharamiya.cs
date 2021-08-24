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

        public void Frighten (int coefficient)
        {
            
        }

        public Arboroharamiya()
        {
            
        }


    }
}