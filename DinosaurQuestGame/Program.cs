using System;
using System.IO;
using DinosaurQuest.GameFunctions;

namespace DinosaurQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            string currDir = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(Path.Combine(currDir, "Tech"));
            Directory.CreateDirectory(Path.Combine(currDir, "Saves"));
            MainFunctions.MainMenu();
        }
    }
}
