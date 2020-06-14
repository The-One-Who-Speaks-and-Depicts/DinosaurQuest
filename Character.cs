using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialGame
{
    
    class Character : ICreature
    {
        public string name { get; set; }
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
        private int Attack { get; set; }
        public int attack
        {
            get
            {
                return Attack;
            }
            set
            {
                Attack = value;
            }
        }
        private int Defence { get; set; }
        public int defence
        {
            get
            {
                return Defence;
            }
            set
            {
                Defence = value;
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
        

        public Character()
        {
            level = 0;
            exp = 0;
            health = 100;
            stamina = 100;
        }
    }
}
