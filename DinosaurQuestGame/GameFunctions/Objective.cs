namespace DinosaurQuest.GameFunctions
{
    public class Objective
    {
        public string name { get; private set; }
        public string description { get; private set; }
        private bool isObligatory { get; set; }
        public enum Status
        {
            Hidden = 0,
            Active,
            Achieved,
            Failed
        }
        public Status currentStatus { get; private set; }

        public Objective(string _name, string _description, bool _isObligatory)
        {
            name = _name;
            description = _description;
            SetStatus(0);
            isObligatory = _isObligatory;
        }

        public void SetStatus(int _status)
        {
            switch (_status)
            {
                case 0:
                    currentStatus = Status.Hidden;
                    break;
                case 2:
                    currentStatus = Status.Achieved;
                    break;
                case 3:
                    currentStatus = Status.Failed;
                    break;
                case 1:
                default:
                    currentStatus = Status.Active;
                    break;
            }
        }

        public override string ToString()
        {
            string toPerform = isObligatory ? "Primary" : "Secondary";
            return ("Objective: " + name + ";\nType: " + toPerform + ";\nStatus: " + currentStatus + ";\nDescription: " + description + "\n");
        }
    }
}