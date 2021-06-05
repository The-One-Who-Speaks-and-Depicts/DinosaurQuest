using System;
using Xunit;
using DinosaurQuest.GameFunctions;

namespace DinosaurQuestTests
{
    public class ServiceFunctionsTests
    {
        [Fact]
        public void keyChoice_rightKeyReturned_True()
        {
        	int decision = ServiceFunctions.ChoosingRightKey((char) 93);

        	Assert.Equal(93 - 48, decision);
        }
    }
}
