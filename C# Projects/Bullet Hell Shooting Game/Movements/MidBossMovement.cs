using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Movements
{
    internal class MidBossMovement : Movement
    {

        private Vector2 currentSpeed;
        private Vector2 startPos;
        private double currentMoveTime;
        private double moveStart;
        private double totalTime;
        private double waitTime = 0;
        private int phase = 0;
        private int rotationCount = 0;

        public MidBossMovement(Vector2 newSpeed, Vector2 newPos, Vector2 size) : base(newSpeed, newPos, size)
        {
            stepCount = -1;
            currentSpeed = newSpeed;
            startPos = newPos;
            currentMoveTime = 0;
            moveStart = 0;
            totalTime = 0;
            
        }

        private Vector2 Phase0(Vector2 position, double elapsedTime)
        {
            position.Y += speed.Y * (float)elapsedTime;
            if (position.Y > startPos.Y + 100)
                phase++;
            return position;
        }

        private Vector2 Phase1(Vector2 position, double elapsedTime)
        {
            //totalTime += elapsedTime;
            if (rotationCount > 17)
                position.Y -= speed.Y * (float)elapsedTime;
                 
            if ((position.X >= 500) || (position.X <= 100) || (position.Y >= 300))
                    rotationCount++;

            if ((rotationCount % 3) == 0)
                    position.X += speed.X * (float)elapsedTime;
            else if ((rotationCount % 3) == 1)
            {
                position.X -= speed.X * (float)elapsedTime;
                position.Y += speed.Y * (float)elapsedTime;
            }
            else
            {
                position.X -= speed.X * (float)elapsedTime;
                position.Y -= speed.Y * (float)elapsedTime;
            }

            return position;
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
