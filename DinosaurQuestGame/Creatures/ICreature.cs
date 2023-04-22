using DinosaurQuest.Territories;

namespace DinosaurQuest.Creatures
{
    public interface ICreature
    {
        string name { get; }
        int health { get; }
        int maxHealth { get; }
        int stamina { get; }
        int maxStamina { get; }
        int attackCoefficient { get; }
        int defenceCoefficient { get; }
        enum direction { N, NE, E, SE, S, SW, W, NW }

        void Move(ITerritory source, ITerritory target, bool directed = false);
        void Frighten(ITerritory currentTerritory, int coefficient = 20);

    }
}
