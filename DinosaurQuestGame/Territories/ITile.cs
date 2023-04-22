using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinosaurQuest.Creatures;
using DinosaurQuest.Stages;

namespace DinosaurQuest.Territories
{
    public interface ITile : ITerritory
    {
        int X { get; }
        int Y { get; }

        void SetX(int _X, int step);
        void SetY(int _Y, int step);
    }
}