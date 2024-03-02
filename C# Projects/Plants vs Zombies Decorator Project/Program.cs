using System;
using System.Collections.Generic;

namespace ZombieGameDecorator
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To ZombieGame2");
            Console.WriteLine();
            string input;
            GameObjectManager GOM = new GameObjectManager();
            GameEventManager GEM = new GameEventManager(GOM);
            do {
                Console.WriteLine("1. CreateZombies?");
                Console.WriteLine("2. Demo game play.");
                Console.WriteLine("Enter q to exit");

                input = Console.ReadLine();
                if (input == "1")
                {
                    string waveInput;
                    Console.WriteLine("Which kind?");
                    Console.WriteLine("1. Regular");
                    Console.WriteLine("2. Cone");
                    Console.WriteLine("3. Bucket");
                    Console.WriteLine("4. ScreenDoor");
                    waveInput = Console.ReadLine();
                    foreach (char c in waveInput)
                    {
                        GOM.addZombie(int.Parse(c.ToString()));   
                    }
                    Console.WriteLine("Upcoming Wave");
                    GOM.display();
                    Console.WriteLine();
                }
                else if (input == "2")
                {
                    do {

                        Console.WriteLine("Select Your Plant:");
                        Console.WriteLine("1. Peashooter");
                        Console.WriteLine("2. Watermelon");
                        Console.WriteLine("3. Magnet");
                        Console.WriteLine("Enter q to exit");
                        input = (Console.ReadLine());
                        if(input == "q")
                        {
                            continue;
                        }
                        int attack = int.Parse(input);
                        GEM.simulateCollisionDetection(attack);
                        GOM.checkUpdates();
                        GOM.display();

                    } while (input != "q" && GOM.size() != 0);
                    
                    
                }
                
            } while (input != "q");

            Console.WriteLine();
            Console.WriteLine("Good Bye");
        }
    }
}
