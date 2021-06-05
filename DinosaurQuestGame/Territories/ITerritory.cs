using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinosaurQuest.Creatures;

namespace DinosaurQuest.Territories
{
    public interface ITerritory
    {    	

        Character character { get; set; }
        
        int X {get; set;}
        int Y {get; set;}

        List <ITerritory> connectedTerritories {get; set;}

        List<ICreature> creatures { get; set; }

        void OpenTerritory(Character character);
        void CloseTerritory(Character character);

        void Generate();        
        bool isAccessible ();
    }
}