using System;
using System.Text;
using System.Diagnostics;

namespace CellularAutomataCaveGenerator
{
    class RandomCave
    {
        // ======= Properties =======
        // Toggle Debug output. Default is false.
        public bool DebugEnabled { get; set; } = false;

        // Probibility that cell will initially be spawned 'alive'. Default is 29% (29). 
        private int chanceToStartAlive = 27;
        public int ChanceToStartAlive
        {
            get { return chanceToStartAlive; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    chanceToStartAlive = value;
                }

                else
                {
                    
                }

            }
        }

        // Sets the number of 'alive neighbours' a 'dead' cell needs to be 'born'. Default is 2.
        public int BirthLimit { get; set; } = 2;

        // Sets the number of 'alive neighbours' an 'alive' cell needs to be 'killed'. Default is 6.
        public int DeathLimit { get; set; } = 6;

        // Sets how many times simulationStep() will be run. Default is 2.
        public int SimulationSteps { get; set; } = 2;

        //Sets the color of the cave walls. Default is GREEN.
        public ConsoleColor WallColor { get; set; } = ConsoleColor.Green; 

        // ======= Private Methods =======
        private bool[,] initializeMap()
        {
            // Prints Debug output
            if (DebugEnabled)
            {
                Debug.WriteLine("DEBUG MODE ENABLED");
                Debug.WriteLine(String.Format("DEBUG: Console Size -- {0} x {1}", Console.WindowWidth, Console.WindowHeight));
            }

            // Assisgn a blank 2D bool array the size of the console window. [x,y]
            bool[,] startingMap = new bool[Console.WindowWidth,Console.WindowHeight];
            // Create a random number generator.
            Random randomNumber = new Random();

            // Loop through every cell in the array and used random number to see if the cell starts 'alive'.
            for (int x = 0; x < startingMap.GetLength(0); x++)
            {
                for (int y = 0; y < startingMap.GetLength(1); y++)
                {
                    // Cell starts alive if random number < ChanceToStartAlive
                    if (randomNumber.Next(0, 100) <= ChanceToStartAlive)
                    {
                        startingMap[x, y] = true;
                    }
                }
            }

            // Return initialised map
            return startingMap;
        }

        // Follow the rules for the cellular automata for one step
        private bool[,] simulationStep(bool[,] oldMap)
        {
            bool[,] newMap = new bool[oldMap.GetLength(0), oldMap.GetLength(1)];

            for (int x = 0; x < oldMap.GetLength(0); x++)
            {
                for (int y = 0; y < oldMap.GetLength(1); y++)
                {
                    int aliveNeighbours = countAliveNeighbours(oldMap, x, y);

                    if (oldMap[x,y])
                    {
                        if ( aliveNeighbours >= DeathLimit)
                        {
                            newMap[x, y] = false;
                        }

                        else
                        {
                            newMap[x, y] = true;
                        }
                    }

                    else
                    {
                        if(aliveNeighbours >= BirthLimit)
                        {
                            newMap[x, y] = true;
                        }

                        else
                        {
                            newMap[x, y] = false;
                        }
                    }
                }
            }

            return newMap;
        }

        private int countAliveNeighbours(bool[,] map, int xPosition, int yPosition)
        {
            int count = 0;

            // Loop through 8 surrounding neighbours. (Moore Neighborhood)
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int neighbourXPosition = xPosition + i;
                    int neighbourYPosition = yPosition + j;

                    if(i == 0 && j == 0)
                    {
                        // Do nothing, this is the current cell.
                    }
                    else if(isOutOfMapArea(map, neighbourXPosition, neighbourYPosition))
                    {
                        // If a cell is out of bounds increment count. When left like this is helps to fill in map edges.
                        count++;
                    }
                    else if(map[neighbourXPosition, neighbourYPosition])
                    {
                        // If cell is alive increment count.
                        count++;
                    }
                }
            }

            return count;
        }
        
        private bool isOutOfMapArea(bool[,] map, int xPosition, int yPosition)
        {
            bool isOutOfArea;

            //If the position is out of bounds return true.
            if (xPosition < 0 || yPosition < 0 || xPosition > (map.GetLength(0) - 1) || yPosition > (map.GetLength(1) - 1))
            {
                isOutOfArea = true;
            }

            //If the position is in bounds return flase.
            else
            {
                isOutOfArea = false;
            }

            return isOutOfArea;
        }


        // ======= Public Methods =======
        public void PrintMap(bool[,] map)
        {
            Console.Clear();

            Console.ForegroundColor = WallColor;

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y])
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("█");
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }


        public bool[,] GenerateCave()
        {
            bool[,] seedMap = initializeMap();

            // Debug output
            if (DebugEnabled)
            {
                Debug.WriteLine(String.Format("DEBUG: Chance To Start Alive -- {0}%.", ChanceToStartAlive));
                Debug.WriteLine(String.Format("DEBUG: Birth Limit -- {0}.", BirthLimit));
                Debug.WriteLine(String.Format("DEBUG: Birth Limit -- {0}.", DeathLimit));
                Debug.WriteLine(String.Format("DEBUG: Simulation Steps -- {0}.", SimulationSteps));
            }

            for (int step = 0; step < SimulationSteps; step++)
            {
                seedMap = simulationStep(seedMap);

                // Debug output
                if (DebugEnabled)
                {
                    Debug.WriteLine(String.Format("DEBUG: Simulation Step {0} Complete.", (step +1)));
                }
            }

            return seedMap;
        }

    }


}
