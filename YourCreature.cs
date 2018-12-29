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

          
        abstract public class EnemyCreature : YourCreature
        {
           public static void printStats (EnemyCreature a)
            {
                Console.WriteLine("You can see {0}. {0} has  {1} health,  {2} sprint, {3} stayer, {4} intelligence, {5} progressivity, {6} perception, {7} luck", a.name, a.health, a.Stats[0], a.Stats[1], a.Stats[2], a.Stats[3], a.Stats[4], a.Stats[5]);
            }
            public static EnemyCreature Spawn()
            {
                Random creatureSummoned = new Random();
                int returnableCreature = creatureSummoned.Next(1, 2);
                switch (returnableCreature)
                {
                    case 1:
                        Adelobasileus m_adelobasileus = new Adelobasileus();
                        return m_adelobasileus;
                    case 2:
                    default:
                        Trytilodontis m_trytilodontis = new Trytilodontis();
                        return m_trytilodontis;
                }
                
            }

            public static EnemyCreature TutorialSpawn(int returnableCreature)
            {
                
                switch (returnableCreature)
                {
                    case 1:
                        Adelobasileus m_adelobasileus = new Adelobasileus();
                        return m_adelobasileus;
                    case 2:
                    default:
                        Trytilodontis m_trytilodontis = new Trytilodontis();
                        return m_trytilodontis;
                }

            }

            class Trytilodontis : EnemyCreature
            {
                public Trytilodontis ()
                {
                    this.name = "Trytilodontis";
                    this.health = 10;
                    this.DoStats();
                    this.Stats[0] += 0;
                    this.Stats[1] += 5;
                    this.Stats[2] += 6;
                    this.Stats[3] += 4;
                    this.Stats[4] += 2;
                    this.Stats[5] += 0;
                    printStats(this);
                }


            }

            class Adelobasileus : EnemyCreature
            {
                public Adelobasileus ()
                {
                    this.name = "Adelobasileus";
                    this.health = 10;
                    this.DoStats();
                    this.Stats[0] += 0;
                    this.Stats[1] += 5;
                    this.Stats[2] += 6;
                    this.Stats[3] += 6;
                    this.Stats[4] += 3;
                    this.Stats[5] += 2;
                    printStats(this);
                }
            }
        }

    }
}
