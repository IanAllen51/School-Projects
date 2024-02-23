using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Zombies;

namespace ZombieGame.Factories
{
    class ConeFactory:ZombieFactory
    {
        public ConeFactory() { }
        public override Zombie buildZombie()
        {
            return new ConeZombie();
        }
        public override Zombie buildZombie(int hp)
        {
            return null;
        }
    }
}
