using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialGame
{
    static class GameFunctions
    {
        public static Character Start_Game()
        {
            StreamReader intro = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "intro.txt"));
            using (intro)
            {
                string introText = intro.ReadToEnd();
                Console.WriteLine(introText);
            }
            Character newCharacter = new Character();
            newCharacter.name = Character.preGiving();
            Console.WriteLine("Congratulations! You've chosen your name. Now you are called {0}", newCharacter.name);
            Console.WriteLine("Your level is {0}. Your health is {1}, and your stamina is {2}. You have {3} experience", newCharacter.level, newCharacter.health, newCharacter.stamina, newCharacter.exp);
            StreamReader stats = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "statsDialogue.txt"));
            List<string> statLines = new List<string>();
            using(stats)
            {
               while (!stats.EndOfStream)
                {
                    statLines.Add(stats.ReadLine());
                }
            }
            Console.WriteLine(statLines[0]);
            int decision = ServiceFunctions.ChoosingRightKey();
            while (decision > 2)
            {
                Console.WriteLine("Please press appropriate key");
                decision = ServiceFunctions.ChoosingRightKey();
            }
            if (decision == 1)
            {
                int statCharge;
                do
                {
                    statCharge = 35;
                    newCharacter.DoStats();
                    for (int i = 1; i < 8; i++)
                    {
                        int number = i;
                        Console.WriteLine(statLines[i]);
                        switch (number)
                        {
                            case 1:                                
                                newCharacter.strength += Character.ChooseStat("strength", statCharge);
                                statCharge = statCharge - newCharacter.strength;
                                statCharge++;
                                break;
                            case 2:
                                newCharacter.speed += Character.ChooseStat("speed", statCharge);
                                statCharge = statCharge - newCharacter.speed;
                                statCharge++;
                                break;
                            case 3:
                                newCharacter.agility += Character.ChooseStat("agility", statCharge);
                                statCharge = statCharge - newCharacter.agility;
                                statCharge++;
                                break;
                            case 4:
                                newCharacter.perception += Character.ChooseStat("perception", statCharge);
                                statCharge = statCharge - newCharacter.perception;
                                statCharge++;
                                break;
                            case 5:
                                newCharacter.luck += Character.ChooseStat("luck", statCharge);
                                statCharge = statCharge - newCharacter.luck;
                                statCharge++;
                                break;
                            case 6:
                                newCharacter.appearance += Character.ChooseStat("appearance", statCharge);
                                statCharge = statCharge - newCharacter.appearance;
                                statCharge++;
                                break;
                            case 7:
                                newCharacter.intelligence += Character.ChooseStat("intelligence", statCharge);
                                statCharge = statCharge - newCharacter.intelligence;
                                statCharge++;
                                break; 
                        }


                        Console.WriteLine("You have {0} points to distribute", statCharge);

                    }
                    if (statCharge > 0)
                    {
                        Console.WriteLine("You should distribute all the stats. You have {0} stats left, redistribute your stats once again", statCharge);
                        statCharge = 35;
                        newCharacter.DoStats();
                        decision = 0;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Your stats are: strength {0}, speed {1}, agility {2}, perception {3}, luck {4}, appearance {5}, intelligence {6}. If you are satisfied, press 1; if not, press 2", newCharacter.strength, newCharacter.speed, newCharacter.agility, newCharacter.perception, newCharacter.luck, newCharacter.appearance, newCharacter.intelligence);
                        decision = ServiceFunctions.ChoosingRightKey();
                        while ((decision < 1) || (decision > 2))
                        {
                            Console.WriteLine("Please press appropriate key");
                            Console.WriteLine("Your stats are: strength {0}, speed {1}, agility {2}, perception {3}, luck {4}, appearance {5}, intelligence {6}. If you are satisfied, press 1; if not, press 2", newCharacter.strength, newCharacter.speed, newCharacter.agility, newCharacter.perception, newCharacter.luck, newCharacter.appearance, newCharacter.intelligence);
                            decision = ServiceFunctions.ChoosingRightKey();
                        }


                        if (decision != 1)
                        {
                            decision = 0;
                            newCharacter.DoStats();

                        }
                    }
                }
                while ((decision != 2) && (statCharge > 0));                
            }
            else
            {
                Exit_Game();
            }
            Console.WriteLine("Now you have to choose your creature biological sex, for this kind of creatures masculine either feminine. Females get +1 strength, as they are stronger. Males get +1 agility, as they are weaker, but more durable. Press 1 for choosing female, press 2 for choosing male");            
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
                    newCharacter.sex = "masculine";
                }
                else if (decision == 1)
                {
                    Console.WriteLine("You are female now");
                    newCharacter.sex = "feminine";
                }

                Console.WriteLine("If you are sure about your choice, press 1, in the other case, press any other key");
                decision = ServiceFunctions.ChoosingRightKey();
                if (decision != 1)
                {
                    Console.WriteLine("Press 1 for feminine, 2 for masculine");
                }
            }
            while (decision != 1);
            if (newCharacter.sex == "feminine") newCharacter.strength++;
            else newCharacter.agility++;
            Console.WriteLine("Your name is {0}, you are of {1} sex, you have {2} exp and thus are of level {3}, {4} health and {5} stamina, your stats are {6} strength, {7} speed, {8} agility, {9} perception, {10} luck, {11} appearance, {12} intelligence.", newCharacter.name, newCharacter.sex, newCharacter.exp, newCharacter.level, newCharacter.health, newCharacter.stamina, newCharacter.strength, newCharacter.speed, newCharacter.agility, newCharacter.perception, newCharacter.luck, newCharacter.appearance, newCharacter.intelligence);
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
                        new Level1(5, 5, currentCharacter);
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
