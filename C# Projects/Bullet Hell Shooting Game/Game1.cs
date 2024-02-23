using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Bullet_Hell_Shooting_Game.Enemies;
using Bullet_Hell_Shooting_Game.Projectiles;

using Bullet_Hell_Shooting_Game.Patterns;
using Bullet_Hell_Shooting_Game.PowerUps;
using Bullet_Hell_Shooting_Game.Content.Engine.Interpreters;
using Bullet_Hell_Shooting_Game.Managers;
using Bullet_Hell_Shooting_Game.Menus;
using Bullet_Hell_Shooting_Game.Content.Engine;

namespace Bullet_Hell_Shooting_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Player player;
        private Settings settings;
        private Keybinds keybinds;

        private SpriteFont font;

        private double previousUpdate = 0;
        private double lastReset = 0;

        private List<Entity> enemies;
        private List<Projectile> hostileProjectiles;
        private List<Projectile> friendlyProjectiles;
        private List<PowerUp> powerUps;


        private float spawn = 0;
        private bool menuOpen = true;
        private MainMenu menu;
        private Background background;

        private EnemyManager enemyManager;
        private ProjectileManager projectileManager;
        private PowerUpManager powerUpManager;
        private CollisionManager collisionManager;
        //private Wave currentWave;
        public static readonly Vector2[] GameLimits = new Vector2[] { new Vector2(730, 810), new Vector2(-30, -30) };

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Globals.screenSize = new Vector2(700, 800);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        public Settings LoadJson()
        {
            this.keybinds = new Keybinds();
            Input._Keybinds = keybinds;

            PlayerInterpreter playerInterpreter = JsonSerializer.Deserialize<PlayerInterpreter>(File.ReadAllText("../../../Content/Engine/Player.json"));
            PatternInfo temp = new PatternInfo();
            temp.projectilePattern = playerInterpreter.player["PatternType"];
            temp.projectileType = playerInterpreter.player["ProjectileType"];
            playerInterpreter.patterns = new List<PatternInfo>();
            playerInterpreter.patterns.Add(temp);
            player = new Player(playerInterpreter.player, Content, playerInterpreter.patterns);

            _graphics.PreferredBackBufferWidth = 700;// GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = 800;// GraphicsDevice.DisplayMode.Height;
            _graphics.ApplyChanges();

            return settings;
        }

        protected override void LoadContent()
        {
            this.settings = LoadJson();
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            enemies = new List<Entity>();
            hostileProjectiles = new List<Projectile>();
            friendlyProjectiles = new List<Projectile>();
            powerUps = new List<PowerUp>();

            enemyManager = new EnemyManager(Content, enemies);
            projectileManager = new ProjectileManager(friendlyProjectiles, hostileProjectiles, enemies, player, Content);
            powerUpManager = new PowerUpManager(player, powerUps, Content);
            collisionManager = new CollisionManager(player, enemies, hostileProjectiles, friendlyProjectiles);
            font = Content.Load<SpriteFont>("Time");
            menu = new MainMenu(Content);
            background = new Background(Content);

        }
        protected override void Update(GameTime gameTime)
        {
            if (player.IsDead())
            {
                player.Die();
                projectileManager.Reset();
                if (player.IsGameOver())
                    menuOpen = true;
                
            }
            if (menuOpen)
            {
                int choice = menu.Update(gameTime);
                if (choice == 0)
                {
                    menuOpen = false;
                    Restart(gameTime);
                }
                else if (choice == 2)
                {
                    player.MakeInvulnerable(-1);
                    menuOpen = false;
                    Restart(gameTime);
                }
                base.Update(gameTime);
                return;
            }

            double time = gameTime.TotalGameTime.TotalSeconds - lastReset;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Updates player
            player.Update(time - previousUpdate);

            enemyManager.Update(time);
            projectileManager.Update(time);
            powerUpManager.Update(time);

            collisionManager.Update(time);
            
            this.previousUpdate = time;
            collisionManager.Deleter();
            enemyManager.Deleter(); 
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            if (menuOpen)
            {
                GraphicsDevice.Clear(Color.Black);
                menu.Draw(_spriteBatch);
                _spriteBatch.End();
                base.Draw(gameTime);
                return;
            }

            GraphicsDevice.Clear(Color.CornflowerBlue);

            background.Draw(_spriteBatch, gameTime.ElapsedGameTime.TotalSeconds);

            _spriteBatch.Draw(player.Texture, player.Position, player.Invulnerable ? Color.Red : Color.White); // Draws the player.
            _spriteBatch.Draw(player.HealthTexture, player.HealthRectangle, Color.White); // Draws the health bar.
            _spriteBatch.Draw(player.HealthTexture, player.InnerHealthRectangle, Color.Red); 
            // Draws all enemies in enemy list.
            for (int i = 0; i < enemies.Count; i++)
            {
                _spriteBatch.Draw(enemies[i].Texture, enemies[i].Position, Color.White);
            }

            // Draws all projectiles in projectile list.
            for (int i = 0; i < friendlyProjectiles.Count; i++)
            {
                _spriteBatch.Draw(friendlyProjectiles[i].Texture, friendlyProjectiles[i].Position, Color.White);
            }
            for (int i = 0; i < hostileProjectiles.Count; i++)
            {
                _spriteBatch.Draw(hostileProjectiles[i].Texture, hostileProjectiles[i].Position, Color.White);
            }

            for (int i = 0; i < powerUps.Count; i++)
                _spriteBatch.Draw(powerUps[i].Texture, powerUps[i].Position, Color.White);

            _spriteBatch.DrawString(font, "time: " + Math.Round((gameTime.TotalGameTime.TotalSeconds-lastReset),2) + " | " + (friendlyProjectiles.Count + hostileProjectiles.Count) + " | " + spawn, new Vector2(350, 10), Color.Black);
            _spriteBatch.DrawString(font, "lives: " + (player.Lives + 1), new Vector2(350, 25), Color.Black);


            _spriteBatch.End();

            base.Draw(gameTime);
        }




        private void Restart(GameTime gameTime)
        {
            player.Reset();
            enemyManager.Reset();
            projectileManager.Reset();
            powerUpManager.Reset();

            lastReset = gameTime.TotalGameTime.TotalSeconds;
            previousUpdate = 0;
        }
    }
}
