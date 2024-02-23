using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Bullet_Hell_Shooting_Game.Menus
{
    internal class MainMenu
    {
        private SpriteFont font;
        private Input input = new Input();
        private int option = 0;
        private bool delay = false;
        private int delayValue = 500;
        private ContentManager content;
        double previousPress = 0;

        public MainMenu(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("Time");
            content = Content;
        }

        public int Update(GameTime gameTime)
        {

            int move = (int)input.GetMoveInput().Y;
            if (move != 0 && gameTime.TotalGameTime.TotalSeconds > previousPress + .2)
            {

                previousPress = gameTime.TotalGameTime.TotalSeconds;

                if (move == -1)
                    option--;
                else if (move == 1)
                    option++;
                if (option > 2)
                    option = 0;
                if (option < 0)
                    option = 2;
            }
            if (input.GetShotInput())
            {
                switch(option)
                {
                    case 0:
                        return 0;
                    case 1:
                        Environment.Exit(0);
                        break;
                    case 2:
                        return 2;

                        
                }
            }
            return 3;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(font, "Bullet Hell Game", new Vector2(170, 100), Color.White, 0, Vector2.One, 3, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, "Start", new Vector2(300, 200), option==0 ? Color.Red : Color.White, 0, Vector2.One, 2, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, "Quit", new Vector2(305, 300), option==1 ? Color.Red : Color.White, 0, Vector2.One, 2, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, "Test", new Vector2(305, 400), option==2 ? Color.Red : Color.White, 0, Vector2.One, 2, SpriteEffects.None, 1);
        }
    }
}
