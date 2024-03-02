using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGameDecorator
{
    public abstract class zObj
    {
        private int health;
        private char type;
        

        public abstract int getHealth();
        public abstract char getType();
        public abstract int takeDamage(int damage);
        public abstract bool die();
        public abstract int getObjectHealth();
        public abstract int takeDamageFromAbove(int damage);

        public abstract bool objectDie();

        public abstract bool update();

    }

    class Zombie : zObj
    {
        private int health = 50;
        private char type = 'R';

        public override int getObjectHealth()
        {
            return this.getHealth();
        }

        public override int getHealth()
        {
            return this.health;
        }

        public override char getType()
        {
            return this.type;
        }

        public override int takeDamage(int damage)
        {
            int leftOver = damage - health;
            health -= damage;
            return leftOver;
        }
        public override int takeDamageFromAbove(int damage)
        {
            return takeDamage(damage);
        }

        public override bool die()
        {
            return health <= 0;
        }

        public override bool objectDie()
        {
            return die();
        }

        public override bool update()
        {
            //return (this.die() == true || this.objectDie() == true);
            return objectDie();
        }
    }
}
