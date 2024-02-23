using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Movements
{
    public  abstract class Movement
    {
        protected Vector2 speed;
        protected Vector2 startPos;
        protected Vector2 size;
        protected int stepCount;

        public Movement(Vector2 newSpeed, Vector2 newPos, Vector2 size)
        {
            this.speed = newSpeed;
            this.startPos = newPos;
            this.size = size;
            this.stepCount = 0;
        }

        public abstract Vector2 Move(Vector2 position, double elapsedTime);
        public int getStepCount()
        {
            return stepCount;
        }
    }
}
