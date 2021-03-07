using System;
using System.Collections.Generic;
using DinosaurQuest.Perks;
using DinosaurQuest.GameFunctions;

namespace DinosaurQuest.Creatures
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
                MaxHealth = value;
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
        private int MaxStamina { get; set; }
        public new int maxStamina
        {
            get
            {
                return MaxStamina;
            }
            set
            {
                MaxStamina = value;
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
                AttackCoefficient = value;
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
            health = 100;
            stamina = 100;
        }


        #endregion

        #region CharacterCreation
        public void preGiving()
        {
            string result;
            do
            {
                Console.WriteLine("Type the name of your creature");
                result = Console.ReadLine();
                Console.WriteLine("Your name is {0}. If OK, enter 1, if not, enter anything else", result);
            }
            while (ServiceFunctions.ChoosingRightKey() != 1);
            this.name = result;
        }
        

        public void ChooseStats()
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
        #endregion
    }
}
