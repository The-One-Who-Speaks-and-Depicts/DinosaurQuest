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
				return 1;
			}
		}
		public int coolDown {get; set;}
		public bool isGettable {get; set; } =  false;
		public bool isAcquired {get; set; } = true;

		public void OnTile(Character character, ITile tile)
		{
			tile.OpenTerritory(character);
		}
        public void OnMovement(Character character, ITile departingTile, ITile destinationTile)
        {
        	
			ITile newDestinationTile = destinationTile;
			if (destinationTile.Y < departingTile.Y)
			{
				newDestinationTile.Y = newDestinationTile.Y - 1;					
			}				
			else if (destinationTile.Y > departingTile.Y)
			{
				newDestinationTile.Y = newDestinationTile.Y + 1;
			}
			if (destinationTile.X < departingTile.X)
			{
				newDestinationTile.X = newDestinationTile.X - 1;					
			}				
			else if (destinationTile.X > departingTile.X)
			{
				newDestinationTile.X = newDestinationTile.X + 1;
			}
			if (newDestinationTile.isAccessible())
			{
				newDestinationTile.Generate();
				character.Move(departingTile, newDestinationTile);
				Console.WriteLine("Longer feathers make your flight longer.");
			}
			else 
			{
				Console.WriteLine("There is no way to move there, long flight is interrupted.");
			}
			this.CoolDownSet();
		}
        public void OnUs(Character character, Anchiornis us, ITile tile)
        {
			us.IncreaseFriendliness(character.socialCoefficient + 1);
		}
        public void OnThem(Character character, ICreature them, ITile tile) // implement
        {
			throw new NotImplementedException();
		}
        public void CoolDownSet()
        {
			this.coolDown = coolDownTime;
		}
        public void UnBlock() { }
	}
}