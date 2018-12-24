using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Int32;


namespace TrialGame
{
    class Program
    {
        public static void Exit_Game ()
        {
            Console.WriteLine("For End press Enter");
            String finish = Console.ReadLine();
        }

        public static int ChoosingRightKey()
        {
            int decision;
            ConsoleKeyInfo readKey;
            readKey = Console.ReadKey();
            Console.WriteLine(" ");
            decision = Convert.ToInt32(readKey.KeyChar);
            return decision;
        }

        public static int ChooseStat(String S, int wholeAmount)
        {
            int stat;

            Console.WriteLine("Choose your {0} stat now", S);
            stat = Convert.ToInt32(Console.ReadKey().KeyChar);
            int distributionsp1 = wholeAmount + 48 - stat;
            if ((stat < 48) || (stat > 57))
            {
                ConsoleKeyInfo readKeysp1;
                do
                {
                    Console.WriteLine("Please insert appropriate number");
                    readKeysp1 = Console.ReadKey();
                    stat = Convert.ToInt32(readKeysp1.KeyChar);
                }
                while ((stat < 48) || (stat > 57));

            }
            else if (distributionsp1 < 0)
            {
                ConsoleKeyInfo readKeysp2;
                do
                {
                    Console.WriteLine("Please insert appropriate number");
                    readKeysp2 = Console.ReadKey();
                    stat = Convert.ToInt32(readKeysp2.KeyChar);
                }
                while (distributionsp1 < 0);
            }
            else stat -= 48;
            Console.WriteLine(" ");
            int statOut = stat;
            Console.WriteLine("Your sprint  equals {0}", ++statOut);
            return stat;
        }
        public static string givingNameToCharacter()
        {
            Console.WriteLine("Type the name of your creature");
            String str = Console.ReadLine();
            return str;
        }
        public static string preGiving()
        {
            String result = givingNameToCharacter();
            var player = new YourCreature(result);
            Console.WriteLine("Your name is {0}. If OK, enter 1, if not, enter anything else", player.name);
            return player.name;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game of prehistory. It is a story of a predator dinosaur, little cryolophosaurus, who is growing in the Antarctica of Early Jurassic. The aim of a game is to guide your creature through the childhood, teenagehood, adolescence and adult life. The world around you is going to be harsh and cruel. Primary objective is survival by any cost. Secondary objective is to keep being the character you truly want to be.");
            YourCreature character = new YourCreature();
            character.name = "персонаж";

            do
            {
                character.name = preGiving();
            }
            while (Console.ReadLine() != "1");

            Console.WriteLine("Congratulations! You've chosen your name. Now you are called {0}", character.name);
            character.SetDefault(0, 100, 0);
            Console.WriteLine("Your level is {0}. Your health is {1}. You have {2} experience", character.level, character.health, character.exp);
            Console.WriteLine("Choose your master stats. You have 30 points to delegate into the following parameters, with minimum of 0 and maximum of 9: sprinter, stayer, intelligence, progressivity, perception, luck. To go to choosing stats press 1, to exit game press 2. Stat info is depicted while choosing");
            int decision = ChoosingRightKey();
            if (decision >= 51)
            {
                do
                {
                    decision = ChoosingRightKey();
                    Console.WriteLine("Please press appropriate key");
                }
                while (decision > 51);

            }

            else if (decision == 49)
            {
                Console.WriteLine("To choose your stats, press any key");
                decision = ChoosingRightKey();
                decision -= 48;
                int statCharge;

                do
                {
                    statCharge = 30;

                    Console.WriteLine("Sprint makes you more fast and strong. It helps you attack bigger herbivore creatures and subjugate ones of your kind. Also it strengthen your bones, so they are not as likely to be damaged.");
                    character.sprint += ChooseStat("sprint", statCharge);
                    statCharge = statCharge - character.sprint;
                    statCharge++;
                    Console.WriteLine("You have {0} point to distribute", statCharge);

                    Console.WriteLine("Stayer makes you more agile and flexible. It helps you attack smaller creatures and sneak away of bigger predators. Your bones are recovering faster as well.");
                    character.stayer += ChooseStat("stayer", statCharge);
                    statCharge = statCharge - character.stayer;
                    statCharge++;
                    Console.WriteLine("You have {0} point to distribute", statCharge);

                    Console.WriteLine("Intelligence makes you more clever and able to solving tasks. It helps you solve harder tasks and outsmart your rivals.");
                    character.intelligence += ChooseStat("intelligence", statCharge);
                    statCharge = statCharge - character.intelligence;
                    statCharge++;
                    Console.WriteLine("You have {0} point to distribute", statCharge);

                    Console.WriteLine("Progressivity improves your biodiversity. It enables you to acquire some important physical features that move your kind further. Also it helps you finding completely new solutions.");
                    character.progressivity += ChooseStat("progressivity", statCharge);
                    statCharge = statCharge - character.progressivity;
                    statCharge++;
                    Console.WriteLine("You have {0} point to distribute", statCharge);

                    Console.WriteLine("Perception improves your senses.  You are able to find other creatures in a more effective way and scavenge better.");
                    character.perception += ChooseStat("perception", statCharge);
                    statCharge = statCharge - character.perception;
                    statCharge++;
                    Console.WriteLine("You have {0} point to distribute", statCharge);

                    Console.WriteLine("Luck gives you better chances to make the best out of situation. It enables you scavenge more things, especially rare, and get away of bad encounters");
                    character.luck += ChooseStat("luck", statCharge);
                    statCharge = statCharge - character.luck;
                    statCharge++;
                    Console.WriteLine("You have {0} point to distribute", statCharge);

                    Console.WriteLine("Your stats are: sprint {0}, stayer {1}, intelligence {2}, progressivity {3}, perception {4}, luck {5}. If you are satisfied, press 1; if not, press 2", character.sprint, character.stayer, character.intelligence, character.progressivity, character.perception, character.luck);
                    decision = ChoosingRightKey();
                    decision -= 48;
                   
                    
                    if ((decision < 1) || (decision >2))
                    {
                        Console.WriteLine("Please press appropriate key");
                        Console.WriteLine("Your stats are: sprint {0}, stayer {1}, intelligence {2}, progressivity {3}, perception {4}, luck {5}. If you are satisfied, press 1; if not, press 2", character.sprint, character.stayer, character.intelligence, character.progressivity, character.perception, character.luck);
                        decision = ChoosingRightKey();
                        decision -= 48;
                        
                    }
                    
                    
                    else if (decision != 1) {
                        decision = 0;
                        character.sprint = 1;
                        character.stayer = 1;
                        character.intelligence = 1;
                        character.progressivity = 1;
                        character.luck = 1;
                        character.perception = 1;
                        statCharge += 30;
                    }
                    
                    else if (statCharge > 0)
                    {
                        Console.WriteLine("You should distribute all the stats. You have {0} stats left, redistribute your stats once again", statCharge);
                        decision = 0;
                    }
                    
                }
                while ((decision != 2) & (statCharge > 0));


            }
            else
            {
                Exit_Game();
                System.Environment.Exit(0);
            }

            Console.WriteLine("Now you have to choose your creature biological sex, for this kind of creatures masculine either feminine. Females get +1 sprint, as they are stronger, and probably faster. Males get +1 stayer, as they are weaker, but more agile and sneaky. Press 1 for choosing female, press 2 for choosing male");
            decision = ChoosingRightKey();
            decision -= 48;

            do
            {
                if ((decision != 1) && (decision != 2))
                {
                    Console.WriteLine("Press 1 for feminine, 2 for masculine");
                    decision = ChoosingRightKey();
                    decision -= 48;
                }
                else if (decision == 1)
                {
                    Console.WriteLine("You are female now");
                    character.sprint++;
                    character.sex = 0;
                }
                else
                {
                    Console.WriteLine("You are male now");
                    character.stayer++;
                    character.sex = 1;
                }

                Console.WriteLine("If you are sure about your choice, press 1, in the other case, press any other key");
                decision = ChoosingRightKey();
                decision -= 48;

            }
            while (decision != 1);
            String bioSex = character.PrintSex();
            Console.WriteLine("Your name is {0}, you are of {1} sex, you have level {2} and {3} health, your stats are {4} sprint, {5} stayer, {6} intelligence, {7} progressivity, {8} perception, {9} luck.", character.name, bioSex, character.level, character.health, character.sprint, character.stayer, character.intelligence, character.progressivity, character.perception, character.luck);
            Console.WriteLine("You are going to the tutorial level. Press any key");
            Console.ReadKey();
            Exit_Game();
        }


        public class YourCreature
        {
            public string name;
            public int health;
            public int level;
            public int exp;
            public int sprint = 1;
            public int stayer = 1;
            public int intelligence = 1;
            public int progressivity = 1;
            public int perception = 1;
            public int luck = 1;
            public int sex;

            public string PrintSex()
            {
                if (this.sex == 0) return "feminine";
                else return "masculine";
            }

            public YourCreature()
            {

            }

            public YourCreature(String givenName)
            {
                name = givenName;
            }

            public void SetDefault(int level, int health, int exp)
            {
                this.level = level;
                this.health = health;
                this.exp = exp;
            }

        }

    }
}