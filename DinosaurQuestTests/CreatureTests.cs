using System;
using Xunit;
using DinosaurQuest.Creatures;

public class CreatureTests
{
	[Fact]
	public void JoinFromScratch_AnchiornisRefuses_True()
	{
		var pack = new Pack<Anchiornis>();
		var mockAnchiornis = new Anchiornis();
		pack.Join(mockAnchiornis);

		var packCount = pack.Count;

		Assert.True(packCount == 0);
	}

	[Fact]
	public void JoinWithInteraction_AnchiornisAgrees_True()
	{
		var pack = new Pack<Anchiornis>();
		var mockAnchiornis = new Anchiornis();
		mockAnchiornis.IncreaseFriendliness(25);
		pack.Join(mockAnchiornis);

		var packCount = pack.Count;

		Assert.True(packCount > 0);
	}
}