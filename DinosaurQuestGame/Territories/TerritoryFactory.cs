using System;
using System.Reflection;
using DinosaurQuest.Stages;

namespace DinosaurQuest.Territories
{
    public static class TerritoryFactory
    {
        public static ITerritory GenerateStart (ILevel level)
        {
            return new Tile();
        }

        public static ITerritory Generate (ITerritory previousTerritory, Type thisTerritoryType)
        {
            return (ITerritory) Activator.CreateInstance(thisTerritoryType);
        }
    }
}