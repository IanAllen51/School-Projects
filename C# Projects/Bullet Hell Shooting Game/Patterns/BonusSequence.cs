using Bullet_Hell_Shooting_Game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Patterns
{
    internal class BonusSequence : Pattern
    {
        ProjectileType type;
        Vector2 initPosition;

        public BonusSequence(ContentManager content, ProjectileType type, Vector2 pos)
        {
            this.factory = new ProjectileFactory(content);
            this.firePattern = new List<Projectile>();
            this.initPosition = pos;
            this.type = type;
        }

        public List<Projectile> returnList(int shotCount)
        {
            if (shotCount == -1)
            {
                return firePattern;
            }

            Vector2 shotPos = new Vector2();

            for (int i = 1; i < 33; i++)//32
            {
                shotPos.X = initPosition.X + 50 * (float)Math.Cos(i);
                shotPos.Y = initPosition.Y + 50 * (float)Math.Sin(i);
                firePattern.Add(factory.Create(type, shotPos, Movements.MovementType.BONUSSEQUENCE, getSpeed(shotPos)));
                firePattern.Add(factory.Create(type, shotPos, Movements.MovementType.BONUSSEQUENCETWO, getSpeed(shotPos)));
                firePattern.Add(factory.Create(type, shotPos, Movements.MovementType.BONUSSEQUENCETHREE, getSpeed(shotPos)));
            }


            return firePattern;
        }

        private Vector2 getSpeed(Vector2 shotPos)
        {
            float dirX = (shotPos.X - initPosition.X);
            float dirY = (shotPos.Y - initPosition.Y);

            float z = (float)Math.Sqrt(dirX * dirX + dirY * dirY);
            z = 250 / z;
            return new Vector2(dirX * z, dirY * z);
        }


    }
}
