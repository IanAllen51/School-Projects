using Bullet_Hell_Shooting_Game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Patterns
{
    internal class SpiralSequence : Pattern
    {
        private Vector2 initPosition;
        ProjectileType type;

        public SpiralSequence(ContentManager content, ProjectileType type, Vector2 pos)
        {
            this.factory = new ProjectileFactory(content);
            this.firePattern = new List<Projectile>();
            this.initPosition = pos;
            this.type = type;
        }

        public List<Projectile> returnList(int shotCount, Vector2 playerPos)
        {
            if (shotCount == -1)
                return firePattern;
            float a = (float)(Math.PI - (float)shotCount / 6);
            Vector2 shotPos = new Vector2();
            shotPos.X = initPosition.X + 100 * (float)Math.Cos(a);
            shotPos.Y = initPosition.Y + 100 * (float)Math.Sin(a);
            firePattern.Add(factory.Create(type, shotPos, Movements.MovementType.CUSTOM, getSpeed(playerPos, shotPos)));

            a = (float)(Math.PI - (float)shotCount / 6);
            shotPos.X = initPosition.X - 100 * (float)Math.Cos(a);
            shotPos.Y = initPosition.Y - 100 * (float)Math.Sin(a);
            firePattern.Add(factory.Create(type, shotPos, Movements.MovementType.CUSTOM, getSpeed(playerPos, shotPos)));

            return firePattern;
        }

        private Vector2 getSpeed(Vector2 playerPosition, Vector2 shotPos)
        {
            float dirX = (playerPosition.X - shotPos.X);
            float dirY = (playerPosition.Y - shotPos.Y);

            float z = (float)Math.Sqrt(dirX * dirX + dirY * dirY);
            z = 300 / z;
            return new Vector2(dirX * z, dirY * z);
        }
    }
}
