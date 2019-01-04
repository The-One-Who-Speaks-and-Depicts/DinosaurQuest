using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Int32;

namespace TrialGame
{
    public abstract class Creature
    {
        public string name;
        public int m_level;
        public int m_health;
        public int m_sprint;
        public int m_stayer;
        public int m_intelligence;
        public int m_progressivity;
        public int m_perception;
        public int m_luck;

        public virtual void DoStats()
        {
            this.m_sprint = 1;
            this.m_stayer = 1;
            this.m_intelligence = 1;
            this.m_progressivity = 1;
            this.m_perception = 1;
            this.m_luck = 1;
        }

       
    }
    public class YourCreature : Creature
    {
        
        public double exp;
        public int sex;
       

        public int level 
        {
            get { return m_level; }
            set
            {
                int t_level = level;
                if (level != value)
                {
                    m_level = value;
                    StatChange?.Invoke(this, EventArgs.Empty);
                    Console.WriteLine("{0} is how level changed", level - t_level);
                }
            }
        }

        public int health
        {
            get { return m_health; }
            set
            {
                int t_health = health;
                if (health != value)
                {
                    m_health = value;
                    StatChange?.Invoke(this, EventArgs.Empty);
                    Console.WriteLine("{0} is how health changed", health - t_health);
                    
                }
            }
        }

        public int sprint
        {
            get { return m_sprint; }
            set
            {
                int t_sprint = sprint;
                if (sprint != value)
                {
                    m_sprint = value;
                    StatChange?.Invoke(this, EventArgs.Empty);
                    Console.WriteLine("{0} is how sprint changed", sprint - t_sprint);

                }
            }
        }

        public int stayer
        {
            get { return m_stayer; }
            set
            {
                int t_stayer = stayer;
                if (stayer != value)
                {
                    m_stayer = value;
                    StatChange?.Invoke(this, EventArgs.Empty);
                    Console.WriteLine("{0} is how stayer changed", stayer - t_stayer);

                }
            }
        }

        public int intelligence
        {
            get { return m_intelligence; }
            set
            {
                int t_intelligence = intelligence;
                if (intelligence != value)
                {
                    m_intelligence = value;
                    StatChange?.Invoke(this, EventArgs.Empty);
                    Console.WriteLine("{0} is how intelligence changed", intelligence - t_intelligence);

                }
            }
        }

        public int progressivity
        {
            get { return m_progressivity; }
            set
            {
                int t_progressivity = progressivity;
                if (progressivity != value)
                {
                    m_progressivity = value;
                    StatChange?.Invoke(this, EventArgs.Empty);
                    Console.WriteLine("{0} is how progressivity changed", progressivity - t_progressivity);

                }
            }
        }

        public int perception
        {
            get { return m_perception; }
            set
            {
                int t_perception = perception;
                if (perception != value)
                {
                    m_perception = value;
                    StatChange?.Invoke(this, EventArgs.Empty);
                    Console.WriteLine("{0} is how perception changed", perception - t_perception);

                }
            }
        }


        public int luck
        {
            get { return m_luck; }
            set
            {
                int t_luck = luck;
                if (luck != value)
                {
                    m_luck = value;
                    StatChange?.Invoke(this, EventArgs.Empty);
                    Console.WriteLine("{0} is how luck changed", luck - t_luck);

                }
            }
        }
        public event EventHandler StatChange;
    
        

        public string[] characterStats = new string[] { "sprint", "stayer", "intelligence", "progressivity", "perception", "luck" };

        public override void DoStats()
        {
            this.sprint = 1;
            this.stayer = 1;
            this.intelligence = 1;
            this.progressivity = 1;
            this.perception = 1;
            this.luck = 1;        
        }

        public void ResetStats()
        {
            this.sprint = 1;
            this.stayer = 1;
            this.intelligence = 1;
            this.progressivity = 1;
            this.perception = luck;
            this.luck = 1;
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
            this.name = givenName;
        }

        public void SetDefault(int level, int health, int exp)
        {
            this.level = level;
            this.health = health;
            this.exp = exp;
        }

        public void PrintCharacterStats()
        {
            Console.WriteLine("{0} has {1} level, {2} health, {3} experience, {4} sprint, {5} stayer, {6} intelligence, {7} progressivity, {8} perception, {9} luck", this.name, this.level, this.health, this.exp, sprint, stayer, intelligence, progressivity, perception, luck);
        }
          
        abstract public class EnemyCreature : Creature
        {
            public static void Attack (YourCreature a, EnemyCreature b)
            {
                Console.WriteLine("{0} attacks {1}", a.name, b.name);
                double attack_coefficient = (a.sprint * a.progressivity) / 2;
                double defence_coefficient = (a.stayer * a.intelligence) / 2;
                double result_of_attack = attack_coefficient / defence_coefficient;
                
                if (result_of_attack < 1)
                {
                    Console.WriteLine("Attack failed");
                    double m_receivedexp = 0;
                    m_receivedexp = (b.m_health * 0.25);
                    a.exp += m_receivedexp;
                    Console.WriteLine("You gained {0} experience", m_receivedexp);
                }
                else if (result_of_attack > 1)
                {
                    
                    while ((a.health/10 <= b.m_health) || (b.m_health/10 >= a.health))
                    {
                        
                        if (a.level > b.m_level)
                        {
                            b.m_health -= a.stayer * (a.level/b.m_level);
                            a.health -= b.m_sprint;
                        }
                        else
                        {
                            b.m_health -= a.sprint * a.intelligence;
                            a.health -= b.m_sprint * b.m_intelligence;
                        }                                                
                    }
                    
                    if (a.health/10 > b.m_health) { 
                    Console.WriteLine("Attack is successful");
                    double m_receivedexp = 0;
                    m_receivedexp = (b.m_health * 2);
                    a.exp += m_receivedexp;                        
                    Console.WriteLine("You gained {0} experience", m_receivedexp);
                    Scavenge(a, b);
                    }
                    else if (b.m_health/10 > a.health)
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
                            m_receivedexp = (b.m_health * 0.25);
                            a.exp += m_receivedexp;
                            Console.WriteLine("You gained {0} experience", m_receivedexp);
                            break;
                        case 1:
                            while ((a.health / 10 <= b.m_health) || (b.m_health / 10 <= a.health))
                            {
                                if (a.level > b.m_level)
                                {
                                    b.m_health -= a.stayer * (a.level / b.m_level);
                                    a.health -= b.m_sprint;
                                }
                                else
                                {
                                    b.m_health -= a.sprint * a.intelligence;
                                    a.health -= b.m_sprint * b.m_intelligence;
                                }
                            }
                            if (a.health / 10 > b.m_health)
                            {
                                Console.WriteLine("Attack is successful");
                                m_receivedexp = (b.m_health * 2);
                                a.exp += m_receivedexp;
                                Console.WriteLine("You gained {0} experience", m_receivedexp);
                                Scavenge(a, b);
                            }
                            else if (b.m_health / 10 > a.health)
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
                if (a.luck > b.m_perception)
                {
                    Console.WriteLine("Stealth attack is successful");
                    double m_receivedexp = (b.m_health * 1.5);
                    a.exp += m_receivedexp;
                    Console.WriteLine("You gained {0} experience", m_receivedexp);
                    Scavenge(a, b);
                }
                else if (a.luck == b.m_perception)
                {
                    Console.WriteLine("You have been spotted!");
                    Attack(a, b);
                }
                else if (a.luck < b.m_perception)
                {
                    if (a.level > b.m_level)
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
                Console.WriteLine("You can see {0}. {0} has  {1} health,  {2} sprint, {3} stayer, {4} intelligence, {5} progressivity, {6} perception, {7} luck", a.name, a.m_health, a.m_sprint, a.m_stayer, a.m_intelligence, a.m_progressivity, a.m_perception, a.m_luck);
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
                        Trytilodontis m_trytilodontis = new Trytilodontis();
                        return m_trytilodontis;
                    default:
                        Console.WriteLine("There is nobody here");
                        return null;
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
                        Trytilodontis m_trytilodontis = new Trytilodontis();
                        return m_trytilodontis;
                    default:
                        Console.WriteLine("There is nobody here");
                        return null;
                }                

            }

            public static void Scavenge(YourCreature a, EnemyCreature b)
            {
                Console.WriteLine("You restore your life strength, eating the corpse of {0}", b.name);
                int full_health = 100 + 10 * a.level;
                int scavengeable_meat = b.m_health/4;
                if (a.health < full_health)
                {
                    if (scavengeable_meat > (full_health - scavengeable_meat))
                    {
                        a.health = full_health;
                    }
                    else a.health += scavengeable_meat;
                }
            }

            class Trytilodontis : EnemyCreature
            {
                public Trytilodontis ()
                {
                    this.name = "Trytilodontis";
                    this.m_health = 10;
                    this.m_level = 1;
                    this.DoStats();
                    this.m_sprint += 0;
                    this.m_stayer += 5;
                    this.m_intelligence += 6;
                    this.m_progressivity += 4;
                    this.m_perception += 2;
                    this.m_luck+= 0;
                    printStats(this);
                }
                
                


            }

            class Adelobasileus : EnemyCreature
            {
                public Adelobasileus ()
                {
                    this.name = "Adelobasileus";
                    this.m_health = 10;
                    this.m_level = 1;
                    this.DoStats();
                    this.m_sprint += 0;
                    this.m_stayer += 5;
                    this.m_intelligence += 6;
                    this.m_progressivity += 6;
                    this.m_perception += 3;
                    this.m_luck += 2;
                    printStats(this);
                }
            }
        }

    }
}
