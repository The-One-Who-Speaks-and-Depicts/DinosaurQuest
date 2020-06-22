using System;
using System.Collections.Generic;

namespace TrialGame
{
    
    public class Character : ICreature
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
       
        private List<Perk> perks { get; set; }
        public List<Perk> Perks
        {
            get
            {
                return perks;
            }
            set
            {
                perks = value;
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
        

        public static void ChooseStat()
        {
            
        }
        #endregion

        #region technicalFunctions


        #endregion
    }
}
