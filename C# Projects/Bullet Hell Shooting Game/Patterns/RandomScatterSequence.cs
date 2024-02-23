using Bullet_Hell_Shooting_Game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Patterns
{
    internal class RandomScatterSequence : Pattern
    {
        ProjectileType type;
        Vector2 initPosition;
        Random rnd = new Random();

        public RandomScatterSequence(ContentManager content, ProjectileType type, Vector2 pos)
        {
            this.factory = new ProjectileFactory(content);
            this.firePattern = new List<Projectile>();
            this.initPosition = pos;
            this.type = type;
        }

        public List<Projectile> returnList(int shotCount)
        {
            if (shotCount == -1)
                return firePattern;
            float a = (float)(Math.PI - (float)shotCount / 6);
            Vector2 shotPos = new Vector2();
            shotPos.X = initPosition.X + 100 * (float)Math.Cos(a);
            shotPos.Y = initPosition.Y + 100 * (float)Math.Sin(a);
            firePattern.Add(factory.Create(type, shotPos, Movements.MovementType.CUSTOM, getSpeed())); //new Vector2(rnd.Next(-50,50)*10,rnd.Next(-50,50)*10)

            a = (float)(Math.PI - (float)shotCount / 6);
            shotPos.X = initPosition.X - 100 * (float)Math.Cos(a);
            shotPos.Y = initPosition.Y - 100 * (float)Math.Sin(a);
            firePattern.Add(factory.Create(type, shotPos, Movements.MovementType.CUSTOM, getSpeed()));

            return firePattern;
        }

        public Vector2 getSpeed()
        {
            Vector2 vec = new Vector2();
            float xVal = rnd.Next(-50, 50);
            if (xVal < 10 && xVal > 0)
                xVal += 10;
            if (xVal < 0 && xVal > -10)
                xVal -= 10;
            vec.X = xVal * 10;

            float yVal = rnd.Next(-50, 50);
            if (yVal < 10 && yVal > 0)
                yVal += 10;
            if (yVal < 0 && yVal > -10)
                yVal -= 10;
            vec.Y = yVal * 10;

            return vec;
        }
    }
}
