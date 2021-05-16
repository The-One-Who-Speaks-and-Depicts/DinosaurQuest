namespace DinosaurQuest.GameFunctions
{
	public class Objective
	{
		public string name {get ; set;}
		public string description {get; set;}
		public enum Status
		{
			Hidden = 0,
			Active,
			Achieved,
			Failed
		}
		private Status currentStatus {get; set;}

		public Objective (string _name, string _description)
		{
			name = _name;
			description = _description;
			currentStatus = setStatus(0);
		}

		public Status setStatus(int _status)
		{
			switch (_status) 
			{
				case 0:
					return Status.Hidden;
				case 2:
					return Status.Achieved;
				case 3: 
					return Status.Failed;
				case 1:
				default:
					return Status.Active;
			}
		}
	}
}