namespace TrialGame
{
    public interface ICreature
    {
        string name { get; set; }
        int health { get; set; }
        int stamina { get; set; }
        int attackCoefficient { get; set; }
        int defenceCoefficient { get; set; }

        void Fight(ICreature attacker, ICreature defender, int coefficient = 0);

    }
}
