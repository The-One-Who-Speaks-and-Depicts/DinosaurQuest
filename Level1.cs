using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialGame
{
    class Level1
    {

        public static void Level1_Entrance(YourCreature character)
        {
            RecordedSaves.Save_Game(character, 2);
            Tile nest = new Tile("noDir", "autumn", "nest", character);
            Program.Exit_Game();
        }

    }
}
