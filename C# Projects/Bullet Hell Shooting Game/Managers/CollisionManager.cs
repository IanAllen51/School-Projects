using Bullet_Hell_Shooting_Game.Enemies;
using Bullet_Hell_Shooting_Game.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game
{

    
    internal class CollisionManager
    {
        private Player player;
        private List<Entity> enemies;
        private List<Projectile> hostileProjectiles;
        private List<Projectile> friendlyProjectiles;

        public CollisionManager(Player p, List<Entity> e, List<Projectile> h, List<Projectile> f)
        {
            player = p;
            enemies = e;
            hostileProjectiles = h;
            friendlyProjectiles = f;
        }
        public void Update(double gameTime)
        {
            CollisionCheck(gameTime);

        }
        public void Deleter()
        {
            deleteProjectiles(hostileProjectiles);
            deleteProjectiles(friendlyProjectiles);

        }
        private void deleteProjectiles(List<Projectile> projectiles)
        {

            for (int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles[i].Position.X > Game1.GameLimits[0].X || projectiles[i].Position.X < Game1.GameLimits[1].X || projectiles[i].Position.Y > Game1.GameLimits[0].Y || projectiles[i].Position.Y < Game1.GameLimits[1].Y)
                {
                    projectiles.RemoveAt(i);
                }
            }

        }
        //Checks if projectiles hit enemies or player.
        private void CollisionCheck(double gameTime)
        {

            for (int k = 0; k < friendlyProjectiles.Count; k++)
            {
                for(int j = 0; j<enemies.Count; j++)
                {
                    if (k >= friendlyProjectiles.Count)
                        return;
                    bool collisionX = enemies[j].Position.X + enemies[j].Size.X >= friendlyProjectiles[k].Position.X && friendlyProjectiles[k].Position.X + friendlyProjectiles[k].Size.X >= enemies[j].Position.X;
                    bool collisionY = enemies[j].Position.Y + enemies[j].Size.Y >= friendlyProjectiles[k].Position.Y && friendlyProjectiles[k].Position.Y + friendlyProjectiles[k].Size.Y >= enemies[j].Position.Y;
                    if (collisionX && collisionY)
                    {
                        enemies[j].DealDamage(friendlyProjectiles[k].Damage);
                        if (enemies[j].IsDead())
                        {
                            enemies.RemoveAt(j);
                        }
                        friendlyProjectiles.RemoveAt(k);
                    }
                }


            }
            for (int i = 0; i < hostileProjectiles.Count; i++)
            {
                bool playerCollisionX = player.Position.X + player.Size.X >= hostileProjectiles[i].Position.X && hostileProjectiles[i].Position.X + hostileProjectiles[i].Size.X >= player.Position.X;
                bool playerCollisionY = player.Position.Y + player.Size.Y >= hostileProjectiles[i].Position.Y && hostileProjectiles[i].Position.Y + hostileProjectiles[i].Size.Y >= player.Position.Y;
                if (playerCollisionX && playerCollisionY)
                {
                    player.DealDamage(hostileProjectiles[i].Damage);

                    hostileProjectiles.RemoveAt(i);
                }
            }
        }
    }

}
