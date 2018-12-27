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
            Program.YourCreature mother = new Program.YourCreature();
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
            Program.Exit_Game();
        }
    }
}
