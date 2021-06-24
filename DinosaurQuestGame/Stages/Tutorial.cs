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
	    public int X_length => 3;
	    public int Y_length => 3;
	    public int Area => X_length * Y_length;
	    public List<ICreature> accessibleCreatures { get; private set; }
	    public List<ITerritory> territories { get; private set; }
	    public List<Objective> objectives {get; private set;}
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