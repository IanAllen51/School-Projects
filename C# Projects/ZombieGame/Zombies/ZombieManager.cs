using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Factories;

namespace ZombieGame.Zombies
{
    class ZombieManager : Zombie
    {
        private ZombieFactory rFact = new RegularFactory();
        private ZombieFactory cFact = new ConeFactory();
        private ZombieFactory bFact = new BucketFactory();
        private ZombieFactory sFact = new ScreenFactory();
        private ZombieFactory dFact = new DemotedFactory();

        private List<Zombie> zombieList = new List<Zombie>();

        public ZombieManager() { }

        public override void takeDamage(int d)
        {
            zombieList[0].takeDamage(d);
        }

        public override string getInfo()
        {
            string info = "[";
            foreach(Zombie z in zombieList)
            {
                info += z.getInfo() + ", ";
            }
            info += "]";
            return info;
        }

        public void addZombie(char response)
        {
            switch(response)
            {
                case '1':
                    zombieList.Add(rFact.buildZombie());
                    break;
                case '2':
                    zombieList.Add(cFact.buildZombie());
                    break;
                case '3':
                    zombieList.Add(bFact.buildZombie());
                    break;
                case '4':
                    zombieList.Add(sFact.buildZombie());
                    break;
                default:
                    break;
            }
        }

        public void runWave(int damage)
        {
            int counter = 0;
            Console.WriteLine("Round {0}: " + getInfo(), counter);
            while(zombieList.Count >= 1)
            {
                counter++;
                takeDamage(damage);
                if (isAlive() == false)
                {
                    removeZombie();
                }
                else if (getZombieType() != "R" && hasAccessory() == false)
                {
                    demoteZombie();
                }
                if(zombieList.Count == 0)
                {
                    Console.WriteLine("[]");
                }
                else
                {
                    Console.WriteLine("Round {0}: " + getInfo(), counter);
                }
            }
        }

        public void demoteZombie()
        {
            int temp = getHealth();
            removeZombie();
            zombieList.Insert(0, dFact.buildZombie(temp));
        }

        public void removeZombie()
        {
            zombieList.RemoveAt(0);
        }

        public override int getHealth()
        {
            return zombieList[0].getHealth(); 
        }

        public override bool isAlive()
        {
            return zombieList[0].isAlive();
        }

        public override bool hasAccessory() 
        {
            return zombieList[0].hasAccessory(); 
        }

        public void clearZombieList()
        {
            zombieList.Clear();
        }

        public override string getZombieType()
        {
            return zombieList[0].getZombieType();
        }

        //NOT USED DIRECTLY IN Mangager
        public override void die() { }
        
        
        


    }
}
