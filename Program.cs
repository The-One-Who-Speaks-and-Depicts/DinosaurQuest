﻿using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Int32;
>>>>>>> 6952d5411cb7971f0656465aad19ef0474b87e4b



namespace TrialGame
{
    class Program
    {
        public static List<YourCreature.EnemyCreature> MainMenu(YourCreature character, Tile thisTile)
        {
            int click = -1;
            do
            {                
                Console.WriteLine("Press 8 to quit main menu, press 9 to get stats, press 0 to exit");
                click = Program.ChoosingRightKey();
                if (click == 0) Program.Exit_Game();
                else if (click == 9) character.PrintCharacterStats();
                else if (click == 8)
                {
                    return thisTile.m_creaturesList;
                }
            }
            while (click != 1);
            return thisTile.m_creaturesList;
        }
        
        public static void Exit_Game()
        {
            Console.WriteLine("For End press Enter");
            string finish = Console.ReadLine();
            Console.WriteLine("Best luck!");
            Environment.Exit(0);

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

        public static void Start()
        {
            Console.WriteLine("Welcome to the Predators of the Antarctica: the Game! To start a new game, press 1, to continue, press 2, to load game, press 3, to exit game, press 0");
            int decision = Program.ChoosingRightKey();
            switch (decision)
            {
                case 1:
<<<<<<< HEAD
                    Character newCharacter = new Character();
=======
                    CharacterCreation new_game = new CharacterCreation();
>>>>>>> 6952d5411cb7971f0656465aad19ef0474b87e4b
                    break;
                case 2:
                    RecordedSaves.Auto_Load_Game();
                    break;
                case 3:
                    RecordedSaves.Load_Game();
                    break;
                default:
                    Program.Exit_Game();
                    break;
            }
        }

        static void Main(string[] args)
        {
            System.IO.Directory.CreateDirectory(@"C:\DinosaurGame\");
            System.IO.Directory.CreateDirectory(@"C:\DinosaurGame\Tech\");
            Start();
        }


        
    }
}