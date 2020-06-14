using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialGame
{
    
    class Character : ICreature
    {
        public string name { get; set; }
        public int health { get; set; }
        public int stamina { get; set; }
        public int attack { get; set; }
        public int defence { get; set; }
        public int strength { get; set; }
        public int speed { get; set; }
        public int agility { get; set; }
        public int perception { get; set; }
        public int luck { get; set; }
        public int appearance { get; set; }

        public Character()
        {

        }
    }
}
