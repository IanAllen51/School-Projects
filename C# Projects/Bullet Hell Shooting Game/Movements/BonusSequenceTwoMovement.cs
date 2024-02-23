using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Movements
{
    internal class BonusSequenceTwoMovement : Movement
    {
        private double startAngle;
        private double angle;

        public BonusSequenceTwoMovement(Vector2 newSpeed, Vector2 newPos, Vector2 size) : base(newSpeed, newPos, size)
        {
            this.angle = Math.Acos(newSpeed.X / Math.Sqrt(Math.Pow(newSpeed.X, 2) + Math.Pow(newSpeed.Y, 2)));
            this.startAngle = angle;
        }

        public override Vector2 Move(Vector2 position, double elapsedTime)
        {

            if (getDistance(position, startPos) < 100)
            {
                position.X += (float)(speed.X * elapsedTime);
                position.Y += (float)(speed.Y * elapsedTime);
                return position;
            }

            else if (getDistance(position, startPos) < 150) //150
            {
                if (Math.Cos(angle) == 0)
                    position.X += (float)(elapsedTime * 100);
                else
                    position.X += (float)(Math.Cos(angle) * elapsedTime * 100);//100

                if (Math.Sin(angle) == 0)
                    position.Y += (float)(elapsedTime * 100);
                else
                    position.Y += (float)(Math.Sin(angle) * elapsedTime * 100);
                angle -= .05;

                return position;
            }
            else if (getDistance(position, startPos) < 200) //200
            {
                if (Math.Cos(angle) == 0)
                    position.X += (float)(elapsedTime * 100);
                else
                    position.X += (float)(Math.Cos(angle) * elapsedTime * 100);//100

                if (Math.Sin(angle) == 0)
                    position.Y += (float)(elapsedTime * 100);
                else
                    position.Y += (float)(Math.Sin(angle) * elapsedTime * 100);
                angle += .05;
                
                return position;
            }
            else if (getDistance(position, startPos) < 250) //250
            {
                if (Math.Cos(angle) == 0)
                    position.X += (float)(elapsedTime * 100);
                else
                    position.X += (float)(Math.Cos(angle) * elapsedTime * 100);//100

                if (Math.Sin(angle) == 0)
                    position.Y += (float)(elapsedTime * 100);
                else
                    position.Y += (float)(Math.Sin(angle) * elapsedTime * 100);
                angle -= .05;

                return position;
            }
            else
            {
                if (Math.Cos(angle) == 0)
                    position.X += (float)(elapsedTime * 100);
                else
                    position.X += (float)(Math.Cos(angle) * elapsedTime * 100);//100

                if (Math.Sin(angle) == 0)
                    position.Y += (float)(elapsedTime * 100);
                else
                    position.Y += (float)(Math.Sin(angle) * elapsedTime * 100);
                
                return position;
            }

        }

        private float getDistance(Vector2 pos1, Vector2 pos2)
        {
            float distance = (float)Math.Sqrt(Math.Pow(pos1.X - pos2.X, 2) + Math.Pow(pos1.Y - pos2.Y, 2));
            return Math.Abs(distance);
        }



    }
}
