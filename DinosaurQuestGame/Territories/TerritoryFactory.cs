using System;
using System.Reflection;

namespace DinosaurQuest.Territories
{
    public static class TerritoryFactory
    {
        public static ITerritory Generate (ITerritory previousTerritory, Type thisTerritoryType)
        {
            return (ITerritory) Activator.CreateInstance(thisTerritoryType);
        }
    }
}