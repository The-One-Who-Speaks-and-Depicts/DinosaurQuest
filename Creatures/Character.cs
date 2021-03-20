using System;
using System.Collections.Generic;
using DinosaurQuest.Perks;
using DinosaurQuest.GameFunctions;
using DinosaurQuest.Tiles;

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
        private int SocialCoefficient { get; set;}
        public int socialCoefficient
        {
            get
            {
                return SocialCoefficient;
            }
            set
            {
                SocialCoefficient = value;
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
                Console.WriteLine("Your name is {0}. If you agree, enter 1, if not, enter anything else.", result);
            }
            while (ServiceFunctions.ChoosingRightKey() != 1);
            this.name = result;
        }
        

        public void ChooseStats()
        {
            int _attackCoefficient;
            int _defenceCoefficient;
            do 
            {
                Console.WriteLine("To make your attacks more effective, press 1, to make your evasive manoeuvres more effective, press any other key");
                int result = ServiceFunctions.ChoosingRightKey();
                _attackCoefficient = result == 1 ? 1 : 0;
                _defenceCoefficient = result == 1 ? 0 : 1;
                Console.WriteLine("Your defence skill is {0}, your attack skill is {1}. If you agree, enter 1, if not, enter anything else. ", _defenceCoefficient, _attackCoefficient);
            }
            while (ServiceFunctions.ChoosingRightKey() != 1);
            this.attackCoefficient = _attackCoefficient;
            this.defenceCoefficient = _defenceCoefficient;
        }
        #endregion

        #region creatureFunctions

        public void Move(ITile tileSource, ICreature.direction direction)
        {
            ITile tileTarget = tileSource;
            string movementDirection = "";
            switch (direction)
            {
                case ICreature.direction.N:
                {
                    tileTarget.Y++;
                    movementDirection = "northwards";
                    break;
                }
                case ICreature.direction.NE:
                {
                    tileTarget.Y++;
                    tileTarget.X++;
                    movementDirection = "northeastwards";
                    break;
                }
                case ICreature.direction.E: 
                {
                    tileTarget.X++;
                    movementDirection = "eastwards";
                    break;
                }
                case ICreature.direction.SE:
                {
                    tileTarget.Y--;
                    tileTarget.X++;
                    movementDirection = "southeastwards";
                    break;
                }
                case ICreature.direction.S:
                {
                    tileTarget.Y--;
                    movementDirection = "southwards";
                    break;
                }
                case ICreature.direction.SW:
                {
                    tileTarget.Y--;
                    tileTarget.X--;
                    movementDirection = "southwestwards";
                    break;
                }
                case ICreature.direction.W:
                {
                    tileTarget.X--;
                    movementDirection = "westwards";
                    break;
                }
                case ICreature.direction.NW:
                {
                    tileTarget.Y++;
                    tileTarget.X--;
                    movementDirection = "northwestwards";
                    break;
                }
                default:
                {
                    break;
                }                
            }                
            if (tileTarget.isAccessible())
            {
                tileTarget.Generate();
                tileSource.creaturesOnTile.Remove(this);
                tileTarget.creaturesOnTile.Add(this);
                if (this.Pack.Count != 0)
                {
                    foreach (var creature in this.Pack)
                    {
                        creature.Move(tileSource, tileTarget, true);
                    }
                }
                Console.WriteLine("{0} is moving {1}", this.name, movementDirection);
            }
            else 
            {
                Console.WriteLine("There is no way to move there.");
            }
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
