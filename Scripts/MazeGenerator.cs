/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Range(5, 500)]
    public int mazeWidth = 5, mazeHeight = 5;       // dimensions of maze
    public int startX, startY;                      // position our algorithm will start from
    MazeCell[,] maze;                               // array of maze cells representing the maze grid.

    Vector2Int currentCell;

    public MazeCell [,] GetMaze()
    {
        maze = new MazeCell[mazeWidth, mazeHeight];

        for (int x = 0; x < mazeWidth; x++)
        {
            for(int y = 0; y < mazeHeight; y++)
            {
                maze[x, y] = new MazeCell(x,y);
            }
        }
        CarvePath(startX, startY);

        return maze;
    }

    List<Direction> directions = new List<Direction>
    {
        Direction.Up, Direction.Down, Direction.Left, Direction.Right,
    };

    List<Direction> GetRandomDirections()
    {
        // make a copy of our directions list that we can mess around with
        List<Direction> dir = new List<Direction>(directions);       

        // make a directions list to put our randomised directions into 
        List<Direction> rndDir = new List<Direction>();

        while (dir.Count > 0)                           // loop until our rndDir list is empty
        {

            int rnd = Random.Range(0, dir.Count);       // get random index in list
            rndDir.Add(dir[rnd]);                       // add the random direction to our list 
            dir.RemoveAt(rnd);                          // remove that direction so we can't choose it again

        } 

        // when we've got all four directions in a random order, return the queue 
        return rndDir;
    
    }

    bool isCellValid (int x, int y)
    {

        // if the cell is outside of the map or has already been visited, we consider it not valid.
        if (x < 0 || y < 0 || x > mazeWidth - 1 || y > mazeHeight - 1 || maze[x,y].visited) return false;
        else return true;


    }



    Vector2Int CheckNeighbors ()
    {
        List<Direction> rndDir = GetRandomDirections();

        for (int i = 0; i < rndDir.Count; i++)
        {

            // set neighbor coordinates to current cell for now.
            Vector2Int neighbor = currentCell;

             //modify neighbor coordinates based on the random directions we're currently trying 
            switch (rndDir[i])
             {
            
                case Direction.Up:
                    neighbor.y++;
                    break;
                case Direction.Down:
                    neighbor.y--;
                    break;
                case Direction.Right:
                    neighbor.x++;
                    break;
                case Direction.Left:
                    neighbor.x--;
                    break;    

            }   

            // if neighbor we just tried is valid, we can return that neighbor. if not, we go again
            if (isCellValid(neighbor.x, neighbor.y)) return neighbor;
        
        }
  
        //if we tried all directions and didn't find a valid neighbor, we return the currentCell values
        return currentCell;
  
    }


    //take in two maze poitions and sets the cells accordingly
    void BreakWalls (Vector2Int primaryCell, Vector2Int secondaryCell) 
    {

        //we can only go in one direction at a time so we can handle this using if else statements
        if (primaryCell.x > secondaryCell.x)                            //primary cell's left wall
        {
           maze[primaryCell.x, secondaryCell.y].leftWall = false;
        }
        else if (primaryCell.x < secondaryCell.x)                       //secondary cell's left wall
        {
            maze[secondaryCell.x, secondaryCell.y].leftWall = false;
        }
        else if (primaryCell.y < secondaryCell.y)                       //primary cell's top wall
        {
            maze[primaryCell.x, secondaryCell.y].topWall = false;
        }
        else if (primaryCell.y > secondaryCell.y)                       // secondary cell's top wall
        {
            maze[secondaryCell.x, secondaryCell.y].topWall = false;
        }
    }

    //starting at the x, y passed in, carves a path through the maze until it ecounters a "dead end"
    //dead end = cell with no valid neighbors
    void CarvePath (int x, int y)
    {

        //perform a aquick check to make sure our start position is within the boundaries of the map,
        //if not, set them to a default (i am using 0) and throw a little warning up
        if (x < 0 || y < 0 || x > mazeWidth - 1 || y > mazeHeight - 1 ) 
        {
            x = y = 0;
            Debug.LogWarning("Starting position is out of bounds, default to 0, 0");
        }

        // set current cell to the starting position we were passed.
        currentCell = new Vector2Int(x, y);

        //a list to keep track of our current path
        List<Vector2Int> path = new List<Vector2Int>();

        // loop until we encounter a dead end.
        bool deadEnd = false;
        while (!deadEnd)
        {
            //get the next cell we are going to try
            Vector2Int nextCell = CheckNeighbors();
        
            //if that cell has no valid neighbors, set deadend to true so we break out of the loop
            if (nextCell == currentCell)
            {

                //if that cell has no valid neighbors, set deadend to true so we break out of the loop
                for (int i = path.Count - 1; i >= 0; i--)
                {
                
                    currentCell = path[i];                  //set currentcell to the next step back along our path
                    path.RemoveAt(i);                       //remove this step from the path
                    nextCell = CheckNeighbors();            //check that cell to see if any other neighbors are valid

                    //if we find a valid neighbor, break out of the loop
                    if (nextCell != currentCell) break;
                }

                if (nextCell == currentCell)
                    deadEnd = true;

            }    
            
            else
            {
                BreakWalls(currentCell, nextCell);                  // set wall flags on these two cells
                maze[currentCell.x, currentCell.y].visited = true;  // set cell to visited before moving on.
                currentCell = nextCell;                             // set the current cell to the valid neighbor we found 
                path.Add(currentCell);                              // add this cell to our path


            }   
        }
    }
}

public enum Direction 
{
    Up,
    Down,
    Left,
    Right

}

public class MazeCell 
{

    public bool visited;
    public int x, y;

    public bool topWall;
    public bool leftWall;

    //return x and y as a Vector2Int for conveinience
    public Vector2Int position 
    {
        get 
        {
            return new Vector2Int(x,y);
        }
    }

    public MazeCell (int x, int y)
    {
        // coordinates of this cell in the maze grid.
        this.x = x;
        this.y = y;

        //whether the algorithim has visited this cell or not - false to start
        visited = false;

        //all wlls are presenet until the algorithm remives them
        topWall = leftWall = true;
    }    
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Range(5, 500)]
    public int mazeWidth = 5, mazeHeight = 5;       // dimensions of maze
    public int startX, startY;                      // position our algorithm will start from
    MazeCell[,] maze;                               // array of maze cells representing the maze grid.

    Vector2Int currentCell;

    public MazeCell[,] GetMaze()
    {
        maze = new MazeCell[mazeWidth, mazeHeight];

        for (int x = 0; x < mazeWidth; x++)
        {
            for (int y = 0; y < mazeHeight; y++)
            {
                maze[x, y] = new MazeCell(x, y);
            }
        }
        CarvePath(startX, startY);

        return maze;
    }

    List<Direction> directions = new List<Direction>
    {
        Direction.Up, Direction.Down, Direction.Left, Direction.Right,
    };

    List<Direction> GetRandomDirections()
    {
        // make a copy of our directions list that we can mess around with
        List<Direction> dir = new List<Direction>(directions);

        // make a directions list to put our randomised directions into 
        List<Direction> rndDir = new List<Direction>();

        while (dir.Count > 0)                           // loop until our rndDir list is empty
        {

            int rnd = Random.Range(0, dir.Count);       // get random index in list
            rndDir.Add(dir[rnd]);                       // add the random direction to our list 
            dir.RemoveAt(rnd);                          // remove that direction so we can't choose it again

        }

        // when we've got all four directions in a random order, return the queue 
        return rndDir;

    }

    bool IsCellValid(int x, int y)
    {

        // if the cell is outside of the map or has already been visited, we consider it not valid.
        if (x < 0 || y < 0 || x > mazeWidth - 1 || y > mazeHeight - 1 || maze[x, y].visited) return false;
        else return true;


    }



    Vector2Int CheckNeighbors()
    {
        List<Direction> rndDir = GetRandomDirections();

        for (int i = 0; i < rndDir.Count; i++)
        {

            // set neighbor coordinates to current cell for now.
            Vector2Int neighbor = currentCell;

            //modify neighbor coordinates based on the random directions we're currently trying 
            switch (rndDir[i])
            {

                case Direction.Up:
                    neighbor.y++;
                    break;
                case Direction.Down:
                    neighbor.y--;
                    break;
                case Direction.Right:
                    neighbor.x++;
                    break;
                case Direction.Left:
                    neighbor.x--;
                    break;

            }

            // if neighbor we just tried is valid, we can return that neighbor. if not, we go again
            if (IsCellValid(neighbor.x, neighbor.y)) return neighbor;

        }

        //if we tried all directions and didn't find a valid neighbor, we return the currentCell values
        return currentCell;

    }


    //take in two maze poitions and sets the cells accordingly
    void BreakWalls(Vector2Int primaryCell, Vector2Int secondaryCell)
    {

        //we can only go in one direction at a time so we can handle this using if else statements
        if (primaryCell.x > secondaryCell.x)                            //primary cell's left wall
        {
            maze[primaryCell.x, primaryCell.y].leftWall = false;
        }
        else if (primaryCell.x < secondaryCell.x)                       //secondary cell's left wall
        {
            maze[secondaryCell.x, secondaryCell.y].leftWall = false;
        }
        else if (primaryCell.y < secondaryCell.y)                       //primary cell's top wall
        {
            maze[primaryCell.x, primaryCell.y].topWall = false;
        }
        else if (primaryCell.y > secondaryCell.y)                       // secondary cell's top wall
        {
            maze[secondaryCell.x, secondaryCell.y].topWall = false;
        }
    }

    //starting at the x, y passed in, carves a path through the maze until it ecounters a "dead end"
    //dead end = cell with no valid neighbors
    void CarvePath(int x, int y)
    {

        //perform a aquick check to make sure our start position is within the boundaries of the map,
        //if not, set them to a default (i am using 0) and throw a little warning up
        if (x < 0 || y < 0 || x > mazeWidth - 1 || y > mazeHeight - 1)
        {
            x = y = 0;
            Debug.LogWarning("Starting position is out of bounds, default to 0, 0");
        }

        // set current cell to the starting position we were passed.
        currentCell = new Vector2Int(x, y);

        //a list to keep track of our current path
        List<Vector2Int> path = new List<Vector2Int>();

        // loop until we encounter a dead end.
        bool deadEnd = false;
        while (!deadEnd)
        {
            //get the next cell we are going to try
            Vector2Int nextCell = CheckNeighbors();

            //if that cell has no valid neighbors, set deadend to true so we break out of the loop
            if (nextCell == currentCell)
            {

                //if that cell has no valid neighbors, set deadend to true so we break out of the loop
                for (int i = path.Count - 1; i >= 0; i--)
                {

                    currentCell = path[i];                  //set currentcell to the next step back along our path
                    path.RemoveAt(i);                       //remove this step from the path
                    nextCell = CheckNeighbors();            //check that cell to see if any other neighbors are valid

                    //if we find a valid neighbor, break out of the loop
                    if (nextCell != currentCell) break;
                }

                if (nextCell == currentCell)
                    deadEnd = true;

            }

            else
            {
                BreakWalls(currentCell, nextCell);                  // set wall flags on these two cells
                maze[currentCell.x, currentCell.y].visited = true;  // set cell to visited before moving on.
                currentCell = nextCell;                             // set the current cell to the valid neighbor we found 
                path.Add(currentCell);                              // add this cell to our path


            }
        }
    }
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right

}

public class MazeCell
{

    public bool visited;
    public int x, y;

    public bool topWall;
    public bool leftWall;

    //return x and y as a Vector2Int for conveinience
    public Vector2Int position
    {
        get
        {
            return new Vector2Int(x, y);
        }
    }

    public MazeCell(int x, int y)
    {
        // coordinates of this cell in the maze grid.
        this.x = x;
        this.y = y;

        //whether the algorithim has visited this cell or not - false to start
        visited = false;

        //all wlls are presenet until the algorithm remives them
        topWall = leftWall = true;
    }
}