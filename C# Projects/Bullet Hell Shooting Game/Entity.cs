using System;
using System.Collections.Generic;
using System.Text;
using Bullet_Hell_Shooting_Game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bullet_Hell_Shooting_Game.Movements;
using Microsoft.Xna.Framework.Content;
using Bullet_Hell_Shooting_Game.Patterns;
using Bullet_Hell_Shooting_Game.Content.Engine;

namespace Bullet_Hell_Shooting_Game.Enemies
{
    public class Entity
    {

        protected int maxHP;
        protected int health;
        protected Vector2 position;
        protected Texture2D texture;
        protected Vector2 size;
        protected Movement movement;
        protected double prevShotTime;
        protected double shotInterval;
        protected double startShotInterval;
        protected List<ProjectileType> projectileType;
        protected List<PatternType> patternType;
        protected int currentSequencedShotCount = -1;
        protected List<float> sequenceShotInterval;
        protected List<int> sequenceShotCount;
        protected int stepCount;
        protected Vector2 initialPosition;
        protected bool invulnerable = false;

        public bool Invulnerable { get => invulnerable; }
        public Vector2 Position { get => position; }
        public Vector2 Size { get => size; }
        public Texture2D Texture { get => texture; }
        public ProjectileType ProjectileType { get => projectileType[currentPattern]; }
        public PatternType PatternType { get => patternType[currentPattern]; }
        public int StepCount { get; internal set; }
        public int currentPattern = 0;
        public int totalPatterns = 0;

        public Entity(ContentManager content, Dictionary<string, string> entitySettings, List<PatternInfo> patterns)
        {
            this.texture = content.Load<Texture2D>(entitySettings["Texture"]);
            this.initialPosition = new Vector2(Int32.Parse(entitySettings["positionX"]), Int32.Parse(entitySettings["positionY"]));
            ResetPosition();
            this.size = new Vector2(Int32.Parse(entitySettings["sizeX"]), Int32.Parse(entitySettings["sizeY"]));
            this.movement = (new MovementFactory()).Create((MovementType) Enum.Parse(typeof(MovementType), entitySettings ["MovementType"], true), this.position, this.size, Int32.Parse(entitySettings["speed"]));
            this.prevShotTime = float.Parse(entitySettings ["ShotInterval"]);
            this.shotInterval = Double.Parse(entitySettings["ShotInterval"]);
            this.startShotInterval = shotInterval;
            this.health = int.Parse(entitySettings ["Health"]);
            this.maxHP = this.health;

            this.projectileType = new List<ProjectileType>();
            this.patternType = new List<PatternType>();
            this.sequenceShotCount = new List<int>();
            this.sequenceShotInterval = new List<float>();

            for (int i = 0; i < patterns.Count; i++)
            {
                this.projectileType.Add((ProjectileType)Enum.Parse(typeof(ProjectileType), patterns[i].projectileType, true));
                this.patternType.Add((PatternType)Enum.Parse(typeof(PatternType), patterns[i].projectilePattern, true));
                this.sequenceShotInterval.Add(patterns[i].sequenceInterval);
                this.sequenceShotCount.Add(patterns[i].sequenceShotCount);
                totalPatterns++;
            }
        }

        public bool ShootCheck(double gametime)
        {
            if (this.prevShotTime + this.shotInterval < gametime)
            {
                this.prevShotTime = gametime;
                return true;
            }

            return false;
        }

        public int SequenceCount()
        {
            if (sequenceShotCount[currentPattern] == 0) return 0;

            currentSequencedShotCount++;
            if (currentSequencedShotCount == 0)
                this.shotInterval = sequenceShotInterval[currentPattern];
            if (currentSequencedShotCount == sequenceShotCount[currentPattern])
            {
                this.shotInterval = this.startShotInterval;
                currentPattern++;
                if (currentPattern == totalPatterns)
                    currentPattern = 0;
                currentSequencedShotCount = -1;
            }
            return currentSequencedShotCount;
        }

        public void ResetPosition()
        {
            this.position = new Vector2(this.initialPosition.X, this.initialPosition.Y);
        }

        /// <summary>
        /// Subtracts a damage amount from the health of an enemy.
        /// Collision detection not currently implemented so this is unused.
        /// </summary>
        /// <param name="damage">Amount of health to be taken away.</param>
        public void DealDamage(int damage)
        {
            if (invulnerable)
                return;
            this.health -= damage;
        }
        
        public bool IsDead()
        {
            return health <= 0;
        }
        public void Update(double elapsedTime)
        {
            this.position = this.movement.Move(this.position, elapsedTime);
            this.stepCount = this.movement.getStepCount();

        }

        //public abstract Projectile Shoot();
        public bool Deleter()
        {
            if (this.position.X > Globals.screenSize.X + 40 || this.position.X < -40 || this.position.Y > Globals.screenSize.Y + 40 || this.position.Y < -300)
                return true;
            return false;
        }

    }
}
