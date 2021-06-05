using System;
using System.Collections.Generic;
using System.IO;
using DinosaurQuest.Creatures;
using DinosaurQuest.GameFunctions;
using DinosaurQuest.Perks;

namespace DinosaurQuest.Stages
{
    static class Start
    {

        public static Character Start_Game()
        {            
            using (StreamReader intro = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "intro.txt")))
            {
                Console.WriteLine(intro.ReadToEnd());
            }
            Character newCharacter = new Character();
            newCharacter.preGiving();
            Console.WriteLine("Congratulations! You've chosen your name. Now you are called {0}", newCharacter.name);
            Console.WriteLine("\nYour health is {0}, and your stamina is {1}.\n", newCharacter.health, newCharacter.stamina);
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
                newCharacter.perks = new List<IPerk>();
                Archaeopteryx perk = new Archaeopteryx(); 
                newCharacter.perks.Add(perk);
                Console.WriteLine("\nYour character may develop a certain set of skills during the game. The first one is Archaeopteryx:\n");
                Console.WriteLine(perk.ToString());
            }            
            else
            {
                MainFunctions.Exit_Game();
            }
            newCharacter.gender = "feminine";
            Console.WriteLine("{0} is preparing to become a parent. Their first target is to watch for their not yet born children. Or... is it?\n", newCharacter.name);
            return newCharacter;

        }
    }
}