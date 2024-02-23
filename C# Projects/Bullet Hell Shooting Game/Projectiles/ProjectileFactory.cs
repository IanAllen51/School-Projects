using Bullet_Hell_Shooting_Game.Movements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Projectiles
{
    class ProjectileFactory
    {
        protected ContentManager content;

        public ProjectileFactory(ContentManager content)
        {
            this.content = content;
        }

        public Projectile Create(ProjectileType type, Vector2 pos, MovementType dir, Vector2 speed)
        {
            switch (type)
            {
                case ProjectileType.BASIC:
                    return new Projectile(content.Load<Texture2D>("Basic_Projectile"), pos, dir, speed);
                case ProjectileType.GRUNT:
                    return new Projectile(content.Load<Texture2D>("Grunt_Projectile"), pos, dir, speed);
                case ProjectileType.MIDBOSS:
                    return new Projectile(content.Load<Texture2D>("Basic_Projectile"), pos, dir, speed);
                case ProjectileType.FINALBOSS:
                    return new Projectile(content.Load<Texture2D>("Basic_Projectile"), pos, dir, speed);
                default:
                    return null;
            }   
        }
    }
}
