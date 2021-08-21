namespace DinosaurQuest.Territories
{
    public interface ITerritoryFactory
    {
        ITerritory Generate (ITerritory previousTerritory);
    }
}