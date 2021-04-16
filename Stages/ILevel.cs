using System.Collections.Generic;
using DinosaurQuest.Landscapes;
using DinosaurQuest.Creatures;


namespace DinosaurQuest.Stages
{
    public interface ILevel
    {
        string name { get; set; }
        string levelDesc { get; set; }
        int X_length { get; set; }
        int Y_length { get; set; }
        int Area 
        {
            get 
            {
                return X_length * Y_length;
            }
        }
        List<ICreature> accessibleCreatures { get; set; }
        List<ILandscape> landscapes { get; set; }
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