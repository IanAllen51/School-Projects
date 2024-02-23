using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Movements
{
    internal class FinalBossMovement : Movement
    {
        private Vector2 currentSpeed;
        private Vector2 startPos;
        private double currentMoveTime;
        private double moveStart;
        private double totalTime;
        private double waitTime = 0;
        private int phase = 0;

        public FinalBossMovement(Vector2 newSpeed, Vector2 newPos, Vector2 size) : base(newSpeed, newPos, size)
        {
            stepCount = -1;
            currentSpeed = newSpeed;
            startPos = newPos;
            currentMoveTime = 0;
            moveStart = 0;
            totalTime = 0;
        }

        private Vector2 Phase0 (Vector2 position, double elapsedTime)
        {
            position.Y += speed.Y * (float)elapsedTime;
            if (position.Y > startPos.Y + 100)
                phase++;
            return position;
        }

        private Vector2 Phase1(Vector2 position, double elapsedTime)
        {
            totalTime += elapsedTime;

            if (totalTime < moveStart)
                return position;
            if (moveStart + currentMoveTime < totalTime || !inBounds(position)) // Get new direction and speed within 50 of normal speed
            {
                int xDir = getDirectionX(position);
                int yDir = getDirectionY(position);
                currentSpeed.X = xDir * Globals.Random.Next((int)speed.X - 50, (int)speed.X + 50);
                currentSpeed.Y = yDir * Globals.Random.Next((int)speed.Y - 50, (int)speed.Y + 50);

                waitTime = (Globals.Random.NextDouble() *.05 * .3 + .05) * 10;
                moveStart = totalTime + waitTime;
                currentMoveTime = (Globals.Random.NextDouble() * .1 * .3 + .1) * 10;
            }

            position.X += currentSpeed.X * (float)elapsedTime;
            position.Y += currentSpeed.Y * (float)elapsedTime;

            return position;
        }

        private int getDirectionX(Vector2 position)
        {
            if (position.X + size.X > Globals.screenSize.X - 50)
                return -1;
            else if (position.X < 50)
                return 1;
            else
                return Globals.Random.Next(-1, 2);
        }

        private int getDirectionY(Vector2 position)
        {
            if (position.Y + size.Y >  150)//350
                return -1;
            else if (position.Y < 20)
                return 1;
            else
                return Globals.Random.Next(-1, 2);
        }

        private bool inBounds(Vector2 position)
        {
           bool temp = position.X + size.X > Globals.screenSize.X || position.X < 0 || 
                position.Y + size.Y > 400 || position.Y < 0;
            return !temp;
        }

        public override Vector2 Move(Vector2 position, double elapsedTime)
        {
            switch (phase)
            {
                case 0:
                    position = Phase0(position, elapsedTime);
                    break;
                case 1:
                    position = Phase1(position, elapsedTime);
                    break;
            }
            

            return position;
        }
    }
}
