using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialGame
{
    public abstract class Level
    {
        string levelName { get; set; }
        string levelDesc { get; set; }
        public int X_length { get; set; }
        public int Y_length { get; set; }
        public int Area { get; set; }
        public int CalcArea (int X, int Y)
        {
            return X * Y;
        }
        public enum Season
        {
            Winter = 0,
            Spring,
            Summer,
            Fall
        }
        public enum Weather
        {
            Sunny = 0,
            PartlyCloudy,
            Cloudy,
            HeavyClouds,
            Rain,
            Thunderstorm,
            Snow,
            SNowstorm,
            Hail,
            AfterRain            
        }
        public enum Windy
        {
            Silence = 0,
            Light,
            Sensible,
            Heavy,
            TropicalStorm
        }
        public enum Disasters
        {
            Earthquake = 0,
            Tsunami,
            Hurricane,
            VolcanoEruption,
            MeteorShower
        }
        public enum Vegetation
        {
            Desert = 0,
            Steppe,
            BrinkRiver,
            BrinkLake,
            BrinkSea,
            Bush,
            Forest,
            Swamp
        }
        public enum Landscape
        {
            Lowlands = 0,
            Plain,
            Highlands,
            Mountain
        }
        public enum Creatures
        {

        }
        public Character currentCharacter { get; set; }

        public Character Entrance (Character _currentCharacter)
        {
            return _currentCharacter;
        } 
        
        public void Transfer (Character _currentCharacter)
        {

        }
    }
}
