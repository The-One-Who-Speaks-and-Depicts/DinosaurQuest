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
            if (coolDown == 0)
            {
                Console.WriteLine("Trying to heal...");
                Random rnd = new Random();
                int result = rnd.Next(1, 2);
                if (result == 1)
                {                    
                    int addedHealth = 5 * character.level;
                    if (friend.health + addedHealth < friend.maxHealth)
                    {
                        friend.health += addedHealth;
                        Console.WriteLine("You have healed the wounds of your friend by {0}!", addedHealth);
                    }
                    else
                    {
                        friend.health += friend.maxHealth;
                        Console.WriteLine("You have healed the wounds of your friend completely!");
                    }
                }
                else
                {
                    int removedHealth = 5 * character.level;
                    if (friend.health - removedHealth > 0)
                    {
                        friend.health -= removedHealth;
                        Console.WriteLine("You poisoned the wounds of your friend by {0}!", removedHealth);
                    }
                    else
                    {
                        character.pack.Remove(friend as Anchiornis);
                        Console.WriteLine("You have killed your friend!");
                    }
                }
                
            }
            else
            {
                Console.WriteLine("You are not ready to use this, yet.");
            }
        }

        public void OnMovement(Character character, ITile departingTile, ITile destinationTile)
        {
            throw new NotImplementedException();
        }

        public void OnPartner(Character character, ICreature partner, ITile tile)
        {
            Console.WriteLine("It is a pity that there is no additional way of how an Eustreptospondylus is able to attract a partner.");
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
