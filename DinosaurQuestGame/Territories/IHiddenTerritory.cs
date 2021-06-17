using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinosaurQuest.Creatures;
using DinosaurQuest.Stages;

namespace DinosaurQuest.Territories
{
    public interface IHiddenTerritory: ITerritory
    {
        // unit test these
        void OpenTerritory(Character character);
        void CloseTerritory(Character character);
        void EnterTerritory(Character character);
        void LeaveTerritory(Character character);
    }
}