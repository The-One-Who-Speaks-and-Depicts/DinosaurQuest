namespace DinosaurQuest.Territories
{
	public class MockTile : Tile
	{
        private int level_X_length {get; set;}
        private int level_Y_length {get; set;}        

        public MockTile(int _level_X_length, int _level_Y_length)
        {
        	level_X_length = _level_X_length;
        	level_Y_length = _level_Y_length;
        }


        public new bool isAccessible ()
        {
        	if (X > level_X_length || X < 0 || Y > level_Y_length || Y < 0)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
	}
}
