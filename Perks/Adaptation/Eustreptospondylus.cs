using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialGame.Perks.Adaptation
{
    class Eustreptospondylus : IPerk
    {
        public Eustreptospondylus()
        {
        }

        public string name => "Eustreptospondylus"; 

        public string desc { get { return "Eustreptospondyli are more intelligent than Eoraptors, however, for them the insufficiency of strategical behaviour is still significantly seen. Still, they are highly adaptive, despite being slower in that way than Eoraptors, They do not develop some great aromorphoses, but some catastrophic failures are also stepping aside from the wave of their evolution."; } }

        public int branch => 3;

        public int coolDownTime => 15;

        public int coolDown { get; set; }
        public bool isGettable { get; set; }

        public void CoolDownSet()
        {
            coolDown = coolDownTime;
        }

        public void OnBreeding(Character character, Character partner, Character descendant)
        {
            // у Breeding нет cooldown'а, потому что он однократен
            // также, поскольку игрок здесь де-факто контролирует эволюционный поток, сраабатывание навыка не рандомизировано, а гарантированно
            throw new NotImplementedException();
        }

        public void OnEnemy(Character character, ICreature enemy, ITile tile)
        {
            throw new NotImplementedException();
        }

        public void OnFriend(Character character, ICreature friend, ITile tile)
        {
            throw new NotImplementedException();
        }

        public void OnMovement(Character character, ITile departingTile, ITile destinationTile)
        {
            throw new NotImplementedException();
        }

        public void OnPartner(Character character, ICreature partner, ITile tile)
        {
            throw new NotImplementedException();
        }

        public void OnPrey(Character character, ICreature prey, ITile tile)
        {
            throw new NotImplementedException();
        }

        public void OnRival(Character character, ICreature rival, ITile tile)
        {
            throw new NotImplementedException();
        }

        public void OnTile(Character character, ITile tile)
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            if (coolDown > 0)
            {
                coolDown--;
                if (coolDown == 0)
                {
                    Console.WriteLine(name + "is available to use!");
                }
            }
        }

        public void UnBlock()
        {
            isGettable = true;
            Console.WriteLine(name + "is unlocked!");
        }
    }
}
