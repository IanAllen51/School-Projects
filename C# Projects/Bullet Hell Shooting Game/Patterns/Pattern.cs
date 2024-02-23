using Bullet_Hell_Shooting_Game.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Patterns
{
    internal abstract class Pattern
    {
        protected List<Projectile> firePattern;
        protected ProjectileFactory factory;

        public List<Projectile> returnList()
        {
            return firePattern;
        }
    }
}
