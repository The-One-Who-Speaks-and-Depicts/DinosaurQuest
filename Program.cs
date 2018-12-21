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
     public static string givingNameToCharacter ()
        {
            Console.WriteLine("Type the name of your creature");
            String str = Console.ReadLine();
            return str;
    }
        public static void preGiving()
        {
            String result = givingNameToCharacter();
            var player = new Creature.YourCreature(result);
            Console.WriteLine("Your name is {0}. If OK, enter 1, if not, enter 0", player.name);
        }
        static void Main(string[] args)
        {
            Boolean isNameGiven = false;
            if (!isNameGiven)
            {
                do preGiving(); while (Console.ReadLine() == "0");
            }
            
            
            Console.WriteLine("For End press Enter");
            String finish = Console.ReadLine();
        }
    }
    class Creature
    {
        
        public class YourCreature
        {
            public string name; 
            public YourCreature(String givenName)
            {
                name = givenName;    
            }
        }
    }
}
