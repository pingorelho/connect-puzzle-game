using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

[System.Serializable]
public class Level{

    public int LevelID;
    public int Width;
    public int Height;
    public int NumberOfSourceDestinationPairs;
    public Difficulty Difficulty;

    public Vector2Int[] LightSources; //To keep track of light sources positions
    public Vector2Int[] Destinations; //To keep track of destinations positions

    public int[,] LevelGrid; //This is the playable gameboard/grid
    
    public Level(Difficulty difficulty)
    {
        Difficulty = difficulty;

        //Set the width, height and number of sources & destinations the level will have depending on the difficulty
        switch (Difficulty)
        {
            case Difficulty.Easy:
                Width = Random.Range(2, 4);
                Height = Random.Range(2, 4);
                NumberOfSourceDestinationPairs = Random.Range(1, 2);
                break;
            case Difficulty.Medium:
                Width = Random.Range(4, 6);
                Height = Random.Range(4, 6);
                NumberOfSourceDestinationPairs = Random.Range(3, 4);
                break;
            case Difficulty.Hard:
                Width = Random.Range(5, 8);
                Height = Random.Range(5, 8);
                NumberOfSourceDestinationPairs = Random.Range(5, 6);
                break;
            default:
                break;
        }

        //Initialize the sources and destinations arrays
        LightSources = new Vector2Int[NumberOfSourceDestinationPairs];
        Destinations = new Vector2Int[NumberOfSourceDestinationPairs];



        //Initialize grid array
        LevelGrid = new int[Width, Height];

        for (int i = 0; i < Width; i++) {
            for (int j = 0; j < Height; j++) {
                //Populate grid with 0s
                LevelGrid[i, j] = 0; 
            }
        }

        //Randomly set the sources and destinations in the grid
        for (int i = 0; i < NumberOfSourceDestinationPairs; i++) {

            int loopBreakout = 0;
            bool sourcePlaced = false;
            while (!sourcePlaced || loopBreakout== 10) {
                loopBreakout++;

                //Pick a random cell on the grid
                Vector2Int randomCell = RandomPairInRange(0, Width - 1, 0, Height - 1);

                //If the cell value is 0 it means it's free to take a light source or destination
                if (LevelGrid[randomCell.x,randomCell.y]==0) {

                    //Set the cell value to the iteration number, placing a light source
                    LevelGrid[randomCell.x, randomCell.y] = i+1;
                    //Add source to light sources array
                    LightSources[i] = randomCell;

                    sourcePlaced = true;

                    //Do the same for destinations
                    bool destinationPlaced = false;
                    int loopBreakout2 = 0;
                    while (!destinationPlaced || loopBreakout2==50) {
                        loopBreakout2++;
                        randomCell = RandomPairInRange(0, Width - 1, 0, Height - 1);

                        if (LevelGrid[randomCell.x, randomCell.y] == 0) {

                            //Set the cell value to -1, placing a destination
                            LevelGrid[randomCell.x, randomCell.y] = -1;
                            //Add destination to destination array 
                            Destinations[i] = randomCell;

                            destinationPlaced = true;
                        }
                    }
                }
            }
        }
    }

    //Return a pair of random ints between a given range
    public Vector2Int RandomPairInRange(int lowerboundX, int upperboundX, int lowerboundY, int upperboundY) {

        Vector2Int randomPair = new Vector2Int() { x = Random.Range(lowerboundX, upperboundX), y = Random.Range(lowerboundY, upperboundY) };

        return randomPair;
    }


    //Check if the level is solvable
    //public bool ValidateGrid(int[,] grid) {
        
    //}

}
