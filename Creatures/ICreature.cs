using DinosaurQuest.Tiles;

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
        enum direction { N = 0, NE, E, SE, S, SW, W, NW}

        void Move (ITile tile1, int direction); // It should not get tile, but direction
        void Frighten();

    }
}
