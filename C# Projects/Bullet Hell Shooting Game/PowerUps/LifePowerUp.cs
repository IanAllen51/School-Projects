using Bullet_Hell_Shooting_Game.Movements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.PowerUps
{
    internal class LifePowerUp : PowerUp
    {
        public LifePowerUp(ContentManager content) : base()
        {
            texture = content.Load<Texture2D>("LifePowerUp");
            
        }

        public override bool Activate(Player player)
        {
            Vector2 playerPos = player.Position;
            Vector2 playerSize = player.Size;
            if (playerPos.X + playerSize.X > position.X && position.X + size.X > playerPos.X && playerPos.Y + playerSize.Y > position.Y && position.Y + size.Y > playerPos.Y)
            {
                player.AddLives(1);
                return true;
            }

            return false;
        }
    }
}
