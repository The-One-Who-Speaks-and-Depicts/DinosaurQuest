using System;
using DinosaurQuest.Creatures;
using DinosaurQuest.Territories;
using DinosaurQuest.GameFunctions;
using System.Collections.Generic;

namespace DinosaurQuest.Stages
{
	public class Tutorial : ILevel
	{
		public string name => "Tutorial";
	    public string levelDesc => "Description"; // implement
	    public int X_length => 2;
	    public int Y_length => 2;
	    public int Area => X_length * Y_length;
	    public List<Type> accessibleCreatures { get; private set; }
	    public List<ITerritory> territories { get; private set; }
	    public List<Objective> objectives => new List<Objective>()
		{
			new Objective("Stay alive!", "With death of this one the journey of its watcher ends.", true),
			new Objective("Find something to eat", "Staying alive is possible only when one has enough energy to move. So, one should search for something that moves to eat it", true),
			new Objective("Guard the nest", "One is caring not only for oneself, but for their children as well. Thought, sometimes exact priorities may shift a bit", false)
		};

	    public Character currentCharacter { get; private set; }

	    public void Entrance ()
	    {
	    	Console.WriteLine(levelDesc);
	    	// place the character on the start tile	            
	    } 
	        
	    public void Transfer ()
	    {
	            
	    }

	    public Tutorial(Character _currentCharacter)
	    {
	    	Console.WriteLine($"Entering {name}...");
	    	// generate objectives
	    	// generate accessible creatures
	    	// generate center tile
	    	currentCharacter = _currentCharacter;
	    	Console.WriteLine($"{name} level generated!");
	    	Console.WriteLine(levelDesc);
	    	Entrance();
	    }

	}
}