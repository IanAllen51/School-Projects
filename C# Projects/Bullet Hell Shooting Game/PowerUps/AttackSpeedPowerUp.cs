using Bullet_Hell_Shooting_Game.Movements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Bullet_Hell_Shooting_Game.PowerUps
{
    internal class AttackSpeedPowerUp : PowerUp
    {
        public AttackSpeedPowerUp(ContentManager content) : base()
        {
            texture = content.Load<Texture2D>("AttackSpeedPowerUp");

        }

        public override bool Activate(Player player)
        {
            Vector2 playerPos = player.Position;
            Vector2 playerSize = player.Size;
            if (playerPos.X + playerSize.X > position.X && position.X + size.X > playerPos.X && playerPos.Y + playerSize.Y > position.Y && position.Y + size.Y > playerPos.Y)
            {
                player.SetAttackSpeed(player.AttackSpeed / 4);
                Timer timer = new Timer(5000);
                timer.Elapsed += (sender, e) => { player.SetAttackSpeed(player.AttackSpeed); };
                timer.Start();
                return true;
            }

            return false;
        }
        private void setAttackSpeed(object sender, ElapsedEventArgs e, Player p)
        {
            p.SetAttackSpeed(p.AttackSpeed);
        }
    }
}
