using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGameDecorator
{
    class GameObjectManager
    {
        List<zObj> enemies = new List<zObj>();
        zombieFactory zFac = new zombieFactory();

        //insert zombies
        public void addZombie(int num)
        {
            enemies.Add(zFac.createZombie(num));
        }

        public List<zObj> getList()
        {
            return enemies;
        }

        public int size() 
        {
            return enemies.Count;
        }
    
        public void display()
        {

            string wave = "[";
            foreach(zObj zombie in enemies)
            {
                wave += zombie.getType() + zombie.getHealth().ToString() + ", ";
            }
            wave += "]";
            Console.WriteLine(wave);
            
        }


        //TODO: Observer Pattern related attributes and methods.
        public void checkUpdates()
        {
            
            for (int i = 0; i < enemies.Count; i++)
            {
                if(enemies[i].update() == true)
                {
                    if (enemies[i].getObjectHealth() > 0)
                    {
                        enemies.RemoveAt(i);
                    }
                    else if (enemies[i].getObjectHealth() <= 0 && enemies[i].getHealth() > 0)
                    {
                        int temp = enemies[i].getHealth();
                        enemies.RemoveAt(i);
                        enemies.Insert(i, zFac.createZombie(1));
                        enemies[i].takeDamage(50-temp);
                    }
                    else if(enemies[i].getObjectHealth() <= 0 && enemies[i].getObjectHealth() <= 0)
                    {
                        enemies.RemoveAt(i);
                    }
                }
                
            }

        }
    }
}
