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
        public double exp;
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

        public void PrintCharacterStats()
        {
            Console.WriteLine("{0} has {1} level, {2} health, {3} experience, {4} sprint, {5} stayer, {6} intelligence, {7} progressivity, {8} perception, {9} luck", this.name, this.level, this.health, this.exp, this.Stats[0], this.Stats[1], this.Stats[2], this.Stats[3], this.Stats[4], this.Stats[5]);
        }
          
        abstract public class EnemyCreature : YourCreature
        {
            public static void Attack (YourCreature a, EnemyCreature b)
            {
                Console.WriteLine("{0} attacks {1}", a.name, b.name);
                double attack_coefficient = (a.Stats[0] * a.Stats[3]) / 2;
                double defence_coefficient = (b.Stats[1] * a.Stats[2]) / 2;
                double result_of_attack = attack_coefficient / defence_coefficient;
                
                if (result_of_attack < 1)
                {
                    Console.WriteLine("Attack failed");
                    double m_receivedexp = 0;
                    m_receivedexp = (b.health * 0.25);
                    a.exp += m_receivedexp;
                    Console.WriteLine("You gained {0} experience", m_receivedexp);
                }
                else if (result_of_attack > 1)
                {
                    
                    while ((a.health/10 <= b.health) || (b.health/10 >= a.health))
                    {
                        
                        if (a.level > b.level)
                        {
                            b.health -= a.Stats[1] * (a.level/b.level);
                            a.health -= b.Stats[0];
                        }
                        else
                        {
                            b.health -= a.Stats[0] * a.Stats[2];
                            a.health -= b.Stats[0] * b.Stats[2];
                        }                                                
                    }
                    
                    if (a.health/10 > b.health) { 
                    Console.WriteLine("Attack is successful");
                    double m_receivedexp = 0;
                    m_receivedexp = (b.health * 2);
                    a.exp += m_receivedexp;                        
                    Console.WriteLine("You gained {0} experience", m_receivedexp);
                    }
                    else if (b.health/10 > a.health)
                    {
                        Console.WriteLine("You died");
                        Program.Exit_Game();
                    }
                }
                else if (result_of_attack == 1)
                {
                    Random attack_finale = new Random();
                    int m_attack_finale = attack_finale.Next(0, 1);
                    double m_receivedexp = 0;
                    switch (m_attack_finale)
                    {
                        case 0:
                            Console.WriteLine("Attack failed");
                            m_receivedexp = (b.health * 0.25);
                            a.exp += m_receivedexp;
                            Console.WriteLine("You gained {0} experience", m_receivedexp);
                            break;
                        case 1:
                            while ((a.health / 10 <= b.health) || (b.health / 10 <= a.health))
                            {
                                if (a.level > b.level)
                                {
                                    b.health -= a.Stats[1] * (a.level / b.level);
                                    a.health -= b.Stats[0];
                                }
                                else
                                {
                                    b.health -= a.Stats[0] * a.Stats[2];
                                    a.health -= b.Stats[0] * b.Stats[2];
                                }
                            }
                            if (a.health / 10 > b.health)
                            {
                                Console.WriteLine("Attack is successful");
                                m_receivedexp = (b.health * 2);
                                a.exp += m_receivedexp;
                                Console.WriteLine("You gained {0} experience", m_receivedexp);
                            }
                            else if (b.health / 10 > a.health)
                            {
                                Console.WriteLine("You died");
                                Program.Exit_Game();
                            }
                            break;
                    }
                }

            }

            public static void StealthAttack (YourCreature a, EnemyCreature b)
            {
                if (a.Stats[5] > b.Stats[4])
                {
                    Console.WriteLine("Stealth attack is successful");
                    double m_receivedexp = (b.health * 1.5);
                    a.exp += m_receivedexp;
                    Console.WriteLine("You gained {0} experience", m_receivedexp);
                }
                else if (a.Stats[5] == b.Stats[4])
                {
                    Console.WriteLine("You have been spotted!");
                    Attack(a, b);
                }
                else if (a.Stats[5] < b.Stats[4])
                {
                    if (a.level > b.level)
                    {
                        Console.WriteLine("{0} sneaks away", b.name);
                    }
                    else
                    {
                        Console.WriteLine("{0} is ready to fight!", b.name);
                    }
                }
            }

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
                    this.level = 1;
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
                    this.level = 1;
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
