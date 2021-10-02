using System;
using System.Collections.Generic;
using System.Reflection;
using DinosaurQuest.Perks;
using DinosaurQuest.GameFunctions;
using DinosaurQuest.Territories;
using Newtonsoft.Json;

namespace DinosaurQuest.Creatures
{

    public class Character : Anchiornis, ICreature
    {
        #region commonCharacteristics
        [JsonProperty]
        public new string name {get; private set;}
        [JsonProperty]
        public string gender {get; private set;}
        [JsonProperty]
        public new int health {get; private set;}
        [JsonProperty]
        public new int maxHealth {get; private set;}
        [JsonProperty]
        public new int stamina {get; private set;}
        [JsonProperty]
        public new int maxStamina {get; private set;}
        [JsonProperty]
        public List<IPerk> perks {get; private set;}
        [JsonProperty]
        public new int attackCoefficient {get; private set;}
        [JsonProperty]
        public new int defenceCoefficient {get; private set;}
        [JsonProperty]
        public int socialCoefficient {get; private set;}
        [JsonProperty]
        public Pack<Anchiornis> pack {get; private set;}

        #endregion

        #region Constructors

        public Character()
        {
            health = 100;
            maxHealth = health;
            stamina = 100;
            maxStamina = stamina;
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
            attackCoefficient += _attackCoefficient;
            defenceCoefficient += _defenceCoefficient;
            socialCoefficient += _socialCoefficient;
        }

        // test for existance of this perk, later
        public void CreditPerk(IPerk perk)
        {
            Console.WriteLine("You have acquired a new perk!");
            perks.Add(perk);
            Console.WriteLine(perk.ToString());
        }

        public void CreditArchaeopteryx(Archaeopteryx archaeopteryx)
        {
            perks = new List<IPerk>();
            perks.Add(archaeopteryx);
            Console.WriteLine(archaeopteryx.ToString());
        }


        public void SetGender(int option)
        {
            switch (option)
            {
                case 0:
                    gender = "feminine";
                    break;
                case 1:
                default:
                    gender = "masculine";
                    break;
            }

        }
        #endregion

        #region creatureFunctions

        public ITerritory Move(ITerritory source, ICreature.direction direction)
        {
            var tileSource = source as ITile;
            var target = (ITile) Activator.CreateInstance(source.GetType());
            target.currentLevel = source.currentLevel;
            string movementDirection = "";
            switch (direction)
            {
                case ICreature.direction.N:
                {
                    target.SetX(tileSource.X, 0);
                    target.SetY(tileSource.Y, 1);
                    movementDirection = "northwards";
                    break;
                }
                case ICreature.direction.NE:
                {
                    target.SetY(tileSource.Y, 1);
                    target.SetX(tileSource.X, 1);
                    movementDirection = "northeastwards";
                    break;
                }
                case ICreature.direction.E:
                {
                    target.SetX(tileSource.X, 1);
                    target.SetY(tileSource.Y, 0);
                    movementDirection = "eastwards";
                    break;
                }
                case ICreature.direction.SE:
                {
                    target.SetY(tileSource.Y, -1);
                    target.SetX(tileSource.X, 1);
                    movementDirection = "southeastwards";
                    break;
                }
                case ICreature.direction.S:
                {
                    target.SetX(tileSource.X, 0);
                    target.SetY(tileSource.Y, -1);
                    movementDirection = "southwards";
                    break;
                }
                case ICreature.direction.SW:
                {
                    target.SetY(tileSource.Y, -1);
                    target.SetX(tileSource.X, -1);
                    movementDirection = "southwestwards";
                    break;
                }
                case ICreature.direction.W:
                {
                    target.SetX(tileSource.X, -1);
                    target.SetY(tileSource.Y, 0);
                    movementDirection = "westwards";
                    break;
                }
                case ICreature.direction.NW:
                {
                    target.SetY(tileSource.Y, 1);
                    target.SetX(tileSource.X, -1);
                    movementDirection = "northwestwards";
                    break;
                }
                default:
                {
                    break;
                }
            }
            if (target.isAccessible)
            {
                // Generate with ITileFactory
                source.creatures.Remove(this);
                target.creatures.Add(this);
                if (pack != null)
                {
                    foreach (var creature in pack)
                    {
                        creature.Move(source, target, true);
                    }
                }
                Console.WriteLine($"{name} is moving {movementDirection}.");
                return target;
            }
            else
            {
                Console.WriteLine("You are going too far away from your territory!");
                return source;
            }
        }

        // test for non-Anchiornis
        public void AddToPack(ICreature candidate)
        {
            if (pack == null)
            {
                pack = new Pack<Anchiornis>();
            }
            pack.Join(candidate as Anchiornis);
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
