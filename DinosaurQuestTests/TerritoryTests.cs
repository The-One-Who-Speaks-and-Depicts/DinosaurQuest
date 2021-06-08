using System;
using Xunit;
using DinosaurQuest.GameFunctions;
using DinosaurQuest.Creatures;
using DinosaurQuest.Territories;

namespace DinosaurQuestTests
{
    public class TerritoryTests
    {
    	[Fact]
        public void movementOutOfPositiveBounds_accessNotGranted_False()
        {
        	var mockCharacter = new Character();
            var mockTile = new MockTerritory(3, 3, 3, 3);

            var movement = mockCharacter.Move(mockTile, ICreature.direction.N);

            Assert.False(movement);
        }
    }
}
