using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGameDecorator
{
    class GameEventManager
    {
        private List<zObj> enemyList = new List<zObj>();

        public GameEventManager(GameObjectManager gom)
        {
            enemyList = gom.getList();
        }

        public void doDamage(int damage, zObj enemy)
        {
            enemy.takeDamage(damage);
        }

        public void doDamageFromAbove(int damage, zObj enemy)
        {
            enemy.takeDamageFromAbove(damage);
        }

        public void applyMagnetForce(zObj enemy)
        {
            if(enemy.getType() == 'B' || enemy.getType() == 'S')
            {
                int temp = enemy.getObjectHealth();
                enemy.takeDamage(temp);
            }
        }

        public void simulateCollisionDetection(int plant)
        {
            switch (plant)
            {
                case 1:
                    doDamage(25,enemyList[0]);
                    break;
                case 2:
                    doDamageFromAbove(40, enemyList[0]);
                    break;
                case 3:
                    applyMagnetForce(enemyList[0]);
                    break;
                default:
                    break;
            }
        }
    }
}
