using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Movements
{
    internal class GruntAMovement : Movement
    {
        private double totalTime = 0;
        private Vector2 startPosition;

        public GruntAMovement(Vector2 newSpeed, Vector2 newPos, Vector2 size) : base(newSpeed, newPos, size)
        {
            stepCount = -1;
            startPos = newPos;
        }

        public override Vector2 Move(Vector2 position, double elapsedTime)
        {
            totalTime += elapsedTime;

            if (totalTime > 5 )
            {
                position.Y -= speed.Y * (float)elapsedTime;
            }
            else if (position.Y < startPos.Y + 300)
            {
                position.Y += speed.Y * (float)elapsedTime;
            }

            return position;
        }
    }
}
