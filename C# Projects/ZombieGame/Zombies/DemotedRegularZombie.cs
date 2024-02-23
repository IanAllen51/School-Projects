using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame.Zombies
{
    class DemotedRegularZombie:Zombie
    {
        public DemotedRegularZombie(int health)
        {
            this.total_Health = health;
            this.zombieType = "R";
            this.alive = true;
            this.accessory = false;
        }

        public override void takeDamage(int d)
        {
            this.total_Health -= d;
            if (total_Health <= 0)
            {
                this.die();
            }
        }

        public override void die()
        {
            this.alive = false;
        }

        public override string getInfo()
        {
            string infoStr = this.zombieType + "/" + this.total_Health;
            return infoStr;
        }

        public override int getHealth()
        {
            return this.total_Health;
        }

        public override bool isAlive()
        {
            return this.alive;
        }

        public override bool hasAccessory()
        {
            return this.accessory;
        }
        public override string getZombieType()
        {
            return this.zombieType;
        }
    }
}
