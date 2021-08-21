using System;
using System.Collections.Generic;
using DinosaurQuest.Territories;
using DinosaurQuest.Creatures;
using DinosaurQuest.GameFunctions;


namespace DinosaurQuest.Stages
{
    public interface ILevel
    {
        string name { get;}
        string levelDesc { get;}
        int X_length { get; }
        int Y_length { get; }
        int Area => X_length * Y_length;
        List<Type> accessibleCreatures { get; }
        List<ITerritory> territories { get; }
        List<Objective> objectives {get;}
        public Character currentCharacter { get; }

        public void Entrance (Character _currentCharacter)
        {
            
        } 
        
        public void Transfer (Character _currentCharacter)
        {
            
        }
    }
}