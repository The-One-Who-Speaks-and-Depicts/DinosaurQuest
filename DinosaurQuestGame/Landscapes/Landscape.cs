namespace DinosaurQuest.Landscapes
{
	public class Landscape
	{
		public enum Option
		{
			YourNest,
			AnchiornisNest,
			Nest,
			EmptyNest,
			Forest,
			Lake,
			Shore,
			Mountain,
			Meadow,
			Waterfall
		}

		private Option option {get; set;}

		public Landscape(Option _option)
		{
			option = _option;
		}

		public override string ToString()
		{
			switch(option)
			{
				case Option.YourNest:
					return "This is the nest of your pack, where the future of your kind lies. A small pile of branches, under which lay eggs, barely protected from predators.";
				case Option.AnchiornisNest:
					return "This is the nest of somebody of your species. A small pile of branches with some eggs, protected from predators by... somebody? anybody? nobody? One should see.";
				case Option.Nest:
					return "This is the nest you cannot recognize. There are certainly some eggs, but it is not time to be careful. Who knows, who laid the eggs?";
				case Option.EmptyNest:
					return "This is the empty nest. Maybe it is only being prepared, or other predators have got to it before you were able to. How unfortunate. For you.";
				case Option.Forest:
					return "You are surrounded by trees. This is the place you are accustomed to live in, though, there are a lot of dangers here.";
				case Option.Meadow:
					return "Forest gives place to a meadow of ferns. Here your eyes might save you from predator, but... will your legs?";
				case Option.Lake:
					return "A small lake, lost within the forest. Here, one may drink... or find their death.";
				case Option.Mountain:
					return "Here, in mountains, live almost nobody. Almost nothing grows. And, yet, it is a good question of whether this is actually a bad place to live.";
				case Option.Waterfall:
					return "An oasis in mountains, water, falling from a great height, inhabited by some truly rare tasty things. But the place is dangerous as well, because the waterflow may beat and drown even somebody who flies truly great. And Anchiornises are not exactly known for it.";
				case Option.Shore:
					return "The great water is everywhere. It is dangerous, mysterious, and definitely nobody wants to go deeper into it. However, it proposes truly great gifts.";
				default:
					return "This is the realm of unknown, where nothing has shape or form, but you.";
			}
		}
	
	}
}