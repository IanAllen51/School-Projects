using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame.Factories
{
    abstract class ZombieFactory
    {
        public abstract Zombie buildZombie() ;
        public abstract Zombie buildZombie(int hp);
    }
}
