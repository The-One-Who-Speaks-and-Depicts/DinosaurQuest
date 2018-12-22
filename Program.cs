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
        public static void StatInfo (int option)
        {
            Console.WriteLine("Info about stats shallst be here");
        }

        public static int ChooseSprint (int option)
        {
            int sprint;
            Console.WriteLine("Choose your sprinter now");
            sprint = Convert.ToInt32(Console.ReadKey().KeyChar);
            Console.WriteLine();
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
            character.SetDefault(0,100, 0);
            Console.WriteLine("Your level is {0}. Your health is {1}. You have {2} experience", character.level, character.health, character.exp);
            Console.WriteLine("Choose your master skills. You have 30 points to delegate into the following parameters, with minimum of 1 and maximum of 10: sprinter, stayer, intelligence, progressivity, perception, luck. To see more information press 1, to go to choosing stats press 2");
            ConsoleKeyInfo readKey;
            readKey = Console.ReadKey();
            int decision;
            decision = Convert.ToInt32(readKey.KeyChar);
            Console.WriteLine();
            if (decision >= 51)
            {
                int errorNumber;
                try
                {
                    errorNumber = decision;
                }
                catch (Exception e)
                {
                    do {
                        Console.WriteLine("You have to type 1 or 2");
                        readKey = Console.ReadKey();
                        decision = Convert.ToInt32(readKey.KeyChar);
                    }
                    while (decision > 51);
                }
            }
                else if (decision == 49)
                    {
                    StatInfo(decision);
                    }
                else if (decision == 50)
                {
                character.sprint = ChooseSprint(decision);
                }
        

            
            Console.WriteLine("For End press Enter");
            String finish = Console.ReadLine();
        }
    }
    

        public class YourCreature
        {
            public string name;
            public int health;
            public int level;
            public int exp;
            public int sprint;

            public YourCreature()
            {

            } 

            public YourCreature(String givenName)
            {
                name = givenName;
            }

            public void SetDefault (int level, int health, int exp)
        {
            this.level = level;
            this.health = health;
            this.exp = exp;
        }

        }
    
}