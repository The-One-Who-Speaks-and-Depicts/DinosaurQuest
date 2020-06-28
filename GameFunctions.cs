using System;
using System.Collections.Generic;
using System.IO;

namespace TrialGame
{
    static class GameFunctions
    {        



        public static Character Start_Game()
        {            
            using (StreamReader intro = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "intro.txt")))
            {
                string introText = intro.ReadToEnd();
                Console.WriteLine(introText);
            }
            Character newCharacter = new Character();
            newCharacter.name = Character.preGiving();
            Console.WriteLine("Congratulations! You've chosen your name. Now you are called {0}", newCharacter.name);
            Console.WriteLine("Your level is {0}. Your health is {1}, and your stamina is {2}. You have {3} experience", newCharacter.level, newCharacter.health, newCharacter.stamina, newCharacter.exp);
            List<string> statLines = new List<string>();
            using (StreamReader stats = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "statsDialogue.txt")))
            {
                while(!stats.EndOfStream)
                {
                    statLines.Add(stats.ReadLine());
                }
            }
            Console.WriteLine(statLines[0]);
            int decision = ServiceFunctions.ChoosingRightKey();
            while ((decision < 0) || decision > 1)
            {
                Console.WriteLine("Please press appropriate key");
                decision = ServiceFunctions.ChoosingRightKey();
            }
            if (decision > 0)
            {
                if (decision  > 1)
                {

                }
                
                do
                {
                    newCharacter.Perks = new List<IPerk>();
                    // stat choice to implement
                    Console.WriteLine("Your stats are. Are you satisfied? 1 for yes, 2 for no"); // right to end!
                    decision = ServiceFunctions.ChoosingRightKey();
                    while ((decision < 1) || (decision > 2))
                    {
                        Console.WriteLine("Please press appropriate key");
                        Console.WriteLine("Your stats are. Are you satisfied? 1 for yes, 2 for no"); // right to end!
                        decision = ServiceFunctions.ChoosingRightKey();
                    }
                }
                while (decision != 1);                
            }            
            else
            {
                Exit_Game();
            }
            Console.WriteLine("Now you have to choose your creature biological sex, for this kind of creatures masculine either feminine. Press 1 for choosing female + swap parameters, press 2 for choosing male + swap parameters, press 3 for choosing female + getting unique perk, press 4 for choosing male + getting unique perk"); //TELL'EM DIFFERENCE            
            do
            {
                decision = 0;
                while ((decision < 1) || (decision > 2))
                {                    
                    decision = ServiceFunctions.ChoosingRightKey();
                }

                if (decision == 2)
                {
                    Console.WriteLine("You are male now");
                    newCharacter.gender = "masculine";
                }
                else if (decision == 1)
                {
                    Console.WriteLine("You are female now");
                    newCharacter.gender = "feminine";
                }
                // AddChoices

                Console.WriteLine("If you are sure about your choice, press 1, in the other case, press any other key");
                decision = ServiceFunctions.ChoosingRightKey();
                if (decision != 1)
                {
                    Console.WriteLine("Press 1 for feminine, 2 for masculine");
                }
            }
            while (decision != 1);
            if (newCharacter.gender == "feminine")
            {
                //do some thing
            }
            else
            {
                // do another thing
            }
            Console.WriteLine(""); //TELL'EM WHAT THEY DO
            return newCharacter;

        }
        public static void Exit_Game()
        {
            Console.WriteLine("For End press Enter");
            Console.ReadLine();
            Environment.Exit(0);

        }

        public static void MainMenu()
        {
            Console.WriteLine("Welcome to the game! To start a new game, press 1, to continue, press 2, to load game, press 3, to exit game, press any other key");
            int decision = ServiceFunctions.ChoosingRightKey();
            switch (decision)
            {
                case 1:
                    var currentCharacter = Start_Game();
                    Console.WriteLine("You are going to the tutorial level. Press 1 to do that, Press 2 to skip tutorial, press any key to exit the game");
                    decision = ServiceFunctions.ChoosingRightKey();                    
                    if (decision < 1 || decision > 2) Save.Save_Game(currentCharacter, 0);
                    if (decision == 2)
                    {
                        Save.Save_Game(currentCharacter, 2);
                        new Level1(currentCharacter);
                    }
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
