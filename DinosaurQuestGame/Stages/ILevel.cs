using System.Collections.Generic;
using DinosaurQuest.Territories;
using DinosaurQuest.Creatures;
using DinosaurQuest.GameFunctions;


namespace DinosaurQuest.Stages
{
    public interface ILevel
    {
        string name { get; set; }
        string levelDesc { get; set; }
        int X_length { get; set; }
        int Y_length { get; set; }
        int Area => X_length * Y_length;
        List<ICreature> accessibleCreatures { get; set; }
        List<ITerritory> territories { get; set; }
        List<Objective> objectives {get; set;}
        public Character currentCharacter { get; set; }

        public void Entrance (Character _currentCharacter)
        {
            
        } 
        
        public void Transfer (Character _currentCharacter)
        {
            
        }
    }
}