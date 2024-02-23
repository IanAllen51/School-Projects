using Bullet_Hell_Shooting_Game.Enemies;
using Bullet_Hell_Shooting_Game.Patterns;
using Bullet_Hell_Shooting_Game.Projectiles;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Managers
{
    internal class ProjectileManager
    {
        private List<Projectile> hostileProjectiles;
        private List<Projectile> friendlyProjectiles;
        private List<Entity> enemies;
        private Player player;
        private PatternFactory patternFactory;
        private double prevUpdate = 0;

        public ProjectileManager(List<Projectile> fproj, List<Projectile> hproj, List<Entity> enemyList, Player play, ContentManager content)
        {
            friendlyProjectiles = fproj;
            hostileProjectiles = hproj;
            enemies = enemyList;
            player = play;
            patternFactory = new PatternFactory(content);
        }

        public void Update(double time)
        {
            foreach (Projectile proj in friendlyProjectiles)
            {
                proj.Move(time - prevUpdate);
            }
            foreach (Projectile proj in hostileProjectiles)
            {
                proj.Move(time - prevUpdate);
            }
            Spawn(time);
            prevUpdate = time;
        }

        private void Spawn(double time)
        {
            if (player.ShootCheck(time))
                friendlyProjectiles.AddRange(patternFactory.Create(player.PatternType, player.ProjectileType, player.Position + player.Size / 2, player.Position + player.Size / 2));

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].ShootCheck(time))
                {
                    hostileProjectiles.AddRange(patternFactory.Create(enemies[i].PatternType, enemies[i].ProjectileType, enemies[i].Position + enemies[i].Size / 2, player.Position + player.Size / 2, enemies[i].SequenceCount()));
                }
            }
        }

        public void Reset()
        {
            friendlyProjectiles.Clear();
            hostileProjectiles.Clear();
            prevUpdate = 0;
        }
    }
}
