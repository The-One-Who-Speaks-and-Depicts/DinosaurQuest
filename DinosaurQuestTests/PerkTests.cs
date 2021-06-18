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
		public void ArchaeopteryxMove_edgeOfLevelAchieved_returnsTheSameTile()
		{
			var mockCharacter = new Character();
			var mockArchaeopteryx = new Archaeopteryx();
			mockCharacter.CreditArchaeopteryx(mockArchaeopteryx);
			var mockTile = new MockTile(mockCharacter, 3, 3, 3, 3);

			var destination = mockArchaeopteryx.OnMovement(mockCharacter, mockTile, null, ICreature.direction.NW);

			Assert.Equal(mockTile, destination);
		}

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
		public void ArchaeopteryxUs_FriendlinessIncreased_AnchiornisMoreAttracted()
		{
			var mockCharacter = new Character();
			var mockArchaeopteryx = new Archaeopteryx();
			mockCharacter.CreditArchaeopteryx(mockArchaeopteryx);
			var mockFriendlyAnchiornis = new Anchiornis();
			var mockTile = new MockTile(mockCharacter, 3, 3, 2, 2);

			mockArchaeopteryx.OnUs(mockCharacter, mockFriendlyAnchiornis, mockTile);

			Assert.Equal(12, mockFriendlyAnchiornis.friendliness);
		}

		[Fact]
		public void ArchaeopteryxUs_SocialCoefficientIncreased_AnchiornisMoreAttractedThanOther()
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
		

		[Fact]
		public void ArchaeopteryxUsed_coolDownIncreased_coolDownEqualsCoolDownLimit()
		{
			var mockCharacter = new Character();
			var mockArchaeopteryx = new Archaeopteryx(); 
			mockCharacter.CreditArchaeopteryx(mockArchaeopteryx);
			var mockTile = new MockTile(mockCharacter, 3, 3, 2, 2);
			var mockTerritory = new MockHiddenTerritory(mockCharacter, mockArchaeopteryx, mockTile);

			mockArchaeopteryx.OnTile(mockCharacter, mockTerritory);

			Assert.Equal(mockArchaeopteryx.coolDown, mockArchaeopteryx.coolDownTime);
		}

		[Fact]
		public void ArchaeopteryxNotUsed_coolDownRemained_coolDownEqualsZero()
		{
			var mockCharacter = new Character();
			var mockArchaeopteryx = new Archaeopteryx(); 			

			mockCharacter.CreditArchaeopteryx(mockArchaeopteryx);

			Assert.Equal(0, mockArchaeopteryx.coolDown);
		}
	}
}