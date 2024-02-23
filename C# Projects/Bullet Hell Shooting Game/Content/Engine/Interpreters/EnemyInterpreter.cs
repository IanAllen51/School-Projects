using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Content.Engine
{
    internal class EnemyInterpreter
    {
        public Dictionary<string, Dictionary<string, string>> enemies { get; set; }
        public List<PatternInfo> patterns { get; set; }
    }

    public class PatternInfo
    {
        public string projectilePattern { get; set; }
        public float sequenceInterval { get; set; }
        public int sequenceShotCount { get; set; }
        public string projectileType { get; set; }
    }
}
