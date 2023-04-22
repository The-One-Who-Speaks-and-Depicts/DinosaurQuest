using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinosaurQuest.Creatures;
using DinosaurQuest.Stages;
using DinosaurQuest.Perks;

namespace DinosaurQuest.Territories
{
    public interface IHiddenTerritory : ITerritory
    {
        IPerk requiredPerk { get; }

        // negative tests when more perks are ready
        void OpenTerritory(Character character);
        void CloseTerritory(Character character);
        void EnterTerritory(Character character);
        void LeaveTerritory(Character character);
    }
}