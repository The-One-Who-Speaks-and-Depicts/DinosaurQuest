
﻿using System;

namespace TrialGame
{
    class Level1 : Level
    {
        new enum Season
        {
            Winter = 0,
            Fall
        }
        
        public static void Level1_Entrance(Character character)
        {
            //character.HealthChange += Tutorial.OnHealthChange;
            //character.HealthChange += Tutorial.OnCriticalHealth;
            
            //RecordedSaves.Save_Game(character, 2);
            //Tile nest = new Tile("noDir", "autumn", "nest", character);
            GameFunctions.Exit_Game();
        }
        
        public Level1 (Character character)
        {
            Console.WriteLine(Season.Winter);
            GameFunctions.Exit_Game();
        }
    }
}
