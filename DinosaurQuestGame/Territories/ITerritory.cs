using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinosaurQuest.Creatures;
using DinosaurQuest.Stages;

namespace DinosaurQuest.Territories
{
    public interface ITerritory
    {    	

        Character character { get; }
        
        int X {get; }
        int Y {get; }

        List <ITerritory> connectedTerritories {get;}

        List<ICreature> creatures { get; }

        ILevel currentLevel {get; set;}

        void OpenTerritory(Character character);
        void CloseTerritory(Character character);

        void Generate()
        {
        }       
        bool isAccessible ();

        void SetX(int _X, int step);
        void SetY(int _Y, int step);
    }
}