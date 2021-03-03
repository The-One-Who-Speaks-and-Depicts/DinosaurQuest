using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinosaurQuest.Creatures
{
    public class Pack<T> : List<T> where T : ICreature
    {
        public Pack()
        {
            
        }

        public void Attack(ICreature attackedCreature)
        {
            throw new NotImplementedException();
        }

        public void Defend(ICreature attackingCreature)
        {
            throw new NotImplementedException();
        }

        public void Guard(T guardedCreature)
        {
            throw new NotImplementedException();
        }

        public void Sacrifice (T sacrifice)
        {
            throw new NotImplementedException();
        }

        public void Join (T candidate)
        {
            if (candidate is Anchiornis)
            {
                Anchiornis joiningAnchiornis = candidate as Anchiornis;
                if (joiningAnchiornis.friendliness > 50)
                {
                    Add(candidate);
                }
            }
        }
        
    }

}
