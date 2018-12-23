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
            ConsoleKeyInfo readKey;
            readKey = Console.ReadKey();
            int decision;
            decision = Convert.ToInt32(readKey.KeyChar);
            Console.WriteLine(" ");
            if (decision >= 51)
            {
                do
                {
                    Console.WriteLine("You have to type 1 or 2");
                    readKey = Console.ReadKey();
                    Console.WriteLine(" ");
                    decision = Convert.ToInt32(readKey.KeyChar);
                }
                while (decision > 51);

            }

            else if (decision == 49)
            {
                Console.WriteLine("To choose your stats, press any key");
                readKey = Console.ReadKey();
                Console.WriteLine(" ");
                decision = Convert.ToInt32(readKey.KeyChar);
                decision -= 48;
                int statCharge;

                do
                {
                    

                    statCharge = 30;
                    character.sprint += ChooseStat("sprint", statCharge);
                    statCharge = statCharge - character.sprint;
                    statCharge++;
                    Console.WriteLine("You have {0} point to distribute", statCharge);

                    character.stayer += ChooseStat("stayer", statCharge);
                    statCharge = statCharge - character.stayer;
                    statCharge++;
                    Console.WriteLine("You have {0} point to distribute", statCharge);

                    character.intelligence += ChooseStat("intelligence", statCharge);
                    statCharge = statCharge - character.intelligence;
                    statCharge++;
                    Console.WriteLine("You have {0} point to distribute", statCharge);

                    character.progressivity += ChooseStat("progressivity", statCharge);
                    statCharge = statCharge - character.progressivity;
                    statCharge++;
                    Console.WriteLine("You have {0} point to distribute", statCharge);

                    character.perception += ChooseStat("perception", statCharge);
                    statCharge = statCharge - character.perception;
                    statCharge++;
                    Console.WriteLine("You have {0} point to distribute", statCharge);

                    character.luck += ChooseStat("luck", statCharge);
                    statCharge = statCharge - character.luck;
                    statCharge++;
                    Console.WriteLine("You have {0} point to distribute", statCharge);

                    Console.WriteLine("Your stats are: sprint {0}, stayer {1}, intelligence {2}, progressivity {3}, perception {4}, luck {5}. If you are satisfied, press 1; if not, press 2", character.sprint, character.stayer, character.intelligence, character.progressivity, character.perception, character.luck);
                    readKey = Console.ReadKey();
                    Console.WriteLine(" ");
                    decision = Convert.ToInt32(readKey.KeyChar);
                    decision -= 48;
                   
                    
                    if ((decision < 1) || (decision >2))
                    { 
                        Console.WriteLine("Press the correct key, please. Your stats are: sprint {0}, stayer {1}, intelligence {2}, progressivity {3}, perception {4}, luck {5}. If you are satisfied, press 1; if not, press 2", character.sprint, character.stayer, character.intelligence, character.progressivity, character.perception, character.luck);
                        readKey = Console.ReadKey();
                        Console.WriteLine(" ");
                        decision = Convert.ToInt32(readKey.KeyChar);
                        decision -= 48;
                        
                    }
                    
                    
                    else if (decision != 1) {
                        decision = 0; statCharge = 30;
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
            readKey = Console.ReadKey();
            Console.WriteLine(" ");
            decision = Convert.ToInt32(readKey.KeyChar);
            decision -= 48;

            do
            {
                if ((decision != 1) && (decision != 2))
                {
                    Console.WriteLine("Press 1 for feminine, 2 for masculine");
                    readKey = Console.ReadKey();
                    Console.WriteLine(" ");
                    decision = Convert.ToInt32(readKey.KeyChar);
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
                readKey = Console.ReadKey();
                Console.WriteLine(" ");
                decision = Convert.ToInt32(readKey.KeyChar);
                decision -= 48;

            }
            while (decision != 1);
            
            
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