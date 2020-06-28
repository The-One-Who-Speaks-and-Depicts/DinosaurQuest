using System.Collections.Generic;


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
        List<ICreature> creatures { get; set; }

        List<ILandscape> landscapes { get; set; }
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
