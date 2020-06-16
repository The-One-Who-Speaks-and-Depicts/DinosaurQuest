using System.IO;



namespace TrialGame
{
    class Program
    {         
               
        static void Main(string[] args)
        {
            string currDir = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(Path.Combine(currDir, "Tech"));
            Directory.CreateDirectory(Path.Combine(currDir, "Saves"));
            GameFunctions.MainMenu();
        }


        
    }
}