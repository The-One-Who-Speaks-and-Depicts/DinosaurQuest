using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialGame
{
    class MainMenu
    {
        public MainMenu()
        {
            Console.WriteLine("Welcome to the Predators of the Antarctica: the Game! To start a new game, press 1, to continue, press 2, to load game, press 3, to exit game, press 0");
            int decision = ServiceFunctions.ChoosingRightKey();
            switch (decision)
            {
                case 1:
                    Character newCharacter = new Character();
                    CharacterCreation new_game = new CharacterCreation();
                    break;
                case 2:
                    RecordedSaves.Auto_Load_Game();
                    break;
                case 3:
                    RecordedSaves.Load_Game();
                    break;
                default:
                    Program.Exit_Game();
                    break;
            }
        }
    }
}
