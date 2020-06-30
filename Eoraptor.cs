using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialGame
{
    class Eoraptor : IPerk
    {
        
        public Eoraptor()
        {
        }

        public string name { get { return "Eoraptor"; } }
        public string desc { get { return "Eoraptors were not exactly intelligent, so they lack more heuristic approaches to hunt, to fight, to help friends and enchant partners.However, their breed usually becomes more effective and accustomed to the world around, and Eoraptors' bodies develop some very unusual traits, although these traits can do bad for them."; } }
        public int branch { get { return 3; } }
        public int coolDownTime { get { return 15; } }
        public int coolDown { get; set; }
        public bool isGettable { get; set; }

        public void CoolDownSet()
        {
            coolDown = coolDownTime;
        }

        public void OnBreeding(Character character, Character partner, Character descendant)
        {
            // у Breeding нет cooldown'а, потому что он однократен
            Console.WriteLine("Which parent is going to transfer their perks to you? Press 1 to choose your character, press 2 to choose the partner.");
            int decision;
            do
            {
                decision = ServiceFunctions.ChoosingRightKey();
            }
            while (decision > 0 && decision < 3);
            Character transferringParent;
            transferringParent = decision == 1 ? character: partner;
            Console.WriteLine("You may choose a branch of perks that your descendant will own. Press 1 to transfer skeleton, 2 to transfer appearance, 3 to transfer adaptation, 4 to transfer fortune, 5 to transfer orientation, 6 to transfer force");
            decision = -1;
            do
            {
                decision = ServiceFunctions.ChoosingRightKey();
            }
            while (decision > 0 && decision < 7);
            Console.WriteLine("Evolution preserves useful skills!");
            descendant.HeritageAcquiring(transferringParent, decision);
        }

        public void OnEnemy(Character character, ICreature enemy, ITile tile)
        {
            if (coolDown == 0)
            {
                Console.WriteLine("Developing aromorphosis...");
                Random rnd = new Random();
                int aromorphosis = rnd.Next(1, 2);
                if (aromorphosis == 1)
                {
                    Console.WriteLine("Your feathers today grow bigger than feathers of your ancestors. The predator is not ready for this visible size of your body, so they are retreating... for now.");
                    tile.creaturesOnTile = tile.creaturesOnTile.Where(creature => creature != enemy).ToList();
                }
                else
                {
                    Console.WriteLine("You started smelling as a more tasty food. The predator appetite is growing");
                }
            }
            else
            {
                Console.WriteLine("Unable to develop aromorphosis...");
            }
            
        }

        public void OnFriend(Character character, ICreature friend, ITile tile)
        {
            throw new NotImplementedException();
        }

        public void OnMovement(Character character, ITile departingTile, ITile destinationTile)
        {
            if (coolDown == 0)
            {
                Console.WriteLine("Accelerating...");
                double staminaSpendingDelta = character.level / 10;
                int staminaSpendingIncrease = 5 + Convert.ToInt32(Math.Floor(staminaSpendingDelta));
                character.stamina = character.stamina - staminaSpendingIncrease;
                destinationTile.creaturesOnTile = new List<ICreature>();
                CoolDownSet();
            }
            else
            {
                Console.WriteLine("Unable to accelerate...");
            }
        }

        public void OnPartner(Character character, ICreature partner, ITile tile)
        {
            if (coolDown == 0)
            {
                Random rnd = new Random();
                int aromorphosis = rnd.Next(1, 2);
                if (aromorphosis == 1)
                {
                    Console.WriteLine("You developed a unique pattern of feather colors! Your partner is now more keen to mate.");
                    Anchiornis matingPartner = (Anchiornis) partner;
                    matingPartner.IncreaseFriendliness(40);
                }
                else
                {
                    Console.WriteLine("Your partner do not like the feather pattern your ancestors left for you");
                    tile.creaturesOnTile = tile.creaturesOnTile.Where(creature => creature != partner).ToList();
                }
            }
            else
            {
                Console.WriteLine("There is no way a partner will like you because of your evolution path. Yet.");
            }
        }

        public void OnPrey(Character character, ICreature prey, ITile tile)
        {
            if (coolDown == 0)
            {
                Console.WriteLine("Developing aromorphosis...");
                Random rnd = new Random();
                int aromorphosis = rnd.Next(1, 2);
                if (aromorphosis == 1)
                {
                    Console.WriteLine("Your claws and teeth are now sharper than they used to be. Your attacks are much deadlier.");
                    character.Fight(character, prey, 5);
                }
                else
                {
                    Console.WriteLine("Unfortunately, your ancestors were practicing heterophagia. So, your ability to attack something moving is significantly weaker.");
                    character.Fight(character, prey, -5);
                }
            }
            else
            {
                Console.WriteLine("You are not ready to develop this aromorphosis... yet.");
            }
        }

        public void OnRival(Character character, ICreature rival, ITile tile)
        {
            if (coolDown == 0)
            {
                Console.WriteLine("Developing aromorphosis...");
                Random rnd = new Random();
                int aromorphosis = rnd.Next(1, 2);
                if (aromorphosis == 1)
                {
                    Console.WriteLine("Sight of you frightens the rival. They run away.");
                    tile.creaturesOnTile = tile.creaturesOnTile.Where(creature => creature != rival).ToList();
                }
                else
                {
                    Console.WriteLine("Demonstration failed. Enemy attacked and wounded you.");
                    character.health = character.health - (rival.attackCoefficient*2 - character.defenceCoefficient);
                }
            }
            else
            {
                Console.WriteLine("You are not ready to use the advantages, that evolution provided you with. For now.");
            }
        }

        public void OnTile(Character character, ITile tile)
        {
            if (coolDown == 0)
            {
                Console.WriteLine("Developing aromorphosis...");
                Random rnd = new Random();
                int result = rnd.Next(1, 2);
                if (result == 1)
                {
                    Console.WriteLine("Positive aromorphosis developed.");
                    tile.OpenTerritory(character);
                }
                else
                {
                    Console.WriteLine("Negative aromorphosis developed.");
                    tile.CloseTerritory(character);
                }
            }
            else
            {
                Console.WriteLine("You are not ready to develop this aromorphosis, yet.");
            }

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
