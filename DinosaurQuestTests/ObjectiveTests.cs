using System;
using Xunit;
using DinosaurQuest.GameFunctions;

namespace DinosaurQuestTests
{
	public class ObjectiveTests
	{

		[Fact]
		public void StatusTest_ObjectiveCreated_EqualsToHidden()
		{
			var mockObjective = new Objective("FakeName", "FakeDesc", false);

			Assert.Equal(Objective.Status.Hidden, mockObjective.currentStatus);
		}
	}
}