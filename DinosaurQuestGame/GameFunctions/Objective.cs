namespace DinosaurQuest.GameFunctions
{
	public class Objective
	{
		public string name {get ; private set;}
		public string description {get; private set;}
		private bool isObligatory {get; set;}
		public enum Status
		{
			Hidden = 0,
			Active,
			Achieved,
			Failed
		}
		public Status currentStatus {get; private set;}

		public Objective (string _name, string _description, bool _isObligatory)
		{
			name = _name;
			description = _description;
			currentStatus = SetStatus(0);
			isObligatory = _isObligatory;
		}

		// SetStatus needs testing
		public Status SetStatus(int _status)
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

		public override string ToString()
		{
			string toPerform = isObligatory ? "Primary" : "Secondary";
			return ("Objective: " + name + ";\nType: " + toPerform + ";\nStatus: " + currentStatus + ";\nDescription: " + description + "\n");
		}
	}
}