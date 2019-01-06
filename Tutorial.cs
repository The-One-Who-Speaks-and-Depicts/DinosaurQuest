using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Int32;

namespace TrialGame
{
    class Tutorial
    {
        public static void OnStatChange(object sender, EventArgs e)
        {
            
        }

       public static void Tutorial_Entrance (YourCreature character)
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
            mother.StatChange += OnStatChange;
            Console.WriteLine("Mother is starving and thirsty. She is desperate of satisfying her needs, because she was warming her unborn children for weeks, or even months now. But she still needs to guard them. That is going to be a very hard choice for her. Does she want to go away for hunting (1) or is she going to stay here  and protect her children until her last dying breath(2)");
            int decision = Program.ChoosingRightKey();
            while ((decision < 1) || (decision > 2)) 
                {
                Console.WriteLine("Please press appropriate key");
                decision = Program.ChoosingRightKey();
            }
            bool IsNestAbandoned = false;
            if (decision == 1)
            {
                mother.StatChange += OnStatChange;
                Console.WriteLine("Putting mother's needs over child's ones is clever, but, at this point of history, not so progressive step. Mother is going into the woods.");
                mother.intelligence++;
                Console.WriteLine("You hear strange background noises. Maybe, after all, the more clever choice would be staying near the nest? Press 1 to do that, else press any other key");
                decision = Program.ChoosingRightKey();
                if (decision == 1)
                {
                    mother.StatChange += OnStatChange;
                    mother.sprint--;
                    mother.luck++;
                    Console.WriteLine("You are not so fast in decisions, but luck is strong in you, because you have arrived back just in time. A small primitive mammal intends to scavenge the nest. In such kind of cases usually it is possible for one to have three options: sneak and attack from an ambush (testing your luck against enemy's perception), attack openly (testing your sprint and progressivity against enemy's stayer and intelligence) or wait. However, Mother does not have this choice. She has to attack, either way her children are going to be killed.");
                    Tile next = new Tile("noDir", "Fall", "Nest", mother, 0, 1);
                    Console.WriteLine("You have both satisfied your needs and defended your nest. But now you hear another strange noise.");
                    YourCreature.EnemyCreature.Cryolophosaurus Enemy_Cryolophosaurus = new YourCreature.EnemyCreature.Cryolophosaurus();
                }
                else
                {
                    mother.StatChange += OnStatChange;
                    IsNestAbandoned = true;
                    mother.sprint--;
                    mother.luck++;
                    Console.WriteLine("You are fast in decisions, but that may do you the bad luck in the future. However, now you are lucky, because soon you are to discover a prey. A small dicynodontus is heard somewhere close. In such kind of cases usually it is possible for one to have three options: sneak and attack from an ambush (testing your luck against enemy's perception), attack openly (testing your sprint and progressivity against enemy's stayer and intelligence) or wait. However, Mother does not have this choice. She has to attack, or she will die because of starvation.");
                    Tile next = new Tile("southEast", "Fall", "Mountainside", mother, 1, 2);
                    Console.WriteLine("You have satisfied your needs. Now it is time to come back");
                    Tile next1 = new Tile ("northWest", "Fall", "Nest", mother, 0, 9);
                    Console.WriteLine("You sense that going away was, probably, not such a good decision. Your nest is now being destroyed by somebody. Would you protect the last of your children (1), or, maybe, bring in to life next year(any key)?");
                    decision = Program.ChoosingRightKey();
                    if (decision == 1)
                    {
                        Console.WriteLine("It seens that you found the one who is guilty");
                        Tile current = new Tile("noDir", "Fall", "Nest", mother, 0, 1);
                        Console.WriteLine("You have both satisfied your needs and defended your nest. But now you hear another strange noise.");
                        YourCreature.EnemyCreature.Cryolophosaurus Enemy_Cryolophosaurus = new YourCreature.EnemyCreature.Cryolophosaurus();
                    }
                    else {
                        Console.WriteLine("Well, young cryolophosaurus. Your life is ended by Adelobasileus. Maybe, in the next universe? Press 1 to try, press any key to go away.");
                        decision = Program.ChoosingRightKey();
                        if (decision == 1)
                        {
                            RecordedSaves.Load_Game();
                        }
                        else Program.Exit_Game();
                    }
                }
            }
            else if (decision == 2)
            {
                mother.StatChange += OnStatChange;
                Console.WriteLine("Putting child's needs over mother's ones for this creature is a true step forward, however, it is not so clever thing to do in that particular situation. Mother is staying near her nest and soon discovers that it was her lucky choice to stay. A small primitive mammal intends to scavenge the nest. In such kind of cases usually it is possible for one to have three options: sneak and attack from an ambush (testing your luck against enemy's perception), attack openly (testing your sprint and progressivity against enemy's stayer and intelligence) or wait. However, Mother does not have this choice. She has to attack, otherwise her children are going to be killed.");
                mother.progressivity++;
                mother.stayer--;
                mother.luck++;
                Tile next = new Tile("noDir", "Fall", "Nest", mother, 0, 1);
                Console.WriteLine("You have both satisfied your needs and defended your nest. But now you hear another strange noise.");
                YourCreature.EnemyCreature.Cryolophosaurus Enemy_Cryolophosaurus = new YourCreature.EnemyCreature.Cryolophosaurus ();
            }
           
            Program.Exit_Game();
        }
    }
}
