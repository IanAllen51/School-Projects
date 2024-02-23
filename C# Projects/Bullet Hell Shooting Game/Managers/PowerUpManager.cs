using Bullet_Hell_Shooting_Game.PowerUps;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace Bullet_Hell_Shooting_Game.Managers
{
    internal class PowerUpManager
    {
        private List<PowerUp> powerUps;
        private Player player;
        private double prevUpdate = 0;
        private int nextSpawn;
        private PowerUpFactory factory;
        private Random random;

        public PowerUpManager(Player play, List<PowerUp> powerUpList, ContentManager content)
        {
            player = play;
            powerUps = powerUpList;
            factory = new PowerUpFactory(content);
            random = new Random();
            nextSpawn = GetRandomSpawn();
        }

        public void Update(double time)
        {
            for (int i = 0; i < powerUps.Count; i++)
            {
                powerUps[i].Update(time - prevUpdate);
                if (powerUps[i].Activate(player))
                {
                    powerUps.RemoveAt(i);
                    i--;
                }
            }

            if (nextSpawn < time)
            {
                powerUps.Add(factory.Create());
                nextSpawn = (int)(GetRandomSpawn() + time);
            }

            prevUpdate = time;
        }

        private int GetRandomSpawn()
        {
            return random.Next(20, 40);
        }

        public void Reset()
        {
            powerUps.Clear();
            prevUpdate = 0;
        }
    }
}
