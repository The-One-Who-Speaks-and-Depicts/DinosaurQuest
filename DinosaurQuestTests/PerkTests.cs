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
			var mockTerritory = new MockHiddenTerritory(mockCharacter, mockArchaeopteryx, mockTile);

			mockArchaeopteryx.OnTile(mockCharacter, mockTerritory);

			Assert.True(mockTerritory.isAccessible);
		}

		[Fact]
		public void ArchaeopteryxUs_SocialCoefficientIncreased_AnchiornisAttracted()
		{
			var mockCharacter = new Character();
			var mockArchaeopteryx = new Archaeopteryx();
			mockCharacter.CreditArchaeopteryx(mockArchaeopteryx);
			var mockFriendlyAnchiornis = new Anchiornis();
			var mockUnfriendlyAnchiornis = new Anchiornis();
			mockFriendlyAnchiornis.IncreaseFriendliness(15);
			mockUnfriendlyAnchiornis.IncreaseFriendliness(15);
			var mockTile = new MockTile(mockCharacter, 3, 3, 2, 2);

			mockArchaeopteryx.OnUs(mockCharacter, mockFriendlyAnchiornis, mockTile);
			mockUnfriendlyAnchiornis.IncreaseFriendliness(mockCharacter.socialCoefficient);
			var friendlinessIsNotEqual = mockFriendlyAnchiornis.friendliness == mockUnfriendlyAnchiornis.friendliness;

			Assert.False(friendlinessIsNotEqual);
		}
	}
}