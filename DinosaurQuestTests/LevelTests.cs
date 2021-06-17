using System;
using Xunit;
using DinosaurQuest.Stages;

namespace DinosaurQuestTests
{
	public class LevelTests
	{
		[Theory]
		[InlineData(3, 3)]
		[InlineData(3, 4)]
		[InlineData(5, 2)]
		public void AreaTest_MultipliesWidthAndHeight_AreaIsResult(int width, int height)
		{
			var level = new MockLevel(width, height);

			Assert.Equal(width * height, level.Area);
		}
	}
}