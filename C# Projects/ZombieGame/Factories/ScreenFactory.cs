using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Zombies;

namespace ZombieGame.Factories
{
    class ScreenFactory:ZombieFactory
    {
        public ScreenFactory() { }
        public override Zombie buildZombie()
        {
            return new ScreenDoorZombie();
        }
        public override Zombie buildZombie(int hp)
        {
            return null;
        }
    }
}
