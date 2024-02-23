using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bullet_Hell_Shooting_Game
{
    public class Settings
    {
        public Dictionary<string, string> player { get; set; }
        public Dictionary<string, string> keybinds { get; set; }
        public Dictionary<string, Dictionary<string, string>> Enemies { get; set; }
        public Dictionary<string, Dictionary<string, string>> Stage1 { get; set; }
    }
}
