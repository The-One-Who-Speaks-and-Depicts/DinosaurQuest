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
			var mockArchaeopteryx = new Archaeopteryx(); 
			mockCharacter.CreditArchaeopteryx(mockArchaeopteryx);
			var mockTile = new MockTile(mockCharacter, 3, 3, 2, 2);
			var mockTerritory = new MockHiddenTerritory(mockCharacter, new Archaeopteryx(), mockTile);

			mockArchaeopteryx.OnTile(mockCharacter, mockTerritory);

			Assert.True(mockTerritory.isAccessible);
		}
	}
}