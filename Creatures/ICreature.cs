namespace DinosaurAction.Creatures
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

    }
}
