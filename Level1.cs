<<<<<<< HEAD
﻿
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

>>>>>>> 6952d5411cb7971f0656465aad19ef0474b87e4b
namespace TrialGame
{
    class Level1
    {

        public static void Level1_Entrance(YourCreature character)
        {
<<<<<<< HEAD
            //character.HealthChange += Tutorial.OnHealthChange;
            //character.HealthChange += Tutorial.OnCriticalHealth;
=======
            character.HealthChange += Tutorial.OnHealthChange;
            character.HealthChange += Tutorial.OnCriticalHealth;
>>>>>>> 6952d5411cb7971f0656465aad19ef0474b87e4b
            RecordedSaves.Save_Game(character, 2);
            Tile nest = new Tile("noDir", "autumn", "nest", character);
            Program.Exit_Game();
        }

    }
}
