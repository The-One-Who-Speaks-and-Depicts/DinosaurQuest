using System;
using System.Linq;
using Xunit;
using DinosaurQuest.Creatures;
using DinosaurQuest.Perks;

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

	[Fact]
	public void JoinNeutralAnchiornis_AnchiornisRefuses_True()
	{
		var mockCharacter = new Character();
		var mockAnchiornis = new Anchiornis();
		mockCharacter.AddToPack(mockAnchiornis);

		var packCount = mockCharacter.pack.Count;

		Assert.Equal(0, packCount);
	}

	[Fact]
	public void JoinFriendlyAnchiornis_AnchiornisAgrees_True()
	{
		var mockCharacter = new Character();
		var mockAnchiornis = new Anchiornis();
		mockAnchiornis.IncreaseFriendliness(25);
		mockCharacter.AddToPack(mockAnchiornis);

		var packCount = mockCharacter.pack.Count;

		Assert.Equal(1, packCount);
	}

	[Fact]
	public void JoinNeutralAnchiornisToPack_AnchiornisRefuses_True()
	{
		var mockCharacter = new Character();
		var mockAnchiornis = new Anchiornis();
		mockAnchiornis.IncreaseFriendliness(25);
		mockCharacter.AddToPack(mockAnchiornis);
		var neutralAnchiornis = new Anchiornis();
		mockCharacter.AddToPack(neutralAnchiornis);

		var packCount = mockCharacter.pack.Count;

		Assert.Equal(1, packCount);
	}

	[Fact]
	public void JoinFriendlyAnchiornisToPack_AnchiornisAgrees_True()
	{
		var mockCharacter = new Character();
		var mockAnchiornis = new Anchiornis();
		mockAnchiornis.IncreaseFriendliness(25);
		mockCharacter.AddToPack(mockAnchiornis);
		var friendlyAnchiornis = new Anchiornis();
		friendlyAnchiornis.IncreaseFriendliness(21);
		mockCharacter.AddToPack(friendlyAnchiornis);

		var packCount = mockCharacter.pack.Count;

		Assert.Equal(2, packCount);
	}

	[Theory]
	[InlineData(0)]
	[InlineData(1)]
	[InlineData(2)]
	public void SettingGender_GenderFeminine_True(int gender)
	{
		var mockCharacter = new Character();
		mockCharacter.SetGender(gender);

		int genderType = mockCharacter.gender == "feminine" ? 0 : gender;

		Assert.Equal(genderType, gender); 
	}

	[Fact]
	public void CoolDownDecrease_ReducedToZero_ReadyToUse()
	{
		var mockCharacter = new Character();
		mockCharacter.CreditArchaeopteryx(new Archaeopteryx());
		for (int i = 0; i < mockCharacter.perks.Count; i++)
		{
			mockCharacter.perks[i].CoolDownSet();
		}
		for (int i = 0; i < 5; i++)
		{
			mockCharacter.CoolDownCount();
		}

		bool perksReduced = mockCharacter.perks.Any(p => p.coolDown == 0);

		Assert.True(perksReduced);
	}

	[Fact]
	public void CoolDownDecrease_HalfReduced_Recharging()
	{
		var mockCharacter = new Character();
		mockCharacter.CreditArchaeopteryx(new Archaeopteryx());
		for (int i = 0; i < mockCharacter.perks.Count; i++)
		{
			mockCharacter.perks[i].CoolDownSet();
		}
		for (int i = 0; i < 3; i++)
		{
			mockCharacter.CoolDownCount();
		}

		bool perksReduced = mockCharacter.perks.Any(p => p.coolDown == 0);

		Assert.False(perksReduced);
	}

	[Fact]
	public void FriendlinessIncrease_Increased_UpTo50()
	{
		var mockAnchiornis = new Anchiornis();
		mockAnchiornis.IncreaseFriendliness(20);

		int mockAnchiornisFriendliness = 50; 

		Assert.Equal(mockAnchiornis.friendliness, mockAnchiornisFriendliness);
	}

	[Fact]
	public void FriendlinessIncreasesOver100_BlockFromTop_Equals100()
	{
		var mockAnchiornis = new Anchiornis();
		mockAnchiornis.IncreaseFriendliness(100);

		Assert.Equal(mockAnchiornis.friendliness, mockAnchiornis.maxFriendliness);
	}
}