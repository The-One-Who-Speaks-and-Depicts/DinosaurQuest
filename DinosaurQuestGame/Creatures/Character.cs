using System;
using System.Collections.Generic;
using DinosaurQuest.Perks;
using DinosaurQuest.GameFunctions;
using DinosaurQuest.Territories;

namespace DinosaurQuest.Creatures
{
    
    public class Character : Anchiornis, ICreature
    {
        #region commonCharacteristics
        public new string name {get; set;}
        public string gender {get; set;}
        public new int health {get; set;}
        public new int maxHealth {get; set;}
        public new int stamina {get; set;}
        public new int maxStamina {get; set;}
        public List<IPerk> perks {get; set;}
        public new int attackCoefficient {get; set;}
        public new int defenceCoefficient {get; set;}
        public int socialCoefficient {get; set;}
        public Pack<Anchiornis> pack {get; set;}

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
                Console.WriteLine("\nType the name of your creature");
                result = Console.ReadLine();
                Console.WriteLine($"Your name is {result}. If you agree, enter 1, if not, enter anything else.");
            }
            while (ServiceFunctions.ChoosingRightKey(Console.ReadKey().KeyChar) != 1);
            name = result;
        }
        

        public void ChooseStats()
        {
            int _attackCoefficient = 0;
            int _defenceCoefficient = 0;
            int _socialCoefficient = 0;
            do 
            {
                _attackCoefficient = 0;
                _defenceCoefficient = 0;
                _socialCoefficient = 0;
                Console.WriteLine("\nTo make your attacks more effective, press 1, to make your evasive manoeuvres more effective, press 2, to make your social interactions more effective, any other key");
                int result = ServiceFunctions.ChoosingRightKey(Console.ReadKey().KeyChar);
                switch (result)
                {
                    case 1:
                        _attackCoefficient = 1;
                        break;
                    case 2:
                        _defenceCoefficient = 1;
                        break;
                    default:
                        _socialCoefficient = 1;
                        break;
                }
                Console.WriteLine($"Your defence skill is {_defenceCoefficient}, your attack skill is {_attackCoefficient}, your social skill is {_socialCoefficient}. If you agree, enter 1, if not, enter anything else. ");
            }
            while (ServiceFunctions.ChoosingRightKey(Console.ReadKey().KeyChar) != 1);
            attackCoefficient = _attackCoefficient;
            defenceCoefficient = _defenceCoefficient;
            socialCoefficient = _socialCoefficient;
        }
        #endregion

        #region creatureFunctions

        public bool Move(ITerritory source, ICreature.direction direction)
        {
            ITerritory target = source;
            string movementDirection = "";
            switch (direction)
            {
                case ICreature.direction.N:
                {
                    target.Y++;
                    movementDirection = "northwards";
                    break;
                }
                case ICreature.direction.NE:
                {
                    target.Y++;
                    target.X++;
                    movementDirection = "northeastwards";
                    break;
                }
                case ICreature.direction.E: 
                {
                    target.X++;
                    movementDirection = "eastwards";
                    break;
                }
                case ICreature.direction.SE:
                {
                    target.Y--;
                    target.X++;
                    movementDirection = "southeastwards";
                    break;
                }
                case ICreature.direction.S:
                {
                    target.Y--;
                    movementDirection = "southwards";
                    break;
                }
                case ICreature.direction.SW:
                {
                    target.Y--;
                    target.X--;
                    movementDirection = "southwestwards";
                    break;
                }
                case ICreature.direction.W:
                {
                    target.X--;
                    movementDirection = "westwards";
                    break;
                }
                case ICreature.direction.NW:
                {
                    target.Y++;
                    target.X--;
                    movementDirection = "northwestwards";
                    break;
                }
                default:
                {
                    break;
                }                
            }                
            if (target.isAccessible())
            {
                target.Generate();
                source.creatures.Remove(this);
                target.creatures.Add(this);
                if (pack.Count != 0)
                {
                    foreach (var creature in pack)
                    {
                        creature.Move(source, target, true);
                    }
                }
                Console.WriteLine($"{name} is moving {movementDirection}.");
                return true;
            }
            else 
            {
                Console.WriteLine("You are going too far away from your territory!");
                return false;
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
