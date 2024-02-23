using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bullet_Hell_Shooting_Game.Projectiles;
using Bullet_Hell_Shooting_Game.Movements;

namespace Bullet_Hell_Shooting_Game.Patterns
{
    class TriShot : Pattern
    {
        public TriShot(ContentManager content, ProjectileType type, Vector2 pos)
        {
            firePattern = new List<Projectile>();
            factory = new ProjectileFactory(content);
            Vector2 speed = new Vector2(0, 300);
            Vector2 tempPos = pos;
            tempPos.X = pos.X + 50;
            tempPos.Y = pos.Y + 15 + 50;
            firePattern.Add(factory.Create(type, tempPos, MovementType.CUSTOM, new Vector2(0, 400)));//center
            tempPos.X = pos.X - 15 + 50;
            tempPos.Y = pos.Y + 50;
            firePattern.Add(factory.Create(type, tempPos, MovementType.CUSTOM, new Vector2(-100, 400)));//left
            tempPos.X = pos.X + 15 + 50;
            tempPos.Y = pos.Y + 50;
            firePattern.Add(factory.Create(type, tempPos, MovementType.CUSTOM, new Vector2(100, 400)));//right
        }
    }
}

