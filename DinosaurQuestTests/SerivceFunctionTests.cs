using System;
using Xunit;
using DinosaurQuest.GameFunctions;

namespace DinosaurQuestTests
{
    public class ServiceFunctionsTests
    {
    	[Theory]
        [InlineData('A')]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData('\n')]
        public void keyChoice_rightKeyReturned_True(char value)
        {
        	int decision = ServiceFunctions.ChoosingRightKey(value);

        	Assert.Equal(value - 48, decision);        	
        }
    }
}
