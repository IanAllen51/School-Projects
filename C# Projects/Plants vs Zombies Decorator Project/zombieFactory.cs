using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGameDecorator
{
    class zombieFactory
    {
        public zombieFactory() { }
        public zObj createZombie(int num)
        {
            zObj zombie = new Zombie();
            switch (num)
            {
                case 1:
                    break;
                case 2:
                    zombie = new ConeZombie(zombie);
                    break;
                case 3:
                    zombie = new BucketZombie(zombie);
                    break;
                case 4:
                    zombie = new ScreenZombie(zombie);
                    break;
                default:
                    break;

            }

            return zombie;
        }
    }
}
