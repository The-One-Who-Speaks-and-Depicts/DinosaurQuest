using DinosaurQuest.Tiles;
using DinosaurQuest.Creatures;
using System;

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
				return "Archaeopteryx description"; // implement
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
			// add description
			tile.OpenTerritory(character);
			this.CoolDownSet;
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
        	// add description
			us.IncreaseFriendliness(character.socialCoefficient + 1);
			this.CoolDownSet;
		}
        public void OnThem(Character character, ICreature them, ITile tile)
        {
        	// add description
			them.Frighten();
			this.CoolDownSet;
		}
        public void CoolDownSet()
        {
			this.coolDown = coolDownTime;
			Console.WriteLine("Till Archaeopteryx charge remain {0} ticks", coolDownTime)
		}
        public void UnBlock() { }
	}
}