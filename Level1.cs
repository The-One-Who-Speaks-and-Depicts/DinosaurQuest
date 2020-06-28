
﻿using System;

namespace TrialGame
{
    class Level1 : Level
    {
        
        
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
            GameFunctions.Exit_Game();
        }
    }
}
