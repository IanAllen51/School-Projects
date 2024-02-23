using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Zombies;

namespace ZombieGame.Factories
{
    class DemotedFactory:ZombieFactory
    {
 
        public DemotedFactory() {}
        public override Zombie buildZombie(int hp)
        {
            return new DemotedRegularZombie(hp);
        }
        public override Zombie buildZombie()
        {
            return null;
        }
        
        
    }
}
