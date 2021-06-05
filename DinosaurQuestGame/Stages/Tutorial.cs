using System;
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
	    public int Area => X_length * Y_length;
	    public List<ICreature> accessibleCreatures { get; set; }
	    public List<ITerritory> territories { get; set; }
	    public List<Objective> objectives {get; set;}
	    public Character currentCharacter { get; set; }

	    public void Entrance ()
	    {
	    	Console.WriteLine(levelDesc);
	    	// place character on start tile	            
	    } 
	        
	    public void Transfer ()
	    {
	            
	    }

	    public Tutorial(Character _currentCharacter)
	    {
	    	name = "Tutorial";
	    	Console.WriteLine("Entering {0}...", name);
	    	levelDesc = ""; // implement
	    	X_length = 3;
	    	Y_length = 3;
	    	// generate accessible creatures
	    	// generate tiles
	    	// generate objectives
	    	currentCharacter = _currentCharacter;
	    	Console.WriteLine("{0} level generated!", name);
	    	Entrance();
	    }

	}
}