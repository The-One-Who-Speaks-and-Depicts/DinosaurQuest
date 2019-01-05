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
            int LastSaveFileNumber = filesnames2.Length;
            LastSaveFileNumber++;
            string NewSaveName = FolderName + LastSaveFileNumber + ".dns";
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

        public static void Load_Game()
        {

        }
        
    }
}
