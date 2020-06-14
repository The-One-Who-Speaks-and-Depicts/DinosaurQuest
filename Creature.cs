using System;
using System.Threading;
using System.IO;


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
        public int sex;

        public int full_health
        {
            get { return 100 + m_level * 10; }
            set
            {
                full_health = (100 + m_level * 10);
                if (m_health < (full_health / 10))
                    CriticalHealth?.Invoke(this, EventArgs.Empty);

            }
        }
        public event EventHandler CriticalHealth;
        public string PrintSex()
        {
            if (this.sex == 0) return "feminine";
            else return "masculine";
        }

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




        // уровень и его изменение


        public int level
        {
            get { return m_level; }
            set
            {
                /*int t_level = level;
                if (level != value)
                {
                    m_level = value;
                    LevelDifferenceInput(level - t_level, "level");
                    LevelChange?.Invoke(this, EventArgs.Empty);                    
                }*/
                m_level = value;
            }


        }
        /*
        public static void LevelDifferenceInput(int statDifference, string stat)
        {
            try
            {
                string FileOfInput = @"C:\DinosaurGame\Tech\herelieslevel.txt";
                if (File.Exists(FileOfInput)) File.Delete(FileOfInput);
                StreamWriter ChangeableStat = new StreamWriter(FileOfInput);
                ChangeableStat.WriteLine(statDifference.ToString());
                ChangeableStat.WriteLine(" is how changed {0}", stat);
                ChangeableStat.Close();
                ChangeableStat.Dispose();
                Thread.Sleep(20);
            }
            catch
            {
                Console.Write("");
            }
        }

        public static int LevelDifferenceOutput()
        {
            Thread.Sleep(20);
            string FileofOutput = @"C:\DinosaurGame\Tech\herelieslevel.txt";
            StreamReader ChangedStat = new StreamReader(FileofOutput);
            int DifferenceNumerical = Convert.ToInt32(ChangedStat.ReadLine());
            ChangedStat.Close();
            return DifferenceNumerical;

        }

        public event EventHandler LevelChange;
        */
        // здоровье и его изменение

        public int health
        {
            get { return m_health; }
            set
            {
                m_health = value;
                /*int t_health = health;
                if (health != value)
                {
                    Console.WriteLine("Health is changed to {0}", value);
                    m_health = value;                    
                    HealthDifferenceInput(health - t_health, "health");
                    HealthChange?.Invoke(this, EventArgs.Empty);                    

                }*/
            }
        }
        /*
        public static void HealthDifferenceInput(int statDifference, string stat)
        {
            try
            {
                string FileOfInput = @"C:\DinosaurGame\Tech\herelieshealth.txt";
                if (File.Exists(FileOfInput)) File.Delete(FileOfInput);
                StreamWriter ChangeableStat = new StreamWriter(FileOfInput);
                ChangeableStat.WriteLine(statDifference.ToString());
                ChangeableStat.WriteLine(" is how changed {0}, {1}", stat);
                ChangeableStat.Close();
                ChangeableStat.Dispose();
                Thread.Sleep(20);
            }
            catch
            {
                Console.Write("");
            }
        }

        public static int HealthDifferenceOutput()
        {
            try
            { 
            string FileofOutput = @"C:\DinosaurGame\Tech\herelieshealth.txt";
                       
                Thread.Sleep(20);
                
                StreamReader ChangedStat = new StreamReader(FileofOutput);
                int DifferenceNumerical = Convert.ToInt32(ChangedStat.ReadLine());
                ChangedStat.Close();
                return DifferenceNumerical;
            }
            catch
            {
                return 1;
            }
        }

        public event EventHandler HealthChange;
        */
        // sprint and its change

        public int sprint
        {
            get { return m_sprint; }
            set
            {
                int t_sprint = sprint;
                if (sprint != value)
                {
                    m_sprint = value;
                    SprintDifferenceInput(sprint - t_sprint, "sprint");
                    SprintChange?.Invoke(this, EventArgs.Empty);

                }
            }
        }

        public static void SprintDifferenceInput(int statDifference, string stat)
        {
            try
            {
                string FileOfInput = @"C:\DinosaurGame\Tech\hereliessprint.txt";
                if (File.Exists(FileOfInput)) File.Delete(FileOfInput);
                StreamWriter ChangeableStat = new StreamWriter(FileOfInput);
                ChangeableStat.WriteLine(statDifference.ToString());
                ChangeableStat.WriteLine(" is how changed {0}", stat);
                ChangeableStat.Close();
                ChangeableStat.Dispose();
                Thread.Sleep(20);
            }
            catch
            {
                Console.WriteLine("Oh, hi, Mark!");
            }
        }

        public static int SprintDifferenceOutput()
        {
            Thread.Sleep(20);
            string FileofOutput = @"C:\DinosaurGame\Tech\hereliessprint.txt";
            StreamReader ChangedStat = new StreamReader(FileofOutput);
            int DifferenceNumerical = Convert.ToInt32(ChangedStat.ReadLine());
            ChangedStat.Close();
            return DifferenceNumerical;

        }

        public event EventHandler SprintChange;

        // stayer and its change

        public int stayer
        {
            get { return m_stayer; }
            set
            {
                int t_stayer = stayer;
                if (stayer != value)
                {
                    m_stayer = value;
                    StayerDifferenceInput(stayer - t_stayer, "stayer");
                    StayerChange?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public static void StayerDifferenceInput(int statDifference, string stat)
        {
            try
            {
                string FileOfInput = @"C:\DinosaurGame\Tech\hereliesstayer.txt";
                if (File.Exists(FileOfInput)) File.Delete(FileOfInput);
                StreamWriter ChangeableStat = new StreamWriter(FileOfInput);
                ChangeableStat.WriteLine(statDifference.ToString());
                ChangeableStat.WriteLine(" is how changed {0}", stat);
                ChangeableStat.Close();
                ChangeableStat.Dispose();
                Thread.Sleep(20);
            }
            catch
            {
                Console.WriteLine("Oh, hi, Mark!");
            }
        }

        public static int StayerDifferenceOutput()
        {
            Thread.Sleep(20);
            string FileofOutput = @"C:\DinosaurGame\Tech\hereliesstayer.txt";
            StreamReader ChangedStat = new StreamReader(FileofOutput);
            int DifferenceNumerical = Convert.ToInt32(ChangedStat.ReadLine());
            ChangedStat.Close();
            return DifferenceNumerical;

        }

        public event EventHandler StayerChange;

        //intelligence and its change

        public int intelligence
        {
            get { return m_intelligence; }
            set
            {
                int t_intelligence = intelligence;
                if (intelligence != value)
                {
                    m_intelligence = value;
                    IntelligenceDifferenceInput(intelligence - t_intelligence, "intelligence");
                    IntelligenceChange?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public static void IntelligenceDifferenceInput(int statDifference, string stat)
        {
            try
            {
                string FileOfInput = @"C:\DinosaurGame\Tech\hereliesintelligence.txt";
                if (File.Exists(FileOfInput)) File.Delete(FileOfInput);
                StreamWriter ChangeableStat = new StreamWriter(FileOfInput);
                ChangeableStat.WriteLine(statDifference.ToString());
                ChangeableStat.WriteLine(" is how changed {0}", stat);
                ChangeableStat.Close();
                ChangeableStat.Dispose();
                Thread.Sleep(20);
            }
            catch
            {
                Console.WriteLine("Oh, hi, Mark!");
            }
        }

        public static int IntelligenceDifferenceOutput()
        {
            Thread.Sleep(20);
            string FileofOutput = @"C:\DinosaurGame\Tech\hereliesintelligence.txt";
            StreamReader ChangedStat = new StreamReader(FileofOutput);
            int DifferenceNumerical = Convert.ToInt32(ChangedStat.ReadLine());
            ChangedStat.Close();
            return DifferenceNumerical;

        }

        public event EventHandler IntelligenceChange;

        // progressivity and its change

        public int progressivity
        {
            get { return m_progressivity; }
            set
            {
                int t_progressivity = progressivity;
                if (progressivity != value)
                {
                    m_progressivity = value;
                    ProgressivityDifferenceInput(progressivity - t_progressivity, "progressivity");
                    ProgressivityChange?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public static void ProgressivityDifferenceInput(int statDifference, string stat)
        {
            try
            {
                string FileOfInput = @"C:\DinosaurGame\Tech\hereliesprogressivity.txt";
                if (File.Exists(FileOfInput)) File.Delete(FileOfInput);
                StreamWriter ChangeableStat = new StreamWriter(FileOfInput);
                ChangeableStat.WriteLine(statDifference.ToString());
                ChangeableStat.WriteLine(" is how changed {0}", stat);
                ChangeableStat.Close();
                ChangeableStat.Dispose();
                Thread.Sleep(20);
            }
            catch
            {
                Console.WriteLine("Oh, hi, Mark!");
            }
        }

        public static int ProgressivityDifferenceOutput()
        {
            Thread.Sleep(20);
            string FileofOutput = @"C:\DinosaurGame\Tech\hereliesprogressivity.txt";
            StreamReader ChangedStat = new StreamReader(FileofOutput);
            int DifferenceNumerical = Convert.ToInt32(ChangedStat.ReadLine());
            ChangedStat.Close();
            return DifferenceNumerical;

        }

        public event EventHandler ProgressivityChange;

        //perception and its change

        public int perception
        {
            get { return m_perception; }
            set
            {
                int t_perception = perception;
                if (perception != value)
                {
                    m_perception = value;
                    PerceptionDifferenceInput(perception - t_perception, "perception");
                    PerceptionChange?.Invoke(this, EventArgs.Empty);


                }
            }
        }

        public static void PerceptionDifferenceInput(int statDifference, string stat)
        {
            try
            {
                string FileOfInput = @"C:\DinosaurGame\Tech\hereliesperception.txt";
                if (File.Exists(FileOfInput)) File.Delete(FileOfInput);
                StreamWriter ChangeableStat = new StreamWriter(FileOfInput);
                ChangeableStat.WriteLine(statDifference.ToString());
                ChangeableStat.WriteLine(" is how changed {0}", stat);
                ChangeableStat.Close();
                ChangeableStat.Dispose();
                Thread.Sleep(20);
            }
            catch
            {
                Console.WriteLine("Oh, hi, Mark!");
            }
        }

        public static int PerceptionDifferenceOutput()
        {
            Thread.Sleep(20);
            string FileofOutput = @"C:\DinosaurGame\Tech\hereliesperception.txt";
            StreamReader ChangedStat = new StreamReader(FileofOutput);
            int DifferenceNumerical = Convert.ToInt32(ChangedStat.ReadLine());
            ChangedStat.Close();
            return DifferenceNumerical;

        }

        public event EventHandler PerceptionChange;

        //luck and its change
        public int luck
        {
            get { return m_luck; }
            set
            {
                int t_luck = luck;
                if (luck != value)
                {
                    m_luck = value;
                    LuckDifferenceInput(luck - t_luck, "luck");
                    LuckChange?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public static void LuckDifferenceInput(int statDifference, string stat)
        {
            try
            {
                string FileOfInput = @"C:\DinosaurGame\Tech\hereliesluck.txt";
                if (File.Exists(FileOfInput)) File.Delete(FileOfInput);
                StreamWriter ChangeableStat = new StreamWriter(FileOfInput);
                ChangeableStat.WriteLine(statDifference.ToString());
                ChangeableStat.WriteLine(" is how changed {0}", stat);
                ChangeableStat.Close();
                ChangeableStat.Dispose();
                Thread.Sleep(20);
            }
            catch
            {
                Console.WriteLine("Oh, hi, Mark!");
            }
        }

        public static int LuckDifferenceOutput()
        {
            Thread.Sleep(20);
            string FileofOutput = @"C:\DinosaurGame\Tech\hereliesluck.txt";
            StreamReader ChangedStat = new StreamReader(FileofOutput);
            int DifferenceNumerical = Convert.ToInt32(ChangedStat.ReadLine());
            ChangedStat.Close();
            return DifferenceNumerical;

        }

        public event EventHandler LuckChange;



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
            public static void Attack(YourCreature a, EnemyCreature b)
            {
                //a.HealthChange += Tutorial.OnHealthChange;
                Console.WriteLine("{0} attacks {1}", a.name, b.name);
                double attack_coefficient = (a.sprint * a.progressivity) / 2;
                double defence_coefficient = (a.stayer * a.intelligence) / 2;
                double result_of_attack = attack_coefficient / defence_coefficient;

                if (result_of_attack < 1)
                {
                    Console.WriteLine("Attack failed");
                    double m_receivedexp = 0;
                    m_receivedexp = (b.full_health * 0.25);
                    a.exp += m_receivedexp;
                    Console.WriteLine("You gained {0} experience", m_receivedexp);
                }
                else if (result_of_attack > 1)
                {

                    while ((a.health / 10 <= b.m_health) || (b.m_health / 10 >= a.health))
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
                        double m_receivedexp = 0;
                        m_receivedexp = (b.full_health * 2);
                        a.exp += m_receivedexp;
                        Console.WriteLine("You gained {0} experience", m_receivedexp);
                        Scavenge(a, b);
                    }
                    else if ((b.m_health / 10 > a.health) || (a.health < 0))
                    {
                        Console.WriteLine("You died");
                        GameFunctions.Exit_Game();
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
                                m_receivedexp = (b.full_health * 2);
                                a.exp += m_receivedexp;
                                Console.WriteLine("You gained {0} experience", m_receivedexp);
                                Scavenge(a, b);
                            }
                            else if ((b.m_health / 10 > a.health) || (a.health < 0))
                            {
                                Console.WriteLine("You died");
                                GameFunctions.Exit_Game();
                            }
                            break;
                    }
                }
            }

            public static void StealthAttack(YourCreature a, EnemyCreature b)
            {
                if (a.luck > b.m_perception)
                {
                    Console.WriteLine("Stealth attack is successful");
                    b.m_health = 0;
                    double m_receivedexp = (b.full_health * 1.5);
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

            public static void printStats(EnemyCreature a)
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
                int scavengeable_meat = b.full_health / 4;
                if (a.health < full_health)
                {
                    if (scavengeable_meat > (full_health - scavengeable_meat))
                    {
                        a.health = full_health;
                    }
                    else a.health += scavengeable_meat;
                }

            }

            public static bool ShowingUp(YourCreature a, EnemyCreature b, string a1, string b1)
            {
                if ((a.m_progressivity * a.m_luck) > (b.m_progressivity * b.m_luck))
                {
                    Console.WriteLine("{0} has successfully demonstrated its supremacy on {1}", a1, b1);
                    return true;
                }
                else
                {
                    Console.WriteLine("{0} has failed to demonstrate its supremacy on {1}", a1, b1);
                    return false;
                }
            }

            class Trytilodontis : EnemyCreature
            {
                public Trytilodontis()
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
                    this.m_luck += 0;
                    printStats(this);
                }




            }

            class Adelobasileus : EnemyCreature
            {
                public Adelobasileus()
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

            public class Cryolophosaurus : EnemyCreature
            {
                public Cryolophosaurus(int sex)
                {
                    this.DoStats();
                    this.name = "Cryolophosaurus";
                    this.m_health = 450;
                    this.m_level = 35;
                    this.DoStats();
                    this.m_sprint += 6;
                    this.m_stayer += 5;
                    this.m_intelligence += 3;
                    this.m_progressivity += 4;
                    this.m_perception += 3;
                    this.m_luck += 9;
                    this.sex = sex;
                    Console.WriteLine("You can see {0}. {0} has  {1} health,  {2} sprint, {3} stayer, {4} intelligence, {5} progressivity, {6} perception, {7} luck", this.name, this.m_health, this.m_sprint, this.m_stayer, this.m_intelligence, this.m_progressivity, this.m_perception, this.m_luck);
                    Console.WriteLine("Sex is {0}", this.PrintSex());
                }
            }



            public class Dragonfly : EnemyCreature
            {

                public Dragonfly()
                {
                    this.DoStats();
                    this.name = "Dragonfly";
                    this.m_health = 15;
                    this.m_level = 1;
                    this.m_sprint += 2;
                    this.m_stayer += 0;
                    this.m_intelligence -= 1;
                    this.m_progressivity -= 1;
                    this.m_perception += 3;
                    this.m_luck += 0;
                    Console.WriteLine("You can see {0}. {0} has  {1} health,  {2} sprint, {3} stayer, {4} intelligence, {5} progressivity, {6} perception, {7} luck", this.name, this.m_health, this.m_sprint, this.m_stayer, this.m_intelligence, this.m_progressivity, this.m_perception, this.m_luck);
                }

            }

            public class Cockroach : EnemyCreature
            {

                public Cockroach()
                {
                    this.DoStats();
                    this.name = "Cockroach";
                    this.m_health = 8;
                    this.m_level = 1;
                    this.m_sprint -= 1;
                    this.m_stayer -= 1;
                    this.m_intelligence -= 1;
                    this.m_progressivity -= 1;
                    this.m_perception -= 1;
                    this.m_luck -= 1;
                    Console.WriteLine("You can see {0}. {0} has  {1} health,  {2} sprint, {3} stayer, {4} intelligence, {5} progressivity, {6} perception, {7} luck", this.name, this.m_health, this.m_sprint, this.m_stayer, this.m_intelligence, this.m_progressivity, this.m_perception, this.m_luck);
                }
            }

            public class Austropleuropholis : EnemyCreature
            {

                public Austropleuropholis()
                {
                    this.DoStats();
                    this.name = "Austropleuropholis";
                    this.m_health = 30;
                    this.m_level = 2;
                    this.m_sprint += 5;
                    this.m_stayer += 0;
                    this.m_progressivity -= 1;
                    this.m_perception += 4;
                    this.m_luck += 1;
                    Console.WriteLine("You can see {0}. {0} has  {1} health,  {2} sprint, {3} stayer, {4} intelligence, {5} progressivity, {6} perception, {7} luck", this.name, this.m_health, this.m_sprint, this.m_stayer, this.m_intelligence, this.m_progressivity, this.m_perception, this.m_luck);
                }
            }

            public class Zapatodon : EnemyCreature
            {

                public Zapatodon()
                {
                    this.DoStats();
                    this.name = "Zapatodon";
                    this.m_health = 50;
                    this.m_level = 4;
                    this.m_sprint += 3;
                    this.m_stayer += 2;
                    this.m_intelligence -= 1;
                    this.m_progressivity += 1;
                    this.m_perception += 3;
                    this.m_luck += 1;
                    Console.WriteLine("You can see {0}. {0} has  {1} health,  {2} sprint, {3} stayer, {4} intelligence, {5} progressivity, {6} perception, {7} luck", this.name, this.m_health, this.m_sprint, this.m_stayer, this.m_intelligence, this.m_progressivity, this.m_perception, this.m_luck);
                }
            }
        }

    }
}