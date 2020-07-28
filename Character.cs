using System;
using System.Collections.Generic;

namespace TrialGame
{
    
    public class Character : Anchiornis, ICreature
    {
        #region commonCharacteristics
        private string Name { get; set; }
        public new string name
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
        private string Gender { get; set; }
        public string gender
        {
            get
            {
                return Gender;
            }
            set
            {
                Gender = value;
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
        public new int health
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
        private int MaxHealth { get; set; }
        public new int maxHealth
        {
            get
            {
                return MaxHealth;
            }
            set
            {
                maxHealth = value;
            }
        }
        private int Stamina { get; set; }
        public new int stamina
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
       
        private List<IPerk> perks { get; set; }
        public List<IPerk> Perks
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
        private int AttackCoefficient { get; set; }
        private int DefenceCoefficient { get; set; }
        public new int attackCoefficient
        {
            get
            {
                return AttackCoefficient;
            }
            set
            {
                attackCoefficient = value;
            }
        }
        public new int defenceCoefficient
        {
            get
            {
                return DefenceCoefficient;
            }
            set
            {
                DefenceCoefficient = value;
            }
        }

        private Pack<Anchiornis> Pack { get; set; } = new Pack<Anchiornis>();
        public Pack<Anchiornis> pack
        {
            get
            {
                return Pack;
            }
            set
            {
                Pack = value;
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

        public void CoolDownCount()
        {
            for (int i = 0; i < perks.Count; i++)
            {
                if (perks[i].coolDown > 0)
                {
                    perks[i].coolDown--;
                }
            }
        }

        public List<IPerk> HeritageAcquiring(Character parent, int branch)
        {
            return parent.Perks.FindAll(perk => perk.branch == branch);
        }

        public new void Fight(ICreature attacker, ICreature defender, int effectCoefficient = 0)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
