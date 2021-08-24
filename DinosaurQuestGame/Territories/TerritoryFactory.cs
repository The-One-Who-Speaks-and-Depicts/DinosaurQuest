using System;
using System.Reflection;
using DinosaurQuest.Stages;
using DinosaurQuest.Landscapes;

namespace DinosaurQuest.Territories
{
    public static class TerritoryFactory
    {
        public static ITerritory GenerateStart (ILevel level, int X, int Y, Landscape.Option option)
        {
            return new Tile(level, X, Y, new Landscape(option));
        }

        public static ITerritory Generate (ITerritory previousTerritory, Type thisTerritoryType)
        {
            return (ITerritory) Activator.CreateInstance(thisTerritoryType);
        }
    }
}