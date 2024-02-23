using System.Collections.Generic;

namespace Bullet_Hell_Shooting_Game.Content.Engine.Interpreters
{
    internal class PlayerInterpreter
    {
        public Dictionary<string, string> player { get; set; }
        public List<PatternInfo> patterns { get; set; }
    }
}
