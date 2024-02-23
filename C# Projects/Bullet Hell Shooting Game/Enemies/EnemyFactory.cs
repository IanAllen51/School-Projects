using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Bullet_Hell_Shooting_Game.Content.Engine;

namespace Bullet_Hell_Shooting_Game.Enemies
{
    class EnemyFactory
    {
        private ContentManager content;

        public EnemyFactory(ContentManager content)
        {
            this.content = content;
        }

        public Entity SpawnEnemy(Dictionary<string, string> settings, List<PatternInfo> patterns)
        {
            return new Entity(this.content, settings, patterns);
        }
    }
}
