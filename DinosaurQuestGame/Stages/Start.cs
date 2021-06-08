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
            newCharacter.gender = "feminine";
            Console.WriteLine($"{newCharacter.name} is preparing to become a parent. Their first target is to watch for their not yet born children. Or... is it?\n");
            return newCharacter;

        }
    }
}