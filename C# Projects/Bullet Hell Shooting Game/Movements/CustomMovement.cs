using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Movements
{
    internal class CustomMovement : Movement
    {
        public CustomMovement(Vector2 newSpeed, Vector2 newPos, Vector2 size) : base(newSpeed, newPos, size)
        {
            speed = newSpeed;
        }

        public override Vector2 Move(Vector2 position, double elapsedTime)
        {
            position += speed * (float)elapsedTime;
            return position;
        }
    }
}
