using System;
using System.Collections.Generic;
using System.IO;
using DinosaurQuest.Stages;
using DinosaurQuest.Creatures;

namespace DinosaurQuest.GameFunctions
{
    static class MainFunctions
    {
        public static void Exit_Game()
        {
            Console.WriteLine("For End press Enter");
            Console.ReadLine();
            Environment.Exit(0);

        }

        public static void MainMenu()
        {
            Console.WriteLine("Welcome to the game! To start a new game, press 1, to continue, press 2, to load game, press 3, to exit game, press any other key");
            int decision = ServiceFunctions.ChoosingRightKey(Console.ReadKey().KeyChar);
            switch (decision)
            {
                case 1:
                    Character currentCharacter = Start.Start_Game();
                    Console.WriteLine("You are going to the tutorial level. Press 1 to do that, press any other key to exit the game");
                    decision = ServiceFunctions.ChoosingRightKey(Console.ReadKey().KeyChar);                    
                    if (decision < 1 || decision > 2) Save.Save_Game(currentCharacter, 0);
                    else
                    {
                        Save.Save_Game(currentCharacter, 0);
                        new Tutorial(currentCharacter);                        
                    }
                    Exit_Game();
                    break;
                case 2:
                    Save.Auto_Load_Game();
                    break;
                case 3:
                    Save.Load_Game();
                    break;
                default:
                    Exit_Game();
                    break;
            }
        }
    }
}
