
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Int32;

namespace TrialGame
{
    class Tutorial
    {
        public static void OnLevelChange(object sender, EventArgs e)
        {
            
            Console.WriteLine("{0} is how level changed", YourCreature.LevelDifferenceOutput());
        }

        public static void OnHealthChange(object sender, EventArgs e)
        {

            Console.WriteLine("{0} is how health changed", YourCreature.HealthDifferenceOutput());
        }

        public static void OnSprintChange(object sender, EventArgs e)
        {

            Console.WriteLine("{0} is how sprint changed", YourCreature.SprintDifferenceOutput());
        }

        public static void OnStayerChange(object sender, EventArgs e)
        {

            Console.WriteLine("{0} is how stayer changed", YourCreature.StayerDifferenceOutput());
        }

        public static void OnIntelligenceChange(object sender, EventArgs e)
        {

            Console.WriteLine("{0} is how stayer changed", YourCreature.IntelligenceDifferenceOutput());
        }

        public static void OnProgressivityChange(object sender, EventArgs e)
        {

            Console.WriteLine("{0} is how progressivity changed", YourCreature.ProgressivityDifferenceOutput());
        }

        public static void OnPerceptionChange(object sender, EventArgs e)
        {

            Console.WriteLine("{0} is how perception changed", YourCreature.PerceptionDifferenceOutput());
        }

        public static void OnLuckChange(object sender, EventArgs e)
        {

            Console.WriteLine("{0} is how luck changed", YourCreature.LuckDifferenceOutput());
        }

        public static void OnCriticalHealth(object sender, EventArgs e)
        {
            Console.WriteLine("Critical danger!");
        }

        public static void ShowingUpTutorial (YourCreature playerCreature, YourCreature.EnemyCreature.Cryolophosaurus Enemy_Cryolophosaurus )
        {
            Console.WriteLine("It's time for the aspect of showing up. Showing up is one of the main ways of interaction between the creature of one kind. It is not harmful, just the test of how progressive and lucky both creatures are. By this you can subjugate ones of your own kind, or make them go away. It is useful for creating your own pack or fighting with others");
            Console.WriteLine("{0} attacks {1}, trying to make {1} run away", playerCreature.name, Enemy_Cryolophosaurus.name);
            YourCreature.EnemyCreature.ShowingUp(playerCreature, Enemy_Cryolophosaurus, playerCreature.name, Enemy_Cryolophosaurus.name);
        }

        public static void Tutorial_Entrance(YourCreature character)
        {

            RecordedSaves.Save_Game(character, 1);
            Console.WriteLine("You are now an egg, so, everything you can do is exist, while other creatures decide, what your fate is going to be like. However, some divine bodyless sentient creature that governs you, is able to help you by telling your mother what is going to be the best for you. And she will help this divine creature as well, by showing how this cruel world works. It is not too long before your birth, however, for your mother these are going to be the truly hardest hours of her parenthood. And now they are to begin. Let the desperate Diviner brace themselves, Early Jurassic of Antarctica begins!");
            YourCreature mother = new YourCreature();
            mother.name = "Mother Cryolophosaurus";
            mother.sex = 1;
            mother.SetDefault(35, 450, 350001);
            mother.DoStats();
            mother.sprint += 7;
            mother.stayer += 4;
            mother.intelligence += 5;
            mother.progressivity += 8;
            mother.perception += 4;
            mother.luck += 3;
            mother.PrintCharacterStats();
            mother.LevelChange += OnLevelChange;
            mother.HealthChange += OnHealthChange;
            mother.SprintChange += OnSprintChange;
            mother.StayerChange += OnStayerChange;
            mother.IntelligenceChange += OnIntelligenceChange;
            mother.ProgressivityChange += OnProgressivityChange;
            mother.PerceptionChange += OnPerceptionChange;
            mother.LuckChange += OnLuckChange;
            Console.WriteLine("Mother is starving and thirsty. She is desperate of satisfying her needs, because she was warming her unborn children for weeks, or even months now. But she still needs to guard them. That is going to be a very hard choice for her. Does she want to go away for hunting (1) or is she going to stay here  and protect her children until her last dying breath(2)");
            mother.CriticalHealth += OnCriticalHealth;
            int decision = Program.ChoosingRightKey();
            while ((decision < 1) || (decision > 2))
            {
                Console.WriteLine("Please press appropriate key");
                decision = Program.ChoosingRightKey();
            }

            if (decision == 1)
            {
                Tutorial_Final(character, mother, 1);

            }
            else if (decision == 2)
            {
                Tutorial_Final(character, mother, 0);
            }

            Program.Exit_Game();
        }

        public static void Tutorial_Final(YourCreature character, YourCreature mother, int result)
        {
            switch (result)
            {
                case 0: // mother stayed
                    {
                        Console.WriteLine("Putting child's needs over mother's ones for this creature is a true step forward, however, it is not so clever thing to do in that particular situation. Mother is staying near her nest and soon discovers that it was her lucky choice to stay. A small primitive mammal intends to scavenge the nest. In such kind of cases usually it is possible for one to have three options: sneak and attack from an ambush (testing your luck against enemy's perception), attack openly (testing your sprint and progressivity against enemy's stayer and intelligence) or wait. However, Mother does not have this choice. She has to attack, otherwise her children are going to be killed.");
                        mother.progressivity++;
                        mother.stayer--;
                        mother.luck++;
                        Cryolophosaurus_Tile_Generation(character, mother, 0);                   
                        break;
                    }
                case 1: // mother went away, but returned
                    {
                        Console.WriteLine("Putting mother's needs over child's ones is clever, but, at this point of history, not so progressive step. Mother is going into the woods.");
                        mother.intelligence++;
                        Console.WriteLine("You hear strange background noises. Maybe, after all, the more clever choice would be staying near the nest? Press 1 to do that, else press any other key");
                        int decision = Program.ChoosingRightKey();
                        if (decision == 1)
                        {
                            mother.sprint--;
                            mother.luck++;
                            Console.WriteLine("You are not so fast in decisions, but luck is strong in you, because you have arrived back just in time. A small primitive mammal intends to scavenge the nest. In such kind of cases usually it is possible for one to have three options: sneak and attack from an ambush (testing your luck against enemy's perception), attack openly (testing your sprint and progressivity against enemy's stayer and intelligence) or wait. However, Mother does not have this choice. She has to attack, either way her children are going to be killed.");
                            Cryolophosaurus_Tile_Generation(character, mother, 0);
                            
                        }
                        else
                        {
                            Tutorial_Final(character, mother, 2);

                        }
                        break;
                    }
                case 2: // mother went away and not returned
                    {
                        mother.sprint++;
                        mother.luck--;
                        Console.WriteLine("You are fast in decisions, but that may do you the bad luck in the future. However, now you are lucky, because soon you are to discover a prey. A small dicynodontus is heard somewhere close. In such kind of cases usually it is possible for one to have three options: sneak and attack from an ambush (testing your luck against enemy's perception), attack openly (testing your sprint and progressivity against enemy's stayer and intelligence) or wait. However, Mother does not have this choice. She has to attack, or she will die because of starvation.");
                        Tile next = new Tile("southEast", "Fall", "Mountainside", mother, 1, 2);
                        Console.WriteLine("You have satisfied your needs. Now it is time to come back");
                        Tile next1 = new Tile("northWest", "Fall", "Nest", mother, 0, 9);
                        Console.WriteLine("You sense that going away was, probably, not such a good decision. Your nest is now being destroyed by somebody. Would you protect the last of your children (1), or, maybe, bring in to life next year(any key)?");
                        int decision = Program.ChoosingRightKey();
                        if (decision == 1)
                        {
                            Console.WriteLine("It seems that you found the one who is guilty");
                            Cryolophosaurus_Tile_Generation(character, mother, 1);
                            
                        }
                        else
                        {
                            Console.WriteLine("Well, young cryolophosaurus. Your life is ended by Adelobasileus. Maybe, in the next universe? Press 1 to try, press any key to go away.");
                            decision = Program.ChoosingRightKey();
                            if (decision == 1)
                            {
                                RecordedSaves.Auto_Load_Game();
                            }
                            else Program.Exit_Game();
                        }
                        break;
                    }
                default:
                    { 
                    Console.WriteLine("Something went terribly wrong. Restarting level...");
                    RecordedSaves.Auto_Load_Game();
                    break;
                    }
            }
        }

        public static void Cryolophosaurus_Tile_Generation (YourCreature character, YourCreature mother, int mother_going_away)
        {
            Tile next = new Tile("noDir", "Fall", "Nest", mother, 0, 1);
            Console.WriteLine("You have both satisfied your needs and defended your nest. But now you hear another strange noise. Somebody is coming");
            YourCreature.EnemyCreature.Cryolophosaurus Enemy_Cryolophosaurus = new YourCreature.EnemyCreature.Cryolophosaurus(1);
            Console.WriteLine("Would you like to sneak in the trees (1), or boldly face the danger (other key)?");
            int decision = Program.ChoosingRightKey();
            if (decision == 1)
            {
                Tutorial_Fight(character, mother, Enemy_Cryolophosaurus, 0);
            }
            else { 
            switch (mother_going_away)
            {
                case 0: // mother stayed/returned                   
                    { 
                        Tutorial_Fight(character, mother, Enemy_Cryolophosaurus, 1);
                        break;
                    }                    
                    
                case 1: // mother went away                    
                    {
                        Tutorial_Fight(character, mother, Enemy_Cryolophosaurus, 2);
                        break;
                    }                    
                    
            }
            }
        }

        public static void Tutorial_Fight(YourCreature character, YourCreature mother, YourCreature.EnemyCreature.Cryolophosaurus Enemy_Cryolophosaurus, int result)
        {
            switch (result)
            {
                case 0: //trees
                    { 
                    Console.WriteLine("You have successfully sneaked in the trees. The male Cryolophosaurus is basically here. Would you like to stealth attack him (1), or suddenly appear before his eyes (other key)?");
                    int decision = Program.ChoosingRightKey();
                    if (decision == 1)
                    {
                        mother.LuckChange -= OnLuckChange;
                        mother.m_luck++;
                        ShowingUpTutorial(mother, Enemy_Cryolophosaurus);
                        mother.m_luck--;
                        mother.LuckChange += OnLuckChange;
                        Console.WriteLine("{0} made bigger rival run away, standing now near the nest with her children,one of them  is {1}. The day dawns.", mother.name, character.name);
                        Tutorial_Transfer(character, mother, Enemy_Cryolophosaurus);

                    }
                    else
                    {
                        Tutorial_Fight(character, mother, Enemy_Cryolophosaurus, 1);
                    }
                    break;
                    }

                case 1: //staying
                    { 
                    Console.WriteLine("You are waiting. Steps are coming closer in closer.");
                    ShowingUpTutorial(mother, Enemy_Cryolophosaurus);
                    Console.WriteLine("Mother failed to fear the big male. Now it is time to fight for children.");
                    YourCreature.EnemyCreature.Attack(mother, Enemy_Cryolophosaurus);
                    Console.WriteLine("{0} is standing now near the nest with her children,one of them  is {1}. The day dawns.", mother.name, character.name);
                    Tutorial_Transfer(character, mother, Enemy_Cryolophosaurus);
                    break;
                    }
                case 2: //trees of not-stayed-mother
                    { 
                    Console.WriteLine("You do not have enough time. You have the only choice, which is waiting for predator to come.");
                    ShowingUpTutorial(mother, Enemy_Cryolophosaurus);
                    Console.WriteLine("Mother failed to fear the big male. Now it is time to fight for children.");
                    YourCreature.EnemyCreature.Attack(mother, Enemy_Cryolophosaurus);
                    Console.WriteLine("{0} is standing now near the nest with only two remaining children,one of them  is {1}. The day dawns.", mother.name, character.name);
                    Tutorial_Transfer(character, mother, Enemy_Cryolophosaurus);
                    break;
                    }
            }
        }

        public static void Tutorial_Transfer (YourCreature character, YourCreature mother, YourCreature.EnemyCreature.Cryolophosaurus Enemy_Cryolophosaurus)
        {
            Console.WriteLine("To go to the next stage, press 1, to repeat tutorial level, press 2. Press any other key to exit game");
            int decision = Program.ChoosingRightKey();
            if (decision == 1)
                Level1.Level1_Entrance(character);
            else if (decision == 2)
                RecordedSaves.Auto_Load_Game();
            else Program.Exit_Game();
        }
    }
}