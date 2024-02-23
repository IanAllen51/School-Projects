using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Menus
{
    internal class Background
    {
        private Texture2D[] textures = new Texture2D[3];
        private float[] positions = new float[3];

        public Background(ContentManager content)
        {
            positions[0] = 700;
            positions[1] = 0;
            positions[2] = -700;
            textures[0] = content.Load<Texture2D>("Background1");
            textures[1] = content.Load<Texture2D>("Background2");
            textures[2] = content.Load<Texture2D>("Background3");
        }

        public void Draw(SpriteBatch spriteBatch, double elapsedTime)
        {
            for (int i = 0; i < 3; i++)
            {
                spriteBatch.Draw(textures[i], new Vector2(0, positions[i]), Color.White);
                positions[i] += (float)(100 * elapsedTime);
                if (positions[i] > 800)
                    positions[i] -= 1500;
            }
        }
    }
}
