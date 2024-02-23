using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    //product
    abstract class Zombie
    {
        protected int total_Health;
        protected string zombieType;
        protected int baseHealth = 50;
        protected int accessoryHealth;
        protected bool accessory;
        protected bool alive;

        public Zombie() { }
        public abstract void takeDamage(int d);
        public abstract void die();
        public abstract string getInfo();
        public abstract int getHealth();
        public abstract bool isAlive();
        public abstract bool hasAccessory();
        public abstract string getZombieType();
    }
}
