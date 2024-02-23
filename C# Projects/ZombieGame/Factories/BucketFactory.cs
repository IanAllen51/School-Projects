using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Zombies;

namespace ZombieGame.Factories
{
    class BucketFactory:ZombieFactory
    {
        public BucketFactory() { }
        public override Zombie buildZombie()
        {
            return new BucketZombie();
        }
        public override Zombie buildZombie(int hp)
        {
            return null;
        }
    }
}
