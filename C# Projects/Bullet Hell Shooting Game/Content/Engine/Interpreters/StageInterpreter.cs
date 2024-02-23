using System;
using System.Collections.Generic;
using System.Text;
using static Bullet_Hell_Shooting_Game.Content.Engine.EnemyInterpreter;

namespace Bullet_Hell_Shooting_Game.Content.Engine
{
    internal class StageInterpreter
    {
        public Dictionary<string, Stage> stage { get; set; }

        public class Stage
        {
            public int time { get; set; }
            public string enemyType { get; set; }
            public int enemySpeed { get; set; }
            public int enemyAmount { get; set; }
            public float interval { get; set; }
            public Dictionary<string, PatternInfo> patterns { get; set; }
            public int positionX { get; set; }
            public int positionY    { get; set; }
            public int offsetX { get; set; }
            public int offsetY { get; set; }
            public int speed { get; set; }
            public int duration { get; set; }
            public double lastSpawn { get; set; }
            public int currentCount { get; set; }
        }
    }

}
