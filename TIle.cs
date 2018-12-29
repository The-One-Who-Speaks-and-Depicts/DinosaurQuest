using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Int32;

namespace TrialGame
{
    public class Tile
    {
        int m_coordX = 0;
        int m_coordY = 0;

        enum ELandscape
        {
            Peak,
            Mountainside,
            Waterfall,
            Cloud_forest,
            Forest,
            Steppe,
            Riverside,
            Nest
        }

        enum EYearTime
        {
            Winter,
            Spring,
            Summer,
            Fall
        }

        enum EDirection
        {
            northEast,
            north,
            northWest,
            west,
            southWest,
            south,
            southEast,
            east,
            noDir
        }

        string[] m_yeartimeDesc = new string[] 
        {
            "winter. The night of the existence, the night eternal. It is cold, and sometimes water in the skies freezes, unleashing a phenomenon of blue stars, which have not been there for years. Leaves and pins fall, and only little amount of trees does stand green and bold in this kingdom of nothingness. Life, however, still makes it through.",
            "spring. The great renewal, when the first rays of still weak sun shine over the domain of darkness, which Antarctica used to be for months and months. Every single being awakens from the state of sleepness and apathy, and the vegetation is again green and flourishing. For the single moment hope is again in this land.",
            "summer. Warm, sometimes even hot. The period of mating and big hunt for all and for each in this place. Sun shines throughout all the summer, which is good for both predators and prey, but for different reasons. Occasional rains does not spoil the overall great impression, and for some make it even better.",
            "fall. The time of beautiful sunsets and yellow leaves, when the new life begins its harsh journey through the very being in this region. It is time of nesting for ones and going out of eggs for others. And the end of year is coming, so nights are longer and colder, until sun is no more."
        };
        string[] m_landscapeDesc = new string[] { "PeakDesc", "MountainsideDesc", "WaterfallDesc", "Cloud_forestDesc", "ForestDesc", "SteppeDesc", "RiversideDesc", "NestDesc" };

        void choosingDirection(string direction)
        {
            if ((direction.Equals(EDirection.northEast.ToString())) || (direction.Equals(EDirection.north.ToString())) || (direction.Equals(EDirection.northWest.ToString())))
            {
                m_coordY++;
            }
            else if ((direction.Equals(EDirection.southEast.ToString())) || (direction.Equals(EDirection.south.ToString())) || (direction.Equals(EDirection.southWest.ToString())))
            {
                m_coordY--;
            }
            else if ((direction.Equals(EDirection.northEast.ToString())) || (direction.Equals(EDirection.east.ToString())) || (direction.Equals(EDirection.southEast.ToString())))
            {
                m_coordX++;
            }
            else if ((direction.Equals(EDirection.northWest.ToString())) || (direction.Equals(EDirection.west.ToString())) || (direction.Equals(EDirection.southWest.ToString())))
            {
                m_coordX--;
            }
            
        }

        void choosingYearTime (string yeartime)
        {
            if (yeartime.Equals(EYearTime.Winter.ToString()))
            {
                Console.WriteLine("It's {0}", m_yeartimeDesc[0]);
            }

            else if (yeartime.Equals(EYearTime.Spring.ToString()))
            {
                Console.WriteLine("It's {0}", m_yeartimeDesc[1]);
            }

            else if (yeartime.Equals(EYearTime.Summer.ToString()))
            {
                Console.WriteLine("It's {0}", m_yeartimeDesc[2]);
            }

            else if (yeartime.Equals(EYearTime.Fall.ToString()))
            {
                Console.WriteLine("It's {0}", m_yeartimeDesc[3]);
            }
        }

        void choosingLandscape(string landscape)
        {
            if (landscape.Equals(ELandscape.Peak.ToString()))
            {
                Console.WriteLine("You can see {0}", m_landscapeDesc[0]);
            }
            else if (landscape.Equals(ELandscape.Mountainside.ToString()))
            {
                Console.WriteLine("You can see {0}", m_landscapeDesc[1]);
            }
            else if (landscape.Equals(ELandscape.Waterfall.ToString()))
            {
                Console.WriteLine("You can see {0}", m_landscapeDesc[2]);
            }
            else if (landscape.Equals(ELandscape.Cloud_forest.ToString()))
            {
                Console.WriteLine("You can see {0}", m_landscapeDesc[3]);
            }
            else if (landscape.Equals(ELandscape.Forest.ToString()))
            {
                Console.WriteLine("You can see {0}", m_landscapeDesc[4]);
            }
            else if (landscape.Equals(ELandscape.Steppe.ToString()))
            {
                Console.WriteLine("You can see {0}", m_landscapeDesc[5]);
            }
            else if (landscape.Equals(ELandscape.Riverside.ToString()))
            {
                Console.WriteLine("You can see {0}", m_landscapeDesc[6]);
            }
            else if (landscape.Equals(ELandscape.Nest.ToString()))
            {
                Console.WriteLine("You can see {0}", m_landscapeDesc[7]);
            }
        }

        int CreatureAmount ()
        {
            Random creatureQuantity = new Random();
            int returnablecreatureQuantity = creatureQuantity.Next(1, 5);
            return returnablecreatureQuantity;
        }
       
        public Tile (string direction, string yeartime, string landscapetype)
        {
            choosingDirection(direction);
            choosingYearTime(yeartime);
            choosingLandscape(landscapetype);
            int creatures = CreatureAmount();
            for (int creatureScore = 0; creatureScore < creatures; creatureScore++)
            {
                YourCreature.EnemyCreature.Spawn();
            }
            Console.WriteLine("Your coordinates are {0}, {1}", m_coordX, m_coordY);
        }

        public Tile (string direction, string yeartime, string landscapetype, int creatureAmount, int spawnedCreature)
        {
            Console.WriteLine("Your coordinates are {0}, {1}", m_coordX, m_coordY);
            choosingDirection(direction);
            choosingYearTime(yeartime);
            choosingLandscape(landscapetype);
            int creatures = CreatureAmount();
            YourCreature.EnemyCreature.TutorialSpawn(spawnedCreature);
        }

        
            
        

        
    }
}