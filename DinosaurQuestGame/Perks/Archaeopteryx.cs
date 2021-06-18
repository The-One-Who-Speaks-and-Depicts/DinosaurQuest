using DinosaurQuest.Territories;
using DinosaurQuest.Creatures;
using System;
using System.Text;

namespace DinosaurQuest.Perks
{
	public class Archaeopteryx: IPerk
	{

		public Archaeopteryx() {
			
		}
		
		public string name => "Archaeopteryx";
		public string desc => "Summoning the force of Archaeopteryx, you make your feathers much longer, which may give you access to the new territories, increase your chances to scare enemy by (attack coefficient + defence coefficient) * 2, increase your chances to attract friend by (social coefficient + 1).";
		public int branch => 0;
		public int coolDownTime => 5;
		public int coolDown {get; set;}
		public bool isGettable {get; set; } =  false;
		public bool isAcquired {get; set; } = true;

		// unit test all this

		// negative test when there are more perks
		public void OnTile(Character character, ITerritory territory)
		{
			Console.WriteLine("Longer feathers help you to reach new territories");
			var openedTerritory = territory as IHiddenTerritory;
			openedTerritory.OpenTerritory(character);			
			CoolDownSet();
		}

		// fix output type
        public ITerritory OnMovement(Character character, ITerritory department, ITerritory destination, ICreature.direction direction)
        {
        	CoolDownSet();
        	var midway = character.Move(department, direction);
        	if (midway != department)
        	{        		
        		var finalDestination = character.Move(midway, direction);
        		if (finalDestination != midway)
	        	{
	        		Console.WriteLine("Longer feathers made your flight longer.");
	        		return finalDestination;
	        	}
	        	return midway;
        	}
			return department;
		}
        public void OnUs(Character character, Anchiornis us, ITerritory territory)
        {
        	Console.WriteLine($"You are spreading your feathers, trying to attract the attention of {us.name}");
			us.IncreaseFriendliness(character.socialCoefficient + 1);
			CoolDownSet();
		}

		// test when Frighten is ready at least for Anchiornis
        public void OnThem(Character character, ICreature them, ITerritory territory)
        {
        	Console.WriteLine($"You are trying to scare {them.name}.");
			them.Frighten(20 + (character.attackCoefficient + character.socialCoefficient) * 2);
			CoolDownSet();
		}
		// test when there are more than two perks
        public void CoolDownSet()
        {
			coolDown = coolDownTime;
			Console.WriteLine($"Till Archaeopteryx charge remain {coolDownTime} ticks.");
		}
        public void UnBlock() { }

        public override string ToString()
        {
        	return (name + ".\nBranch: " + branch + ".\n" + desc + "\n Cool down time is " + coolDownTime + ".");
        }

        // test when implemented
        public void Call()
        {

        }
	}
}