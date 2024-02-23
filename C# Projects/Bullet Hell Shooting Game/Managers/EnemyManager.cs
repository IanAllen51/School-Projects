using System;
using System.Collections.Generic;
using System.Text;
using Bullet_Hell_Shooting_Game.Movements;
using Bullet_Hell_Shooting_Game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.IO;
using System.Text.Json;
using Bullet_Hell_Shooting_Game.Content.Engine;
using static Bullet_Hell_Shooting_Game.Content.Engine.StageInterpreter;
using static Bullet_Hell_Shooting_Game.Content.Engine.EnemyInterpreter;

namespace Bullet_Hell_Shooting_Game.Enemies
{
    public class EnemyManager
    {
        private StageInterpreter stageInterpreter;
        private EnemyInterpreter enemyInterpreter;
        private EnemyFactory enemyFactory;
        private ContentManager contentManager;
        private List<Entity> enemies;
        private List<Dictionary<string, string>> loadedWaves;
        private string folderPath;
        private string currentFile;
        private int currentStage;
        private int stageStartTime;
        private bool finished = false;
        private double prevUpdate = 0;
        bool isTest = true; // True to run test file. False to run normally

        public EnemyManager(ContentManager Content, List<Entity> enemyList)
        { 
            contentManager = Content;
            enemies = enemyList;
            enemyFactory = new EnemyFactory(Content);
            loadedWaves = new List<Dictionary<string, string>>();

            folderPath = "../../../Content/Engine/";
            if (isTest)
                currentFile = "Test.json";
            else
                currentFile = "Stage1.json";
            string data = File.ReadAllText(folderPath + currentFile);
            stageInterpreter = JsonSerializer.Deserialize<StageInterpreter>(data);
            data = File.ReadAllText(folderPath + "Enemies.json");
            enemyInterpreter = JsonSerializer.Deserialize<EnemyInterpreter>(data);


            currentStage = 0;
            stageStartTime = 0;
            LoadStage(0);
        }

        public void Update(double time)
        {
            UpdateEnemy(time);
            if (finished)
                return;
            foreach (KeyValuePair<string, StageInterpreter.Stage> wave in stageInterpreter.stage)
            {
                if ((wave.Value.currentCount < wave.Value.enemyAmount) && (wave.Value.time < time))
                {
                    if (time - wave.Value.lastSpawn > wave.Value.interval)
                    {
                        CreateEntitySettings(wave);
                        enemies.Add(enemyFactory.SpawnEnemy(enemyInterpreter.enemies[wave.Value.enemyType], enemyInterpreter.patterns));
                        wave.Value.lastSpawn = time;
                        wave.Value.currentCount++;
                    }
                }
                else if (wave.Value.duration + stageStartTime > (int)time)
                {
                    LoadStage(time);
                }
            }

          //  Spawn(time);
            

        }
        //deletes enemies offscreen
        public void Deleter()
        {
            for (int i = 0; i < this.enemies.Count; i++)
            {
                if (this.enemies[i].Deleter())
                    this.enemies.RemoveAt(i);
            }
        }
        private void UpdateEnemy(double time)
        {
            foreach (Entity enemy in enemies)
            {
                enemy.Update(time - prevUpdate);
            }
            prevUpdate = time;
        }


        private void CreateEntitySettings(KeyValuePair<string, StageInterpreter.Stage> wave)
        {
            enemyInterpreter.patterns = new List<PatternInfo>();
            foreach (KeyValuePair<string, PatternInfo> pattern in wave.Value.patterns)
            {
                enemyInterpreter.patterns.Add(pattern.Value);
            }

            enemyInterpreter.enemies[wave.Value.enemyType]["positionX"] = (wave.Value.positionX + wave.Value.offsetX * wave.Value.currentCount).ToString();
            enemyInterpreter.enemies[wave.Value.enemyType]["positionY"] = (wave.Value.positionY + wave.Value.offsetY * wave.Value.currentCount).ToString();

            enemyInterpreter.enemies[wave.Value.enemyType]["speed"] = wave.Value.speed.ToString();

        }


        private void IncreaseStageCount()
        {
            currentStage++;
            currentFile = "Stage" + currentStage + ".json";
        }

        private void LoadStage(double time)
        {
            IncreaseStageCount();
            string data;
            try
            {
                data = File.ReadAllText(folderPath + currentFile);
            }
            catch
            {
                finished = true;
                return;
            }

            stageStartTime = (int)time + 1;
            stageInterpreter = JsonSerializer.Deserialize<StageInterpreter>(data);
        }

        public void Reset()
        {
            currentStage = 1;
            enemies.Clear();
            if (isTest)
                currentFile = "Test.json";
            else
                currentFile = "Stage1.json";
            stageStartTime = 0;
            string data = File.ReadAllText(folderPath + currentFile);
            stageInterpreter = JsonSerializer.Deserialize<StageInterpreter>(data);
            finished = false;
        }
    }
}

