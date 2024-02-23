using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Zombies;


namespace ZombieGame.Factories
{
    class RegularFactory: ZombieFactory
    {
        public RegularFactory() { }
        public override Zombie buildZombie()
        {
            return new RegularZombie();
        }
        public override Zombie buildZombie(int hp)
        {
            return null;
        }
    }
}
