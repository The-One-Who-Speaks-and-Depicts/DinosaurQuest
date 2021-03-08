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
        	/*
			ITile newDestinationTile = destinationTile;
			// vertical
			if (destinationTile.X == departingTile.X)
			{
				// south
				if (destinationTile.Y < departingTile.Y)
				{
					newDestinationTile.X++;
				}
				// north
				else
				{

				}
			}
			// horizontal
			else if (destinationTile.Y == departingTile.Y)
			{
				// west
				if (destinationTile.X < departingTile.X)
				{

				}
				// east
				else
				{
					
				}
			}
			// diagonal
			else
			{
				//south
				if (destinationTile.Y < departingTile.Y)
				{
					// south-west
					if (destinationTile.X < departingTile.X)
					{

					}
					// south-east
					else
					{

					}
				}
				//north
				else
				{
					// north-west
					if (destinationTile.X < departingTile.X)
					{

					}
					//north-east
					{

					}
				}
			}*/
		}
        public void OnFriend(Character character, ICreature friend, ITile tile)
        {
			throw new NotImplementedException();
		}
        public void OnRival(Character character, ICreature rival, ITile tile)
        {
			throw new NotImplementedException();
		}
        public void OnEnemy(Character character, ICreature enemy, ITile tile)
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