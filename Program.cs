using System;
using System.IO;
using DinosaurAction.GameFunctions;

namespace DinosaurAction
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
