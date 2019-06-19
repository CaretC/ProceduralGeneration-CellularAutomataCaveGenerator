using System;

namespace CellularAutomataCaveGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set Console Title
            Console.Title = "Cellular Automata Cave Generator";

            // Class Instances
            Title title = new Title();
            Random randomNumber = new Random();
            RandomCave cave = new RandomCave();
            cave.DebugEnabled = true;

            // Print Welcome Screen
            title.PrintWelcomeScreen();         
            Console.ReadLine();

            // Produce a new Cave Map evey time the enter key is pressed.
            // TODO: Implement something more elegant than this infite loop. A run until Esc key press would be nice.
            while (true)
            {
                int startAliveProbability = randomNumber.Next(20, 35);

                cave.ChanceToStartAlive = startAliveProbability;
                bool[,] caveMap = cave.GenerateCave();
                cave.PrintMap(caveMap);

                Console.ReadLine();
            }


        }


    }
}
