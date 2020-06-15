using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace TrialGame
{
     
    class Save {

        public static int Save_File_Check(string [] array_of_file_names)
        {
            int saves_predicted_amount = array_of_file_names.Length;
            int saves_real_amount = saves_predicted_amount;
            string[] checking_massive = new string[saves_real_amount];
            for (int save_number = 1; save_number <= saves_real_amount; save_number++)
            {
                int saves_number_for_cycle = save_number;
                checking_massive[--saves_number_for_cycle] = save_number.ToString();
            }
            if (array_of_file_names == checking_massive)
            {
                return Convert.ToInt32(array_of_file_names[++saves_predicted_amount]);
            }
            else
            {            
            foreach (string s in array_of_file_names)
            {
                foreach (string s1 in checking_massive)
                {
                    if (s != s1)
                    {
                            return Convert.ToInt32(s1);
                    }
                    else
                    {
                            string returnable_string = s;                            
                    }
                } 

            }
                return ++saves_predicted_amount;
            }
        }

        public static void Save_Game(Character currCharacter, int stage)
        {
            List<string> filenames = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Saves")).ToList();
            var shortFileNames = new string[filenames.Count];
            foreach (var filename in filenames)
            {
                var shortFileName = Regex.Match(filename, @"[0-9]{1,}.dns");
                shortFileNames.Append(shortFileName.Value);
            }
            Array.Sort(shortFileNames);
            int LastSaveFileNumber = Save_File_Check(shortFileNames);
            string NewSaveName = Path.Combine(Directory.GetCurrentDirectory(), "Saves", LastSaveFileNumber.ToString() + ".dns");
            while (File.Exists(NewSaveName))
            {
                LastSaveFileNumber++;
                NewSaveName = Path.Combine(Directory.GetCurrentDirectory(), "Saves", LastSaveFileNumber.ToString() + ".dns"); 
            }
            StreamWriter SaveRecording = new StreamWriter(NewSaveName);
            SaveRecording.WriteLine(stage.ToString());
            SaveRecording.WriteLine(currCharacter.Jsonize());
            SaveRecording.Close();
        }

        public static void Auto_Load_Game()
        {
            try
            {
            string FolderName = @"c:\DinosaurGame\";
            List<string> filesnames = Directory.GetFiles(FolderName).ToList<string>();            
            string[] filesnames2 = filesnames.ToArray();
            for (int fileCounter = 0; fileCounter < filesnames2.Length; fileCounter++)
            {
                filesnames2[fileCounter].Remove(0, 16);

            }
            Array.Sort(filesnames2);
            int LastSaveFileNumber = filesnames2.Length - 1;
            string NewSaveName = FolderName + LastSaveFileNumber + ".dns";
            StreamReader SaveGetting = new StreamReader(NewSaveName);
            YourCreature gettableCharacter = new YourCreature();
            int stage = 0;
            stage = Convert.ToInt32(SaveGetting.ReadLine());
            gettableCharacter.name = SaveGetting.ReadLine();
            gettableCharacter.sex = Convert.ToInt32(SaveGetting.ReadLine());
            gettableCharacter.m_level = Convert.ToInt32(SaveGetting.ReadLine());
            gettableCharacter.health = Convert.ToInt32(SaveGetting.ReadLine());
            gettableCharacter.exp = Convert.ToInt32(SaveGetting.ReadLine());
            gettableCharacter.sprint = Convert.ToInt32(SaveGetting.ReadLine());
            gettableCharacter.stayer = Convert.ToInt32(SaveGetting.ReadLine());
            gettableCharacter.intelligence = Convert.ToInt32(SaveGetting.ReadLine());
            gettableCharacter.progressivity = Convert.ToInt32(SaveGetting.ReadLine());
            gettableCharacter.perception = Convert.ToInt32(SaveGetting.ReadLine());
            gettableCharacter.luck = Convert.ToInt32(SaveGetting.ReadLine());
            SaveGetting.Close();
            switch(stage)
            {
                case 0:
                case 1:
                    Tutorial.Tutorial_Entrance(gettableCharacter);
                    break;
                case 2:
                    Level1.Level1_Entrance(gettableCharacter);
                    break;

            }
            }
            catch
            {
                Console.WriteLine("There are no saves in the directory");
                GameFunctions.MainMenu();
            }
        }
        
        public static void Load_Game()
        {
            
            string FolderName = @"c:\DinosaurGame\";
            List<string> filesnames = Directory.GetFiles(FolderName).ToList<string>();
            string[] filesnames2 = filesnames.ToArray();
            for (int fileCounter = 0; fileCounter < filesnames2.Length; fileCounter++)
            {
                filesnames2[fileCounter].Remove(0, 16);

            }
            Array.Sort(filesnames2);
            if (filesnames2.Length != 0)
            {
            foreach (string s in filesnames2) {             
            string NewSaveName = s;
            StreamReader SaveGetting = new StreamReader(NewSaveName);              
            Console.Write("{1}, stage = {0},", SaveGetting.ReadLine(), NewSaveName);
            Console.Write("name = {0},", SaveGetting.ReadLine());
            Console.Write("sex = {0},", SaveGetting.ReadLine());
            Console.Write("m_level = {0},", SaveGetting.ReadLine());
            Console.Write("health = {0},", SaveGetting.ReadLine());
            Console.Write("exp = {0},", SaveGetting.ReadLine());
            Console.Write("sprint = {0},", SaveGetting.ReadLine());
            Console.Write("stayer = {0},", SaveGetting.ReadLine());
            Console.Write("intelligence = {0},", SaveGetting.ReadLine());
            Console.Write("progressivity = {0},", SaveGetting.ReadLine());
            Console.Write("perception = {0},", SaveGetting.ReadLine());
            Console.WriteLine("luck = {0}.", SaveGetting.ReadLine());                
            SaveGetting.Close();             
            }
            Console.WriteLine("Write the number of save you want to load");
            string ReadableSave = Console.ReadLine();
            if (File.Exists(FolderName + ReadableSave + ".dns"))
            {
                StreamReader SaveGetting = new StreamReader(FolderName + ReadableSave + ".dns");
                YourCreature gettableCharacter = new YourCreature();
                int stage = 0;
                stage = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.name = SaveGetting.ReadLine();
                gettableCharacter.sex = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.m_level = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.health = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.exp = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.sprint = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.stayer = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.intelligence = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.progressivity = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.perception = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.luck = Convert.ToInt32(SaveGetting.ReadLine());
                SaveGetting.Close();
                switch (stage)
                {
                    case 0:
                    case 1:
                        Tutorial.Tutorial_Entrance(gettableCharacter);
                        break;
                    case 2:
                        Level1.Level1_Entrance(gettableCharacter);
                        break;

                }
            }
            else
            {
                while (!(File.Exists(FolderName + ReadableSave + ".dns"))) { 
                Console.WriteLine("Wrong file name");
                ReadableSave = Console.ReadLine();
                }
                StreamReader SaveGetting = new StreamReader(FolderName + ReadableSave + ".dns");
                YourCreature gettableCharacter = new YourCreature();
                int stage = 0;
                stage = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.name = SaveGetting.ReadLine();
                gettableCharacter.sex = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.m_level = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.health = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.exp = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.sprint = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.stayer = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.intelligence = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.progressivity = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.perception = Convert.ToInt32(SaveGetting.ReadLine());
                gettableCharacter.luck = Convert.ToInt32(SaveGetting.ReadLine());
                SaveGetting.Close();
                switch (stage)
                {
                    case 0:
                    case 1:
                        Tutorial.Tutorial_Entrance(gettableCharacter);
                        break;
                    case 2:
                        Level1.Level1_Entrance(gettableCharacter);
                        break;

                }
            }
            Console.ReadKey();
            }
            else
            {
                Console.WriteLine("There are no saves in the directory");
                GameFunctions.MainMenu();
            } 
            }



    }
}
