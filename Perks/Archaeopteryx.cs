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
			throw new NotImplementedException();
		}
        public void OnMovement(Character character, ITile departingTile, ITile destinationTile)
        {
			throw new NotImplementedException();
		}
        public void OnPartner(Character character, ICreature partner, ITile tile)
        {
			throw new NotImplementedException();
		}
        public void OnFriend(Character character, ICreature friend, ITile tile)
        {
			throw new NotImplementedException();
		}
        public void OnRival(Character character, ICreature rival, ITile tile)
        {
			throw new NotImplementedException();
		}
        public void OnPrey(Character character, ICreature prey, ITile tile)
        {
			throw new NotImplementedException();
		}
        public void OnEnemy(Character character, ICreature enemy, ITile tile)
        {
			throw new NotImplementedException();
		}
        public void OnBreeding(Character character, Character partner, Character descendant)
        {
			throw new NotImplementedException();
		}
        public void CoolDownSet()
        {
			throw new NotImplementedException();
		}
        public void UnBlock()
        {
			throw new NotImplementedException();
		}
	}
}