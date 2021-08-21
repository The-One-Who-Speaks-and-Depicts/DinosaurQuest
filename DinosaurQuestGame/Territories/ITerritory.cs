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

        List <ITerritory> connectedTerritories {get;}

        List<ICreature> creatures { get; }

        ILevel currentLevel {get; set;}
        bool isAccessible { get; }
    }
}