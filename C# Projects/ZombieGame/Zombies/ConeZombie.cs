using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame.Zombies
{
    class ConeZombie : Zombie
    {
        public ConeZombie()
        {
            this.accessoryHealth = 25;
            this.total_Health = this.baseHealth + this.accessoryHealth;
            this.zombieType = "C";
            this.alive = true;
            this.accessory = true;
        }

        public override void takeDamage(int d)
        {
            if (this.accessory == true)
            {
                this.accessoryHealth -= d;
                if (this.accessoryHealth <= 0)
                {
                    this.accessory = false;
                }
                this.total_Health = this.baseHealth + this.accessoryHealth;

            }
            else
            {
                total_Health -= d;
            }

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
