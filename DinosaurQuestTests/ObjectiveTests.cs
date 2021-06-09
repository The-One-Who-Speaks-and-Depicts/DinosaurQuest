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

		[Fact]
		public void StatusTest_StatusChanged_ChangedToActive()
		{
			var mockObjective = new Objective("FakeName", "FakeDesc", false);

			mockObjective.SetStatus(1);

			Assert.Equal(Objective.Status.Active, mockObjective.currentStatus);
		}

		[Fact]
		public void StatusTest_StatusChanged_ChangedToAchieved()
		{
			var mockObjective = new Objective("FakeName", "FakeDesc", false);

			mockObjective.SetStatus(2);

			Assert.Equal(Objective.Status.Achieved, mockObjective.currentStatus);
		}

		[Fact]
		public void StatusTest_StatusChanged_ChangedToFailed()
		{
			var mockObjective = new Objective("FakeName", "FakeDesc", false);

			mockObjective.SetStatus(3);

			Assert.Equal(Objective.Status.Failed, mockObjective.currentStatus);
		}

		[Fact]
		public void StatusTest_StatusChanged_ChangedToActiveByDefault()
		{
			var mockObjective = new Objective("FakeName", "FakeDesc", false);

			mockObjective.SetStatus(4);

			Assert.Equal(Objective.Status.Active, mockObjective.currentStatus);
		}


	}
}