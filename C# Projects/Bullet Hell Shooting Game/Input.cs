using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game
{
    internal class Input
    {
        private static Keybinds _keybinds ;

        public static Keybinds _Keybinds { set { _keybinds = value; } }

        /// <summary>
        /// Should deal with all inputs.
        /// Currently returns the direction of movement.
        /// </summary>
        /// <returns>Vector2 for movement direction.</returns>
        public Vector2 GetMoveInput()
        {
            Vector2 output = new Vector2(0, 0);

            if (Keyboard.GetState().IsKeyDown(_keybinds.UserUp))
                output.Y -= 1;
            if (Keyboard.GetState().IsKeyDown(_keybinds.UserDown))
                output.Y += 1;
            if (Keyboard.GetState().IsKeyDown(_keybinds.UserLeft))
                output.X -= 1;
            if (Keyboard.GetState().IsKeyDown(_keybinds.UserRight))
                output.X += 1;

            return output;
        }

        public bool GetShotInput()
        {
            if (Keyboard.GetState().IsKeyDown(_keybinds.UserShoot))
                return true;

            return false;
        }
    }
}


// usercontrol class has variable of Input type which returns a direction