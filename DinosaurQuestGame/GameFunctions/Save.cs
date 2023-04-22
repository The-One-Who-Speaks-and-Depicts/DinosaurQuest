using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using DinosaurQuest.Creatures;
using DinosaurQuest.Stages;

namespace DinosaurQuest.GameFunctions
{

    class Save
    {

        public static int Save_File_Check(string[] array_of_file_names)
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
            SaveRecording.WriteLine(JsonConvert.SerializeObject(new Save(stage, currCharacter), new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto }));
            SaveRecording.Close();
        }

        public static void Auto_Load_Game()
        {
            try
            {
                string FolderName = Path.Combine(Directory.GetCurrentDirectory(), "Saves");
                List<string> filesnames = Directory.GetFiles(FolderName).ToList();
                var start = new DateTime(1970, 1, 1, 0, 0, 0);
                var fileToLoad = "";
                foreach (var filename in filesnames)
                {
                    if (File.GetCreationTime(filename) > start)
                    {
                        fileToLoad = filename;
                        start = File.GetCreationTime(filename);
                    }
                }
                if (String.IsNullOrEmpty(fileToLoad)) throw new Exception();
                StreamReader saveGetting = new StreamReader(fileToLoad);
                using (saveGetting)
                {
                    var loadedSave = JsonConvert.DeserializeObject<Save>(saveGetting.ReadToEnd(), new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
                    switch (loadedSave.savedStage)
                    {
                        case 0:
                        case 1:
                            new Tutorial(loadedSave.savedCharacter);
                            break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("There are no saves in the directory");
                MainFunctions.MainMenu();
            }
        }

        public static void Load_Game()
        {

            List<string> filesnames = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Saves")).ToList();
            if (filesnames.Count > 0)
            {
                foreach (string name in filesnames)
                {
                    StreamReader SaveGetting = new StreamReader(name);
                    using (SaveGetting)
                    {
                        var shortFileName = Regex.Match(name, @"[0-9]{1,}.dns");
                        shortFileName = Regex.Match(name, @"[0-9]{1,}");
                        var loadedSave = JsonConvert.DeserializeObject<Save>(SaveGetting.ReadToEnd(), new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
                        Console.WriteLine("Number: {0}", shortFileName);
                        Console.WriteLine("Stage: {0}", loadedSave.savedStage);
                        Console.WriteLine("Character: {0}", loadedSave.savedCharacter.name);
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("Write the number of save you want to load");
                string ReadableSave = Console.ReadLine();
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Saves", ReadableSave + ".dns")))
                {
                    StreamReader SaveGetting = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Saves", ReadableSave + ".dns"));
                    using (SaveGetting)
                    {
                        var loadedSave = JsonConvert.DeserializeObject<Save>(SaveGetting.ReadToEnd(), new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
                        switch (loadedSave.savedStage)
                        {
                            case 0:
                            case 1:
                                new Tutorial(loadedSave.savedCharacter);
                                break;
                        }
                    }

                }
                else
                {
                    while (!(File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Saves", ReadableSave + ".dns"))))
                    {
                        Console.WriteLine("Wrong file name. Insert once more");
                        ReadableSave = Console.ReadLine();
                    }
                    StreamReader SaveGetting = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Saves", ReadableSave + ".dns"));
                    using (SaveGetting)
                    {
                        var loadedSave = JsonConvert.DeserializeObject<Save>(SaveGetting.ReadToEnd(), new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
                        switch (loadedSave.savedStage)
                        {
                            case 0:
                            case 1:
                                new Tutorial(loadedSave.savedCharacter);
                                break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no saves in the directory");
                MainFunctions.MainMenu();
            }
        }
        [JsonProperty]
        int savedStage { get; set; }
        [JsonProperty]
        Character savedCharacter { get; set; }

        [JsonConstructor]
        public Save(int _savedStage, Character _savedCharacter)
        {
            savedStage = _savedStage;
            savedCharacter = _savedCharacter;
        }

    }
}
