using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Movements
{
    internal class GruntBMovement : Movement
    {
        //private int stepCount;

        public GruntBMovement(Vector2 newSpeed, Vector2 newPos, Vector2 size) : base(newSpeed, newPos, size)
        {
            stepCount = -1;
        }

        public override Vector2 Move(Vector2 position, double elapsedTime)
        {
            Vector2 distance = new Vector2(0, 0);

            if (stepCount == 8)
            {
                distance.X = -this.speed.X * (float)elapsedTime;
                distance.Y = 0;
                return position + distance;
            }

            if (stepCount == -1)
            {
                distance.Y = this.speed.Y * (float)elapsedTime;
                distance.X = 0;
                if (position.Y >= 50)
                    stepCount++;
            }
            else if (stepCount % 2 == 0)
            {
                distance.X = this.speed.X * (float)elapsedTime;
                distance.Y = 0;
                if (position.X >= 650)
                    stepCount++;
            }
            else if (stepCount % 2 == 1)
            {
                distance.X = -this.speed.X * (float)elapsedTime;
                distance.Y = 0;
                if (position.X <= 50)
                    stepCount++;
            }

            return position + distance;
        }
    }
}
