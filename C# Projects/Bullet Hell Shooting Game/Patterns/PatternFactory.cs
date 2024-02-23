using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Bullet_Hell_Shooting_Game.Projectiles;

namespace Bullet_Hell_Shooting_Game.Patterns
{
    class PatternFactory
    {
        protected ContentManager content;

        public PatternFactory(ContentManager content)
        {
            this.content = content;
        }

        public List<Projectile> Create(PatternType pType, ProjectileType type, Vector2 pos, Vector2 playerPoint, int sequencedShotCount = 0)
        {
            switch(pType)
            {
                case PatternType.SINGLE:
                    return (new SingleShot(content, type, pos)).returnList();
                case PatternType.TRI:
                    return (new TriShot(content, type, pos)).returnList();
                case PatternType.SCATTER:
                    return (new Scatter(content, type, pos)).returnList();
                case PatternType.SUNBURST:
                    return (new SunBurst(content, type, pos)).returnList();
                case PatternType.BOWTIE:
                    return (new BowTie(content, type, pos)).returnList();
                case PatternType.SPIRAL:
                    return (new SpiralSequence(content, type, pos)).returnList(sequencedShotCount, playerPoint);
                case PatternType.SUN:
                    return (new SunSequence(content, type, pos)).returnList(sequencedShotCount);
                case PatternType.BONUS:
                    return (new BonusSequence(content, type, pos)).returnList(sequencedShotCount);
                case PatternType.RANDOMSCATTER:
                    return (new RandomScatterSequence(content,type,pos)).returnList(sequencedShotCount);
                case PatternType.TRIPLESPIRAL:
                    return (new TripleSpiralSequence(content, type, pos)).returnList(sequencedShotCount, playerPoint);
                default:
                    return null;
            }
        }
    }
}
