using DinosaurQuest.Creatures;
using DinosaurQuest.Territories;
using DinosaurQuest.GameFunctions;
using System.Collections.Generic;

namespace DinosaurQuest.Stages
{
	public class Tutorial : ILevel
	{
		public string name { get; set; }
	    public string levelDesc { get; set; }
	    public int X_length { get; set; }
	    public int Y_length { get; set; }
	    public int Area 
	    {
	    	get 
	        {
	            return X_length * Y_length;
	        }
	    }
	    public List<ICreature> accessibleCreatures { get; set; }
	    public List<ITerritory> territories { get; set; }
	    public List<Objective> objectives {get; set;}
	    public Character currentCharacter { get; set; }

	    public void Entrance (Character _currentCharacter)
	    {
	            
	    } 
	        
	    public void Transfer (Character _currentCharacter)
	    {
	            
	    }

	    public Tutorial(Character _currentCharacter)
	    {

	    }

	}
}