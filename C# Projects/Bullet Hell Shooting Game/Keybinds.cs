using Bullet_Hell_Shooting_Game.Content.Engine.Interpreters;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Text.Json;

namespace Bullet_Hell_Shooting_Game
{
    internal class Keybinds
    {
        private Keys userUp;
        private Keys userDown;
        private Keys userLeft;
        private Keys userRight;
        private Keys userShoot;
        public Keys UserUp { get { return userUp; } }
        public Keys UserDown { get { return userDown; } }
        public Keys UserLeft { get { return userLeft; } }
        public Keys UserRight { get { return userRight; } }
        public Keys UserShoot { get { return userShoot; } }

        public Keybinds()
        {
            string data = File.ReadAllText("../../../Content/Engine/KeyBinds.json");
            KeyBindInterpreter keyBindInterpreter = JsonSerializer.Deserialize<KeyBindInterpreter>(data);
            Enum.TryParse(keyBindInterpreter.keybinds["Up"], out userUp);
            Enum.TryParse(keyBindInterpreter.keybinds["Down"], out userDown);
            Enum.TryParse(keyBindInterpreter.keybinds["Left"], out userLeft);
            Enum.TryParse(keyBindInterpreter.keybinds["Right"], out userRight);
            Enum.TryParse(keyBindInterpreter.keybinds["Shoot"], out userShoot);
        }
    }
}
