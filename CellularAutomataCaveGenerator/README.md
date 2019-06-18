# CellularAutomataCaveGenerator

This console application is to explore the possibilities of using cellular automata to prcedurally generate a cave like level for a console based game. 


![Initial Cell Map](images\initialCellMap.png)
![Initial Cell Map](images\mooreNeighborhood.png)


# RandomCave Class

## Properties

`ChanceToStartAlive` - Sets the probibility of cells initially spawning *Alive*. (Default **45%**)

`BirthLimit` - Sets the number of *Alive Neighbours* a *Dead* cell needs to be **Born**. (Default **4**)

`DeathLimit` - Sets the number of *Alive Neighbours* an *Alive* cell needs to be **Killed**. (Default **3**)

`SimulationSteps` - Sets how many times `simulationStep()` will be run. (Default **2**)

`WallColor` - Sets the cave wall color. (Default `ConsoleColor.Green`)

## Methods

### initializeMap()

This method is used to create the initial randomized 'cell map'. This cell map consists of randomly assigned 'alive' and 'dead' cells in a map the same 
size as the console window. The probability of a cell being initialized as 'alive' is governed by the `ChanceToSpawnAlive` property. 

```c#
 public bool[,] initializeMap()
        {
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

            // Return initialized map
            return startingMap;
        }
```

### countAliveNeighbours()

This method takes in a map and a position and returns a count of alive neighbours. This check the *Moore  Neighbourhood*, the surrounding 
8 cells. 

```c#
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
                    else if(map[neighbourXPosition, neighbourXPosition])
                    {
                        // If cell is alive increment count.
                        count++;
                    }
                }
            }

            return count;
        }
```
| **NOTE**  | If a cell is *Out of Map Bounds* the count will be incremented. This helps to fill in map edges. Results are quite different without this. |
|-----------|:-------------------------------------------------------------------------------------------------------------------------------------------|

### isOutOfMapArea()

This method take in a map and position and resturns a bool. If the position is within the map area it will return False` and if the point
is outside the map area it will return `True`

```c#
private bool isOutOfMapArea(bool[,] map, int xPosition, int yPosition)
        {
            bool isOutOfArea;

            //If the position is out of bounds return true.
            if (xPosition < 0 || yPosition < 0 || xPosition >= map.GetLength(0) || yPosition >= map.GetLength(1))
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
```

### PrintMap()

This method is used to print the mapto the console. First, the conaole is cleared using `Console.Clear()`. Once the console window has been
cleared the map 2D Array is looped through and each cell checked. If the cell is `True` a `█` character is printed, if `False` the cell is 
left blank.

```C#
public void PrintMap(bool[,] map)
        {
            Console.Clear();

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
        }
```
