using System;
using System.Collections.Generic;
using System.IO;



namespace TrialGame
{
    class Program
    {
        public static List<YourCreature.EnemyCreature> CharacterMenu(YourCreature character, Tile thisTile)
        {
            int click = -1;
            do
            {                
                Console.WriteLine("Press 8 to quit main menu, press 9 to get stats, press 0 to exiWt");
                click = ServiceFunctions.ChoosingRightKey();
                if (click == 0) GameFunctions.Exit_Game();
                else if (click == 9) character.PrintCharacterStats();
                else if (click == 8)
                {
                    return thisTile.m_creaturesList;
                }
            }
            while (click != 1);
            return thisTile.m_creaturesList;
        }
        
        

        

        

        
        static void Main(string[] args)
        {
            string currDir = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(Path.Combine(currDir, "Tech"));
            Directory.CreateDirectory(Path.Combine(currDir, "Saves"));
            GameFunctions.MainMenu();
        }


        
    }
}