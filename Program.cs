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

        public static int ChooseSprint(int wholeAmount)
        {
            int sprint;

            Console.WriteLine("Choose your sprint stat now");
            sprint = Convert.ToInt32(Console.ReadKey().KeyChar);
            int distributionsp1 = wholeAmount + 48 - sprint;
            if ((sprint < 48) || (sprint > 57))
            {
                ConsoleKeyInfo readKeysp1;
                do
                {
                    Console.WriteLine("Please insert appropriate number");
                    readKeysp1 = Console.ReadKey();
                    sprint = Convert.ToInt32(readKeysp1.KeyChar);
                }
                while ((sprint < 48) || (sprint > 57));

            }
            else if (distributionsp1 < 0)
            {
                ConsoleKeyInfo readKeysp2;
                do
                {
                    Console.WriteLine("Please insert appropriate number");
                    readKeysp2 = Console.ReadKey();
                    sprint = Convert.ToInt32(readKeysp2.KeyChar);
                }
                while (distributionsp1 < 0);
            }
            else sprint -= 48;
            Console.WriteLine(" ");
            Console.WriteLine("Your sprint  equals {0}", sprint);
            return sprint;
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
            Console.WriteLine("Choose your master skills. You have 30 points to delegate into the following parameters, with minimum of 0 and maximum of 9: sprinter, stayer, intelligence, progressivity, perception, luck. To go to choosing stats press 1, to exit game press 2. Stat info is depicted while choosing");
            int statCharge = 30;
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
                character.sprint = ChooseSprint(statCharge);
                statCharge = statCharge - character.sprint;
                Console.WriteLine("You have {0} point to distribute", statCharge);
            }
            else
            {
                Exit_Game();
                System.Environment.Exit(0);
            }
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