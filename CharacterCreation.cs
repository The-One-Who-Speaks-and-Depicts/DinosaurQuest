

﻿using System;
<<<<<<< HEAD

=======
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Int32;
>>>>>>> 6952d5411cb7971f0656465aad19ef0474b87e4b


namespace TrialGame
{

    public class CharacterCreation
    {
        public CharacterCreation()
        {


            Console.WriteLine("Welcome to the game of prehistory. It is a story of a predator dinosaur, little cryolophosaurus, who is growing in the Antarctica of Early Jurassic. The aim of a game is to guide your creature through the childhood, teenagehood, adolescence and adult life. The world around you is going to be harsh and cruel. Primary objective is survival by any cost. Secondary objective is to keep being the character you truly want to be.");
            YourCreature character = new YourCreature();
            character.name = "персонаж";

            do
            {
                character.name = Program.preGiving();
            }
<<<<<<< HEAD
            while (Program.ChoosingRightKey() != 1);
=======
            while (Console.ReadLine() != "1");
>>>>>>> 6952d5411cb7971f0656465aad19ef0474b87e4b

            Console.WriteLine("Congratulations! You've chosen your name. Now you are called {0}", character.name);
            character.SetDefault(0, 100, 0);
            Console.WriteLine("Your level is {0}. Your health is {1}. You have {2} experience", character.level, character.health, character.exp);
            Console.WriteLine("Choose your master stats. You have 30 points to delegate into the following parameters, with minimum of 0 and maximum of 9: sprinter, stayer, intelligence, progressivity, perception, luck. To go to choosing stats press 1, to exit game press 2. Stat info is depicted while choosing");
            int decision = Program.ChoosingRightKey();

            while (decision > 2)
            {
                Console.WriteLine("Please press appropriate key");
                decision = Program.ChoosingRightKey();
            }




            if (decision == 1)
            {

                int statCharge;
                string[] StatInfo = new string[] {
                    "Sprint makes you more fast and strong. It helps you attack bigger herbivore creatures and subjugate ones of your kind. Also it strengthen your bones, so they are not as likely to be damaged.",
                    "Stayer makes you more agile and flexible. It helps you attack smaller creatures and sneak away of bigger predators. Your bones are recovering faster as well.",
                    "Intelligence makes you more clever and able to solving tasks. It helps you solve harder tasks and outsmart your rivals.",
                    "Progressivity improves your biodiversity. It enables you to acquire some important physical features that move your kind further. Also it helps you finding completely new solutions.",
                    "Perception improves your senses.  You are able to find other creatures in a more effective way and scavenge better.",
                    "Luck gives you better chances to make the best out of situation. It enables you scavenge more things, especially rare, and get away of bad encounters"
            };
                do
                {
                    statCharge = 30;
                    character.DoStats();
                    for (int i = 0; i < 6; i++)
                    {
                        int number = i;
                        Console.WriteLine(StatInfo[i]);
                        switch (number)
                        {
                            case 0:
                                character.sprint += Program.ChooseStat(character.characterStats[i], statCharge);
                                statCharge = statCharge - character.sprint;
                                statCharge++;
                                break;
                            case 1:
                                character.stayer += Program.ChooseStat(character.characterStats[i], statCharge);
                                statCharge = statCharge - character.stayer;
                                statCharge++;
                                break;
                            case 2:
                                character.intelligence += Program.ChooseStat(character.characterStats[i], statCharge);
                                statCharge = statCharge - character.intelligence;
                                statCharge++;
                                break;
                            case 3:
                                character.progressivity += Program.ChooseStat(character.characterStats[i], statCharge);
                                statCharge = statCharge - character.progressivity;
                                statCharge++;
                                break;
                            case 4:
                                character.perception += Program.ChooseStat(character.characterStats[i], statCharge);
                                statCharge = statCharge - character.perception;
                                statCharge++;
                                break;
                            case 5:
                                character.luck += Program.ChooseStat(character.characterStats[i], statCharge);
                                statCharge = statCharge - character.luck;
                                statCharge++;
                                break;

                        }


                        Console.WriteLine("You have {0} points to distribute", statCharge);

                    }


                    Console.WriteLine("Your stats are: sprint {0}, stayer {1}, intelligence {2}, progressivity {3}, perception {4}, luck {5}. If you are satisfied, press 1; if not, press 2", character.sprint, character.stayer, character.intelligence, character.progressivity, character.perception, character.luck);
                    decision = Program.ChoosingRightKey();

                    while ((decision < 1) || (decision > 2))
                    {
                        Console.WriteLine("Please press appropriate key");
                        Console.WriteLine("Your stats are: sprint {0}, stayer {1}, intelligence {2}, progressivity {3}, perception {4}, luck {5}. If you are satisfied, press 1; if not, press 2", character.sprint, character.stayer, character.intelligence, character.progressivity, character.perception, character.luck);
                        decision = Program.ChoosingRightKey();
                    }


                    if (decision != 1)
                    {
                        decision = 0;
                        character.ResetStats();
                        statCharge = 30;
                    }

                    else if (statCharge > 0)
                    {
                        Console.WriteLine("You should distribute all the stats. You have {0} stats left, redistribute your stats once again", statCharge);
                        character.ResetStats();
                        decision = 0;
                    }
                }
                while ((decision != 2) && (statCharge > 0));


            }
            else
<<<<<<< HEAD
            {
                Program.Exit_Game();
            }

            Console.WriteLine("Now you have to choose your creature biological sex, for this kind of creatures masculine either feminine. Females get +1 sprint, as they are stronger, and probably faster. Males get +1 stayer, as they are weaker, but more agile and sneaky. Press 1 for choosing female, press 2 for choosing male");
            decision = Program.ChoosingRightKey();


            do
            {
=======
            {
                Program.Exit_Game();
            }

            Console.WriteLine("Now you have to choose your creature biological sex, for this kind of creatures masculine either feminine. Females get +1 sprint, as they are stronger, and probably faster. Males get +1 stayer, as they are weaker, but more agile and sneaky. Press 1 for choosing female, press 2 for choosing male");
            decision = Program.ChoosingRightKey();


            do
            {
>>>>>>> 6952d5411cb7971f0656465aad19ef0474b87e4b
                while ((decision < 1) || (decision > 2))
                {
                    Console.WriteLine("Press 1 for feminine, 2 for masculine");
                    decision = Program.ChoosingRightKey();
                }

                if (decision == 2)
                {
                    Console.WriteLine("You are male now");
                    character.sex = 1;
                }
                else if (decision == 1)
                {
                    Console.WriteLine("You are female now");
                    character.sex = 0;
                }

                Console.WriteLine("If you are sure about your choice, press 1, in the other case, press any other key");
                decision = Program.ChoosingRightKey();
            }
            while (decision != 1);
            String bioSex = character.PrintSex();
            if (character.sex == 1) character.stayer++;
            else character.sprint++;
            Console.WriteLine("Your name is {0}, you are of {1} sex, you have level {2} and {3} health, your stats are {4} sprint, {5} stayer, {6} intelligence, {7} progressivity, {8} perception, {9} luck.", character.name, bioSex, character.level, character.health, character.sprint, character.stayer, character.intelligence, character.progressivity, character.perception, character.luck);
            Console.WriteLine("You are going to the tutorial level. Press 1  to do that, press any key to exit the game");
            decision = Program.ChoosingRightKey();
            RecordedSaves.Save_Game(character, 0);
            if (decision != 1) Program.Exit_Game();
            else Tutorial.Tutorial_Entrance(character);
        }
    }
}