using System;
using System.Collections.Generic;
using DinosaurQuest.Territories;
using DinosaurQuest.Creatures;
using DinosaurQuest.GameFunctions;

namespace DinosaurQuest.Stages
{
	public class MockLevel : ILevel
	{
		public string name { get;}
        public string levelDesc { get;}
        public int X_length { get; private set;}
        public int Y_length { get; private set; }
        public int Area => X_length * Y_length;
        public List<Type> accessibleCreatures { get; }
        public List<ITerritory> territories { get; }
        public List<Objective> objectives {get;}
        public Character currentCharacter { get; }

        public void Entrance (Character _currentCharacter)
        {
            
        } 
        
        public void Transfer (Character _currentCharacter)
        {
            
        }

        public MockLevel(int max_X, int max_Y)
        {
        	X_length = max_X;
        	Y_length = max_Y;
        }
	}
}
