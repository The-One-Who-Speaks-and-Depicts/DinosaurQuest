using System;

namespace DinosaurQuest.GameFunctions
{
    public static class ServiceFunctions
    {
        public static int ChoosingRightKey(char m_readKey)
        {
            Console.WriteLine(" ");
            return Convert.ToInt32(m_readKey) - 48;
        }


    }
}
