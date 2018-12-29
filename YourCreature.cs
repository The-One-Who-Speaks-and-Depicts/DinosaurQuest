using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Int32;

namespace TrialGame
{
    public class YourCreature
    {
        public string name;
        public int health;
        public int level;
        public int exp;
        public int sex;
        public List<int> Stats = new List<int>();


        public string[] characterStats = new string[] { "sprint", "stayer", "intelligence", "progressivity", "perception", "luck" };

        public void DoStats()
        {
            Stats.Add(1);
            Stats.Add(1);
            Stats.Add(1);
            Stats.Add(1);
            Stats.Add(1);
            Stats.Add(1);
        }

        public void ResetStats()
        {
            Stats.Clear();
        }


        public string PrintSex()
        {
            if (this.sex == 0) return "feminine";
            else return "masculine";
        }

        public YourCreature()
        {

        }

        public YourCreature(String givenName)
        {
            name = givenName;
        }

        public void SetDefault(int level, int health, int exp)
        {
            this.level = level;
            this.health = health;
            this.exp = exp;
        }

        public static void Spawn()
        {
            Console.WriteLine("Here there will be tigers");
        }

    }
}
