using System;

namespace DinosaurQuest.Territories
{
    public static class TerritoryFactory
    {
        ITerritory Generate (ITerritory previousTerritory, Type thisTerritoryType);
    }
}