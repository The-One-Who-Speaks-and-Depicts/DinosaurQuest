using System;
using Newtonsoft.Json;

namespace TrialGame
{
    
    class Character : ICreature
    {
        #region commonCharacteristics
        private string Name { get; set; }
        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
        private string Sex { get; set; }
        public string sex
        {
            get
            {
                return Sex;
            }
            set
            {
                Sex = value;
            }
        }
        private int Level { get; set; }
        public int level
        {
            get
            {
                return Level;
            }
            set
            {
                Level = value;
            }
        }
        private int Exp { get; set; }
        public int exp
        {
            get
            {
                return Exp;
            }
            set
            {
                Exp = value;
            }
        }
        private int Health { get; set; }
        public int health
        {
            get
            {
                return Health;
            }
            set
            {
                Health = value;
            }
        }
        private int Stamina { get; set; }
        public int stamina
        {
            get
            {
                return Stamina;
            }
            set
            {
                Stamina = value;
            }
        }        
        private int Strength { get; set; }
        public int strength
        {
            get
            {
                return Strength;
            }
            set
            {
                Strength = value;
            }
        }
        private int Speed { get; set; }
        public int speed
        {
            get
            {
                return Speed;
            }
            set
            {
                Speed = value;
            }
        }
        private int Agility { get; set; }
        public int agility
        {
            get
            {
                return Agility;
            }
            set
            {
                Agility = value;
            }
        }
        private int Perception { get; set; }
        public int perception
        {
            get
            {
                return Perception;
            }
            set
            {
                Perception = value;
            }
        }
        private int Luck { get; set; }
        public int luck
        {
            get
            {
                return Luck;
            }
            set
            {
                Luck = value;
            }
        }
        private int Appearance { get; set; }
        public int appearance
        {
            get
            {
                return Appearance;
            }
            set
            {
                Appearance = value;
            }
        }
        private int Intelligence { get; set; }
        public int intelligence
        {
            get
            {
                return Intelligence;
            }
            set
            {
                Intelligence = value;
            }
        }

        #endregion

        #region Constructors

        public Character()
        {
            level = 0;
            exp = 0;
            health = 100;
            stamina = 100;
        }


        #endregion

        #region CharacterCreation
        public static string preGiving()
        {
            string result;
            do
            {
                Console.WriteLine("Type the name of your creature");
                result = Console.ReadLine();
                Console.WriteLine("Your name is {0}. If OK, enter 1, if not, enter anything else", result);
            }
            while (ServiceFunctions.ChoosingRightKey() != 1);
            return result;
        }
        public virtual void DoStats()
        {
            this.strength = 1;
            this.speed = 1;
            this.agility = 1;
            this.intelligence = 1;
            this.appearance = 1;
            this.perception = 1;
            this.luck = 1;
        }

        public static int ChooseStat(string S, int wholeAmount)
        {
            int decision;

            Console.WriteLine("Choose your {0} stat now", S);
            decision = ServiceFunctions.ChoosingRightKey();



            while ((decision < 0) || (decision > 9))
            {
                Console.WriteLine("Please insert appropriate number, it should be more than 0 and less than 9");
                decision = ServiceFunctions.ChoosingRightKey();

            }

            while (wholeAmount < decision)
            {
                Console.WriteLine("Please insert appropriate number, you have only {0} points to distribute", wholeAmount);
                decision = ServiceFunctions.ChoosingRightKey();

            }

            int statOut = decision;
            Console.WriteLine("Your {0}  equals {1}", S, ++statOut);
            Console.WriteLine(" ");
            return decision;
        }
        #endregion

        #region technicalFunctions

        public string Jsonize()
        {
            return JsonConvert.SerializeObject(this);
        }

        #endregion
    }
}
