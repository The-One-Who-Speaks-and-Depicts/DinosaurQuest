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
        public static void Tutorial_Entrance ()
        {
            Console.WriteLine("You are now an egg, so, everything you can do is exist, while other creatures decide, what your fate is going to be like. However, some divine bodyless sentient creature that governs you, is able to help you by telling your mother what is going to be the best for you. And she will help this divine creature as well, by showing how this cruel world works. It is not too long before your birth, however, for your mother these are going to be the truly hardest hours of her parenthood. And now they are to begin. Let the desperate Diviner brace themselves, Early Jurassic of Antarctica begins!");
            YourCreature mother = new YourCreature();
            mother.name = "Mother Cryolophosaurus";
            mother.sex = 1;
            mother.SetDefault(35, 450, 350001);
            mother.DoStats();
            mother.Stats[0] += 7;
            mother.Stats[1] += 4;
            mother.Stats[2] += 5;
            mother.Stats[3] += 8;
            mother.Stats[4] += 4;
            mother.Stats[5] += 3;
            Console.WriteLine("{0} has {1} level, {2} health, {3} experience, {4} sprint, {5} stayer, {6} intelligence, {7} progressivity, {8} perception, {9} luck", mother.name, mother.level, mother.health, mother.exp, mother.Stats[0], mother.Stats[1], mother.Stats[2], mother.Stats[3], mother.Stats[4], mother.Stats[5]);
            Console.WriteLine("Mother is starving and thirsty. She is desperate of satisfying her needs, because she was warming her unborn children for weeks, or even months now. But she still needs to guard them. That is going to be a very hard choice for her. Does she want to go away for hunting or is she going to stay here (1) and protect her children until her last dying breath(2)");
            int decision = Program.ChoosingRightKey();
            while ((decision < 1) || (decision > 2)) 
                {
                Console.WriteLine("Please press appropriate key");
                decision = Program.ChoosingRightKey();
            }
            if (decision == 1)
            {
                Console.WriteLine("Putting mother's needs over child's ones is clever, but, at this point of history, not so progressive step. Mother is going into the woods.");
                mother.Stats[2]++;
                Tile next = new Tile("southEast", "Fall", "Mountainside");
                do
                {
                    Console.WriteLine("To do something, press any key, to see main menu, press 1");
                    decision = Program.ChoosingRightKey();
                    if (decision == 1) Program.MenuCall(mother);
                }
                while (decision != 2);
            }
            else if (decision == 2)
            {
                Console.WriteLine("Putting child's needs over mother's ones for this creature is a true step forward, however, it is not so clever thing to do in that particular situation. Mother is staying near her nest.");
                mother.Stats[3]++;
                Tile next = new Tile("noDir", "Fall", "Cloud_forest");
                do
                {
                    Console.WriteLine("To do something, press any key, to see main menu, press 1");
                    decision = Program.ChoosingRightKey();
                    if (decision == 1) Program.MenuCall(mother);
                }
                while (decision != 2);
            }
            
            Program.Exit_Game();
        }
    }
}
