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
            Boolean isNameGiven = false;
            if (!isNameGiven)
            {
                do 
                    {
                    character.name = preGiving();
                }
                        while (Console.ReadLine() != "1");
            }
            Console.WriteLine("Congratulations! You've chosen your name. Now you are called {0}", character.name);
            
            Console.WriteLine("For End press Enter");
            String finish = Console.ReadLine();
        }
    }
    

        public class YourCreature
        {
            public string name;

            public YourCreature()
            {

            } 

            public YourCreature(String givenName)
            {
                name = givenName;
            }

        }
    
}