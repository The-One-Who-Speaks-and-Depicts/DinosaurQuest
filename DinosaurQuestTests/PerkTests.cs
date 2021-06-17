using System;
using Xunit;
using DinosaurQuest.Perks;
using DinosaurQuest.Creatures;
using DinosaurQuest.Territories;

namespace DinosaurQuestTests
{
	public class PerkTests
	{
		[Fact]
		public void ArchaeopteryxTiles_territoryUnlocked_returnsAccessible()
		{
			var mockCharacter = new Character();
			mockCharacter.CreditArchaeopteryx(new Archaeopteryx());
			// var mockTerritory = new MockTerritory();
		}
	}
}