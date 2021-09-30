using System;
using DinosaurQuest.Creatures;
using DinosaurQuest.Territories;
using DinosaurQuest.GameFunctions;
using System.Collections.Generic;
using DinosaurQuest.Landscapes;

namespace DinosaurQuest.Stages
{
	public class Tutorial : ILevel
	{
		public string name => "Tutorial";
	    public string levelDesc => "This part of life of Anchiornis is dedicated to re-evaluating of the world they live in. They know a lot about what is going on, they are able to do a lot, and this is time to try all of it, to master their skills.";
	    public int X_length => 2;
	    public int Y_length => 2;
	    public int Area => X_length * Y_length;
	    public List<Type> accessibleCreatures { get; private set; }
	    public List<ITerritory> territories { get; private set; }
	    public List<Objective> objectives{get; private set;}
	    public Character currentCharacter { get; private set; }

	    public void Entrance ()
	    {
	    	Tile startTile = (Tile) territories[0];
			startTile.PlaceCharacter(currentCharacter);
            Console.WriteLine(startTile.ToString());
            LevelLoop();
        }

		public void LevelLoop()
		{
			while (true)
			{
				Console.WriteLine("To go to main menu, press 9. To exit game, press 0.");
                int key = ServiceFunctions.ChoosingRightKey(Console.ReadKey().KeyChar);
				switch (key)
				{
					case 9:
                        MainFunctions.MainMenu();
                        break;
                    case 0:
                        MainFunctions.Exit_Game();
                        break;
					default:
                        break;
                }
            }
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
	    	territories = new List<ITerritory>() {TerritoryFactory.GenerateStart(this, 1, 1, Landscape.Option.YourNest)};
	    	currentCharacter = _currentCharacter;
	    	Console.WriteLine($"{name} level generated!");
			Console.WriteLine(levelDesc);
	    	Entrance();
	    }

	}
}
