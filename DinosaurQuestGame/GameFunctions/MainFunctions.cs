using System;
using System.Collections.Generic;
using System.IO;
using DinosaurQuest.Stages;
using DinosaurQuest.Creatures;
using DinosaurQuest.Perks;

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
                    Character currentCharacter = Start_Game();
                    Console.WriteLine("You are going to the tutorial level. Press 1 to do that, press any other key to exit the game");
                    decision = ServiceFunctions.ChoosingRightKey(Console.ReadKey().KeyChar);
                    if (decision != 1) Save.Save_Game(currentCharacter, 0);
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

        public static Character Start_Game()
        {
            using (StreamReader intro = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "intro.txt")))
            {
                Console.WriteLine(intro.ReadToEnd());
            }
            Character newCharacter = new Character();
            newCharacter.preGiving();
            Console.WriteLine($"Congratulations! You've chosen your name. Now you are called {newCharacter.name}.");
            Console.WriteLine($"\nYour health is {newCharacter.health}, and your stamina is {newCharacter.stamina}.\n");
            using (StreamReader stats = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "statsDialogue.txt")))
            {
                Console.WriteLine(stats.ReadToEnd());
            }
            int decision = ServiceFunctions.ChoosingRightKey(Console.ReadKey().KeyChar);
            while ((decision < 0) || decision > 1)
            {
                Console.WriteLine("Please press appropriate key");
                decision = ServiceFunctions.ChoosingRightKey(Console.ReadKey().KeyChar);
            }
            if (decision > 0)
            {
                newCharacter.ChooseStats();
                Console.WriteLine($"\nYour character may develop a certain set of skills during the game. The first one is Archaeopteryx:\n");
                newCharacter.CreditArchaeopteryx(new Archaeopteryx());
            }
            else
            {
                MainFunctions.Exit_Game();
            }
            newCharacter.SetGender(0);
            Console.WriteLine($"{newCharacter.name} is preparing to become a parent. Their first target is to watch for their not yet born children. Or... is it?\n");
            return newCharacter;
        }
    }
}
