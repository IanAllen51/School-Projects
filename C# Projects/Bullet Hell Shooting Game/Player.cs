using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Bullet_Hell_Shooting_Game.Enemies;
using System.Timers;
using System;
using Bullet_Hell_Shooting_Game.Content.Engine;

namespace Bullet_Hell_Shooting_Game
{
    public class Player : Entity
    {
        private int lives;
        private int startLives;
        private Texture2D healthTexture;
        private Rectangle healthRectangle = new Rectangle(530,10,160,25);
        private Rectangle innerHealthRectangle;
        private Input input;
        private Timer invulTimer;
        private float defaultAttackSpeed;
        public Rectangle InnerHealthRectangle { get => innerHealthRectangle; }
        public Rectangle HealthRectangle { get => healthRectangle; }
        public Texture2D HealthTexture { get => healthTexture; }
        public int Lives { get => lives; }
        public float AttackSpeed { get => defaultAttackSpeed; }
        private float currentAttackSpeed;


        
        public Player(Dictionary<string, string> settings, ContentManager content, List<PatternInfo> patterns) : base(content, settings, patterns)
        {
            startLives = int.Parse(settings["Lives"]);
            defaultAttackSpeed = float.Parse(settings["AttackSpeed"]);
            currentAttackSpeed = defaultAttackSpeed;
            input = new Input();
            lives = startLives;
            healthTexture = content.Load<Texture2D>(settings["HealthTexture"]);
            innerHealthRectangle = new Rectangle(healthRectangle.X, healthRectangle.Y, healthRectangle.Width, healthRectangle.Height);
            invulTimer = new Timer();
            invulTimer.Elapsed += setInvulnerable;
            
        }
        public void SetAttackSpeed(float atkspeed)
        {
            if (atkspeed > 0)
            {
                currentAttackSpeed = atkspeed;
            }
        }
        public void AddLives(int num)
        {
            lives += num;
        }
        public void MakeInvulnerable(int time)
        {
            if (time == -1)
            {
                invulnerable = true;
                return;
            }
            invulnerable = true;
            invulTimer.Interval = time;
            invulTimer.Start();
        }
        public bool IsGameOver()
        {
            return lives < 0;
        }
        public new void DealDamage(int damage)
        {
            if (this.invulnerable)
                return;
            MakeInvulnerable(1000);
            this.health -= damage;
            updateHealth();
            
        }
        public void Reset()
        {
            lives = startLives;
            health = maxHP;
            ResetPosition();
            updateHealth();
            prevShotTime = 0;
        }
        public new bool ShootCheck(double gametime)
        {
            if (input.GetShotInput() && prevShotTime + currentAttackSpeed < gametime)
            {
                prevShotTime = gametime;
                return true;
            }
            return false;
        }
        public void Die()
        {
            lives--;
            health = maxHP;
            ResetPosition();
            updateHealth();
            MakeInvulnerable(1000);
        }
        private void updateHealth()
        {
            float percentage = (float)(this.health) / this.maxHP;
            innerHealthRectangle.Width = (int)(percentage * (healthRectangle.Width));
        }
        private void setInvulnerable(object sender, ElapsedEventArgs e)
        {
            this.invulnerable = false;
        }
        
    }
}
