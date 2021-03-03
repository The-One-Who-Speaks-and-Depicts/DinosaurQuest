using System;

namespace DinosaurAction.GameFunctions
{
    static class ServiceFunctions
    {
        public static int ChoosingRightKey()
        {
            int m_decision;
            ConsoleKeyInfo m_readKey;
            m_readKey = Console.ReadKey();
            Console.WriteLine(" ");
            m_decision = Convert.ToInt32(m_readKey.KeyChar);
            m_decision -= 48;
            return m_decision;
        }       


    }
}
