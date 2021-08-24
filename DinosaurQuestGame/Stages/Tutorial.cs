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
	    public List<Objective> objectives{get; private set;}
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
			Objective stayingAlive = new Objective("Stay alive!", "With death of this one the journey of its watcher ends.", true);
			stayingAlive.SetStatus(1);
			Objective foodSearch = new Objective("Find something to eat", "Staying alive is possible only when one has enough energy to move. So, one should search for something that moves to eat it", true);
			foodSearch.SetStatus(1);
			Objective guard = new Objective("Guard the nest", "One is caring not only for oneself, but for their children as well. Thought, sometimes exact priorities may shift a bit", true);
			guard.SetStatus(1);
			objectives = new List<Objective>()
			{
				stayingAlive, foodSearch, guard
			};
			for(int i = 0; i < objectives.Count; i++)
			{
				Console.WriteLine(objectives[i].ToString());
			}
	    	accessibleCreatures = new List<Type>() {typeof(Arboroharamiya), typeof(ShortLeggedLizard), typeof(Ahirmoneura)}; 
	    	// generate center tile
	    	currentCharacter = _currentCharacter;
	    	Console.WriteLine($"{name} level generated!");
	    	Console.WriteLine(levelDesc);
	    	Entrance();
	    }

	}
}