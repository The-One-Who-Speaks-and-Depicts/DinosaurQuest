using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrialGame
{
     
    abstract class RecordedSaves
    {

        public static int Save_File_Check(string [] array_of_file_names)
        {
            int saves_predicted_amount = array_of_file_names.Length;
            int saves_real_amount = saves_predicted_amount;
            String[] checking_massive = new string[saves_real_amount];
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

        public static void Save_Game(YourCreature a, int stage)
        {
            DirectoryInfo SaveGameDirectory = Directory.CreateDirectory(@"c:\DinosaurGame\");
            string FolderName = @"c:\DinosaurGame\";
            List<string> filesnames = Directory.GetFiles(FolderName).ToList<string>();
            string[] filesnames2 = filesnames.ToArray();
            for (int fileCounter = 0; fileCounter < filesnames2.Length; fileCounter++)
            {
                filesnames2[fileCounter].Remove(0, 16);

            }
            Array.Sort(filesnames2);            
            int LastSaveFileNumber = Save_File_Check(filesnames2);            
            string NewSaveName = FolderName + LastSaveFileNumber + ".dns";
            while (File.Exists(NewSaveName))
            {
                LastSaveFileNumber++;
                NewSaveName = FolderName + LastSaveFileNumber + ".dns";
            }
            StreamWriter SaveRecording = new StreamWriter(NewSaveName);
            SaveRecording.WriteLine(stage.ToString());
            SaveRecording.WriteLine(a.name);
            SaveRecording.WriteLine(a.sex);
            SaveRecording.WriteLine(a.level.ToString());
            SaveRecording.WriteLine(a.exp.ToString());
            SaveRecording.WriteLine(a.health.ToString());
            SaveRecording.WriteLine(a.sprint.ToString());
            SaveRecording.WriteLine(a.stayer.ToString());
            SaveRecording.WriteLine(a.intelligence.ToString());
            SaveRecording.WriteLine(a.progressivity.ToString());
            SaveRecording.WriteLine(a.perception.ToString());
            SaveRecording.WriteLine(a.luck.ToString());
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
                Program.Start();
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
                Program.Start();
            } 
            }



    }
}
