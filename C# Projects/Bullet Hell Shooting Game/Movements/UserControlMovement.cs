using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Movements
{
    internal class UserControlMovement : Movement
    {
        private Input input;

        public UserControlMovement(Vector2 newSpeed, Vector2 newPos, Vector2 size) : base (newSpeed, newPos, size)
        {
            input = new Input();
        }

        public override Vector2 Move(Vector2 position, double elapsedTime)
        {
            Vector2 direction = input.GetMoveInput();
            if (direction.Y == -1 && position.Y > 0)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                    position.Y -= this.speed.Y * (float)elapsedTime / 2;
                else
                    position.Y -= this.speed.Y * (float)elapsedTime;
            }
            if (direction.Y == 1 && position.Y + size.Y < Globals.screenSize.Y)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                    position.Y += this.speed.Y * (float)elapsedTime / 2;
                else
                    position.Y += this.speed.Y * (float)elapsedTime;
            }
            if (direction.X == -1 && position.X > 0)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                    position.X -= this.speed.X * (float)elapsedTime / 2;
                else
                    position.X -= this.speed.X * (float)elapsedTime;
            }
            if (direction.X == 1 && position.X + size.X < Globals.screenSize.X)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                    position.X += this.speed.X * (float)elapsedTime / 2;
                else
                    position.X += this.speed.X * (float)elapsedTime;
            }

            return position;
        }
    }
}
