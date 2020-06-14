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
        public static void Start_Game()
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
                    Start_Game();
                    Exit_Game();
                    break;
                case 2:
                    RecordedSaves.Auto_Load_Game();
                    break;
                case 3:
                    RecordedSaves.Load_Game();
                    break;
                default:
                    Exit_Game();
                    break;
            }
        }
    }
}
