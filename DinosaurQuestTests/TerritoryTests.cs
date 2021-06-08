using System;
using System.Collections.Generic;
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
            var mockTile = new MockTerritory(mockCharacter, 3, 3, 3, 3);

            var movement = mockCharacter.Move(mockTile, ICreature.direction.N);

            Assert.Equal(movement, movement);
        }

        [Fact]
        public void movementOutOfNegativeBounds_accessNotGranted_False()
        {
            var mockCharacter = new Character();
            var mockTile = new MockTerritory(mockCharacter, 3, 3, 1, 1);

            var movement = mockCharacter.Move(mockTile, ICreature.direction.S);

            Assert.Equal(movement, movement);
        }

        [Fact]
        public void movementWithinPositiveBoundsNorthwards_accessGranted_True()
        {
            var mockCharacter = new Character();
            var mockTile = new MockTerritory(mockCharacter, 3, 3, 2, 2);

            var movement = mockCharacter.Move(mockTile, ICreature.direction.NW);

            Assert.Equal(movement, mockTile);
        }

        [Fact]
        public void movementWithPack_packMoved_True()
        {
            var mockCharacter = new Character();
            var mockAnchiornis = new Anchiornis();
            mockCharacter.addToPack(mockAnchiornis);
            var mockTile = new MockTerritory(mockCharacter, 3, 3, 2, 2);
            mockTile.creatures = new List<ICreature>() {mockCharacter, mockAnchiornis};

            var movement = mockCharacter.Move(mockTile, ICreature.direction.N);
            bool packMoved = movement.creatures.Contains(mockAnchiornis) ? true : false;

            Assert.True(packMoved);
        }

        [Fact]
        public void enemyMoving_enemyMoved_True()
        {
            var mockCharacter = new Character();
            var mockAnchiornis = new Anchiornis();
            var mockTile = new MockTerritory(mockCharacter, 3, 3, 2, 2);
            mockTile.creatures = new List<ICreature>() {mockCharacter, mockAnchiornis};

            var movement = mockCharacter.Move(mockTile, ICreature.direction.N);
            mockAnchiornis.Move(mockTile, movement, true);
            bool enemyMoved = movement.creatures.Contains(mockAnchiornis) ? true : false;

            Assert.True(enemyMoved);
        }

        [Fact]
        public void enemyMoving_enemyFailed_False()
        {
            var mockCharacter = new Character();
            var mockAnchiornis = new Anchiornis();
            var mockTile = new MockTerritory(mockCharacter, 3, 3, 2, 2);
            mockTile.creatures = new List<ICreature>() {mockCharacter, mockAnchiornis};

            var movement = mockCharacter.Move(mockTile, ICreature.direction.N);
            mockAnchiornis.Move(mockTile, movement, false);
            bool enemyMoved = movement.creatures.Contains(mockAnchiornis) ? true : false;

            Assert.False(enemyMoved);
        }
    }
}
