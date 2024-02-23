using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Zombies;


namespace ZombieGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ZombieManager zombieWave = new ZombieManager();
            ZombieManager tempHolding = new ZombieManager();
            int damage;
            string input;

            do {
                
                Console.WriteLine("1. CreateZombies?");
                Console.WriteLine("2. Demo game play.");
                Console.WriteLine("Enter q to exit, or r to restart");

                input = Console.ReadLine();
                if(input == "1")
                {
                    string waveInput;
                    Console.WriteLine("Which kind?");
                    Console.WriteLine("1. Regular");
                    Console.WriteLine("2. Cone");
                    Console.WriteLine("3. Bucket");
                    Console.WriteLine("4. ScreenDoor");
                    waveInput = Console.ReadLine();
                    foreach(char c in waveInput)
                    {
                        zombieWave.addZombie(c);
                        tempHolding.addZombie(c);
                    }
                    Console.WriteLine("Upcoming Wave");
                    Console.WriteLine(zombieWave.getInfo());
                    Console.WriteLine();
                }
                else if(input == "2")
                {
                   
                    Console.WriteLine("Please enter damage value. Default is 25");
                    damage = int.Parse(Console.ReadLine());
                    zombieWave.runWave(damage);

                    zombieWave = tempHolding;
                }
                else if(input == "r")
                {
                    zombieWave.clearZombieList();
                    tempHolding.clearZombieList();
                    Console.WriteLine("Wave Cleared");
                }
            
            
            
            } while (input != "q");

            Console.WriteLine("Thank you for Playing");
        
        }
    }    
}
