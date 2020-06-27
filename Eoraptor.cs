using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialGame
{
    class Eoraptor : IPerk
    {
        /*
        new int CoolDownTime { get { return 15; } }
        

        public Eoraptor()
        {
            Name = "Eoraptor";
            Desc = "Eoraptors were not exactly intelligent, so they lack more heuristic approaches to hunt, to fight, to help friends and enchant partners. However, their breed usually becomes more effective and accustomed to the world around, and Eoraptors' bodies develop some very unusual traits, although these traits can do bad for them.";
            CoolDown = 0;
        }

        void CoolDownSet()
        {
            this.CoolDown = CoolDownTime;
        }

        public void 

        public void OnMovement(Character character)
        {
            if (CoolDown ==.0)
            {
                Console.WriteLine("Accelerating...");
                double staminaSpendingDelta = character.level / 10;
                int staminaSpendingIncrease = 5 + Convert.ToInt32(Math.Floor(staminaSpendingDelta));
                character.stamina = character.stamina - staminaSpendingIncrease;
                CoolDownSet();
            }
            else
            {
                Console.WriteLine("Unable to accelerate...");
            }
        }
        */
        public Eoraptor()
        {
        }

        public string name { get { return "Eoraptor"; } }
        public string desc { get { return "Eoraptors were not exactly intelligent, so they lack more heuristic approaches to hunt, to fight, to help friends and enchant partners.However, their breed usually becomes more effective and accustomed to the world around, and Eoraptors' bodies develop some very unusual traits, although these traits can do bad for them."; } }
        public int coolDownTime { get { return 15; } }
        public int coolDown { get; set; }
        public bool isGettable { get; set; }

        public void CoolDownSet()
        {
            coolDown = coolDownTime;
        }

        public void OnBreeding(Character character, ICreature partner, Character descendant)
        {
            throw new NotImplementedException();
        }

        public void OnEnemy(Character character, ICreature enemy, Tile tile)
        {
            throw new NotImplementedException();
        }

        public void OnFriend(Character character, ICreature friend, Tile tile)
        {
            throw new NotImplementedException();
        }

        public void OnMovement(Character character, Tile departingTile, Tile destinationTile)
        {
            if (coolDown == 0)
            {
                Console.WriteLine("Accelerating...");
                double staminaSpendingDelta = character.level / 10;
                int staminaSpendingIncrease = 5 + Convert.ToInt32(Math.Floor(staminaSpendingDelta));
                character.stamina = character.stamina - staminaSpendingIncrease;
                CoolDownSet();
            }
            else
            {
                Console.WriteLine("Unable to accelerate...");
            }
        }

        public void OnPartner(Character character, ICreature partner, Tile tile)
        {
            throw new NotImplementedException();
        }

        public void OnPrey(Character character, ICreature prey, Tile tile)
        {
            throw new NotImplementedException();
        }

        public void OnRival(Character character, ICreature rival, Tile tile)
        {
            throw new NotImplementedException();
        }

        public void OnTile(Character character, Tile tile)
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            if (coolDown > 0)
            {
                coolDown--;
                if (coolDown == 0)
                {
                    Console.WriteLine(name + "is available to use!");
                }
            }            
        }

        public void UnBlock()
        {
            isGettable = true;
            Console.WriteLine(name + "is unlocked!");
        }
    }
}
