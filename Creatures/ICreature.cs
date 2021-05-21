using DinosaurQuest.Territories;

namespace DinosaurQuest.Creatures
{
    public interface ICreature
    {
        string name { get; set; }
        int health { get; set; }
        int maxHealth { get; }
        int stamina { get; set; }
        int maxStamina {get; }
        int attackCoefficient { get; set; }
        int defenceCoefficient { get; set; }
        enum direction { N , NE, E, SE, S, SW, W, NW}

        void Move (ITerritory source, ITerritory target, bool directed = false);
        void Frighten(int coefficient);

    }
}
