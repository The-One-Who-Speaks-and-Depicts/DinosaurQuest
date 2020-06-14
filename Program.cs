using System;
using System.Collections.Generic;
using System.IO;



namespace TrialGame
{
    class Program
    {
        public static List<YourCreature.EnemyCreature> CharacterMenu(YourCreature character, Tile thisTile)
        {
            int click = -1;
            do
            {                
                Console.WriteLine("Press 8 to quit main menu, press 9 to get stats, press 0 to exiWt");
                click = ServiceFunctions.ChoosingRightKey();
                if (click == 0) GameFunctions.Exit_Game();
                else if (click == 9) character.PrintCharacterStats();
                else if (click == 8)
                {
                    return thisTile.m_creaturesList;
                }
            }
            while (click != 1);
            return thisTile.m_creaturesList;
        }
        
        

        

        public static int ChooseStat(String S, int wholeAmount)
        {
            int decision;

            Console.WriteLine("Choose your {0} stat now", S);
            decision = ServiceFunctions.ChoosingRightKey();
           

            
            while ((decision < 0) || (decision > 9)) 
                {
                    Console.WriteLine("Please insert appropriate number, it should be more than 0 and less than 9");
                    decision = ServiceFunctions.ChoosingRightKey();
                    
            }
                       
            while (wholeAmount < decision)
                {
                Console.WriteLine("Please insert appropriate number, you have only {0} points to distribute", wholeAmount);
                decision = ServiceFunctions.ChoosingRightKey();
                
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
            string currDir = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(Path.Combine(currDir, "Tech"));
            Directory.CreateDirectory(Path.Combine(currDir, "Saves"));
            GameFunctions.MainMenu();
        }


        
    }
}