using DinosaurQuest.Tiles;
using DinosaurQuest.Creatures;
using System;
using System.Text;

namespace DinosaurQuest.Perks
{
	public class Archaeopteryx: IPerk
	{
		
		public string name 
		{
			get
			{
				return "Archaeopteryx";
			}
		}
		public string desc
		{
			get
			{
				return "Summoning the force of Archaeopteryx, you make your feathers much longer, which may give you access to the new territories, increase your chances to scare enemy by (attack coefficient + defence coefficient) * 2, increase your chances to attract friend by (social coefficient + 1).";
			}
		}
		public int branch
		{
			get
			{
				return 0;
			}
		}
		public int coolDownTime
		{
			get
			{
				return 5;
			}
		}
		public int coolDown {get; set;}
		public bool isGettable {get; set; } =  false;
		public bool isAcquired {get; set; } = true;

		public void OnTile(Character character, ITile tile)
		{
			Console.WriteLine("Longer feathers help you to reach new territories");
			tile.OpenTerritory(character);
			this.CoolDownSet();
		}
        public void OnMovement(Character character, ITile departingTile, ITile destinationTile, ICreature.direction direction)
        {        	
        	if (character.Move(destinationTile, direction))
        	{
        		Console.WriteLine("Longer feathers make your flight longer.");
        	}
        	else
        	{
        		character.Move(departingTile, direction);
        	}
			this.CoolDownSet();
		}
        public void OnUs(Character character, Anchiornis us, ITile tile)
        {
        	Console.WriteLine("You are spreading your feathers, trying to attract the attention of {0}", us.name);
			us.IncreaseFriendliness(character.socialCoefficient + 1);
			this.CoolDownSet();
		}
        public void OnThem(Character character, ICreature them, ITile tile)
        {
        	Console.WriteLine("You are trying to scare {0}.", them.name);
			them.Frighten(20 + (character.attackCoefficient + character.socialCoefficient) * 2);
			this.CoolDownSet();
		}
        public void CoolDownSet()
        {
			this.coolDown = coolDownTime;
			Console.WriteLine("Till Archaeopteryx charge remain {0} ticks", coolDownTime);
		}
        public void UnBlock() { }
        public void OutputInfo()
        {
        	Console.WriteLine("{0}.\nBranch: {1}.\n{2}\n Cool down time is {3}\n.", this.name, this.branch, this.desc, this.coolDownTime);
        }
	}
}