using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialGame
{
    public interface ICreature
    {
        string name { get; set; }
        int health { get; set; }
        int stamina { get; set; }  
        int strength { get; set; }
        int speed { get; set; }
        int agility { get; set; }
        int perception { get; set; }
        int luck { get; set; }
        int appearance { get; set; }
        int intelligence { get; set; }

    }
}
