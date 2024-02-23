using Bullet_Hell_Shooting_Game.Enemies;
using Bullet_Hell_Shooting_Game.Movements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Bullet_Hell_Shooting_Game.PowerUps
{
    internal abstract class PowerUp
    {
        public PowerUp()
        {
            Random random = new Random();
            position = new Vector2(random.Next(50, 650), -10);
            size = new Vector2(20, 20);
            movement = new MovementFactory().Create(MovementType.CUSTOM, position, size, new Vector2(0, 200));
        }
        protected Movement movement;
        protected Texture2D texture;
        protected Vector2 size;
        protected Vector2 position;
        public Vector2 Position { get { return position; } }
        public Texture2D Texture { get { return texture; } }

        public abstract bool Activate(Player player);
        public void Update(double elapsedTime)
        {
            this.position = this.movement.Move(this.position, elapsedTime);
        }


    }
}
