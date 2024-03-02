using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGameDecorator
{
    public abstract class Decorator : zObj
    {
        protected zObj zombieObj;

        public Decorator(zObj zomObj)
        {
            this.zombieObj = zomObj;
        }

        public override int getHealth()
        {
            return zombieObj.getHealth();
        }

        public override char getType()
        {
            return zombieObj.getType();
        }

        public override int takeDamage(int damage)
        {
            return zombieObj.takeDamage(damage);
        }

        public override bool die()
        {
            return zombieObj.die();
        }
    }

    public class ConeZombie : Decorator
    {
        private int health = 25;
        private char type = 'C';

        public override int getObjectHealth()
        {
            return this.health;
        }
        public ConeZombie(zObj zombieObj) : base(zombieObj)
        {
        }
        public override int getHealth()
        {
            return base.getHealth() + health;
        }
        public override char getType()
        {
            return this.type;
        }
        public override int takeDamage(int damage)
        {
            int d = damage - health;
            health -= damage;
            return d;
        }

        public override int takeDamageFromAbove(int damage)
        {
            return this.takeDamage(damage);
        }

        public override bool objectDie()
        {
            return health <= 0;
        }

        public override bool update()
        {
            return (base.die() == true || this.objectDie() == true);
        }
    }

    public class BucketZombie : Decorator
    {
        private int health = 100;
        private char type = 'B';

        public override int getObjectHealth()
        {
            return this.health;
        }
        public BucketZombie(zObj zombieObj) : base(zombieObj)
        {
        }
        public override int getHealth()
        {
            return base.getHealth() + health;
        }
        public override char getType()
        {
            return this.type;
        }
        public override int takeDamage(int damage)
        {
            int d = damage - health;
            health -= damage;
            return d;
        }

        public override int takeDamageFromAbove(int damage)
        {
            return this.takeDamage(damage);
        }

        public override bool objectDie()
        {
            return health <= 0;
        }

        public override bool update()
        {
            return (base.die() == true || this.objectDie() == true);
        }
    }

    public class ScreenZombie : Decorator
    {
        private int health = 25;
        private char type = 'S';

        public override int getObjectHealth()
        {
            return this.health;
        }
        public ScreenZombie(zObj zombieObj) : base(zombieObj)
        {
        }
        public override int getHealth()
        {
            return base.getHealth() + health;
        }
        public override char getType()
        {
            return this.type;
        }
        public override int takeDamage(int damage)
        {
            int d = damage - health;
            health -= damage;
            return d;
        }

        public override int takeDamageFromAbove(int damage)
        {
            return base.takeDamage(damage);
        }

        public override bool objectDie()
        {
            return health <= 0;
        }

        public override bool update()
        {
            return (base.die() == true || this.objectDie() == true);
        }
    }
}
