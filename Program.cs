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
        
        public static void Exit_Game()
        {
            Console.WriteLine("For End press Enter");
            String finish = Console.ReadLine();
            Console.WriteLine("Best luck!");
            System.Environment.Exit(0);

        }

        public static int ChoosingRightKey()
        {
            int m_decision;
            ConsoleKeyInfo m_readKey;
            m_readKey = Console.ReadKey();
            Console.WriteLine(" ");
            m_decision = Convert.ToInt32(m_readKey.KeyChar);
            m_decision -= 48;
            return m_decision;
        }

        public static int ChooseStat(String S, int wholeAmount)
        {
            int decision;

            Console.WriteLine("Choose your {0} stat now", S);
            decision = ChoosingRightKey();
           

            
            while ((decision < 0) || (decision > 9)) 
                {
                    Console.WriteLine("Please insert appropriate number, it should be more than 0 and less than 9");
                    decision = ChoosingRightKey();
                    
            }
                       
            while (wholeAmount < decision)
                {
                Console.WriteLine("Please insert appropriate number, you have only {0} points to distribute", wholeAmount);
                decision = ChoosingRightKey();
                
            }
            
            int statOut = decision;
            Console.WriteLine("Your {0}  equals {1}", S, ++statOut);
            Console.WriteLine(" ");
            return decision;
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
            Console.WriteLine("Welcome to the Predators of the Antarctica: the Game! To start a new game, press 1, to continue, press 2, to exit game, press 0");
            int decision = Program.ChoosingRightKey();
            switch(decision)
            {
                case 1:
                    CharacterCreation new_game = new CharacterCreation();
                    break;
                case 2:
                    RecordedSaves.Load_Game();
                    break;
                default:
                    Program.Exit_Game();
                    break;
            }
        }


        

    }
}