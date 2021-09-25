using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {

    private int width;
    private int height;
    private int numberOfSourceDestinationPairs;

    private Vector2Int[] lightSources; //To keep track of light sources positions
    private Vector2Int[] destinations; //To keep track of destinations positions

    private int[,] grid; //This is the playable gameboard/grid



    public Grid(int width, int height,int numberOfSources) {

        this.width = width;
        this.height = height;
        this.numberOfSourceDestinationPairs = numberOfSources;


        lightSources = new Vector2Int[numberOfSourceDestinationPairs];
        destinations = new Vector2Int[numberOfSourceDestinationPairs];

        //Initialize grid
        grid = new int[width, height];

        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                //Populate grid with 0s
                grid[i, j] = 0; 
            }
        }

        //Randomly set the sources and destinations in the grid
        for (int i = 0; i < numberOfSourceDestinationPairs; i++) {

            bool sourcePlaced = false;
            while (!sourcePlaced) {
                //Pick a random cell on the grid
                //int x = Random.Range(0, width - 1);
                //int y = Random.Range(0, width - 1);
                //Vector2Int randomCell = new Vector2Int() { x = Random.Range(0, width - 1), y = Random.Range(0, height - 1) };
                Vector2Int randomCell = RandomPairInRange(0, width - 1, 0, height - 1);


                //If the cell value is 0 it means it's free to take a light source or destination
                if (grid[randomCell.x,randomCell.y]==0) {

                    //Set the cell value to the iteration number, placing a light source
                    grid[randomCell.x, randomCell.y] = i+1;
                    //Add source to light sources array
                    lightSources[i] = randomCell;

                    sourcePlaced = true;

                    //Do the same for destinations
                    bool destinationPlaced = false;
                    while (!destinationPlaced) {
                        randomCell = RandomPairInRange(0, width - 1, 0, height - 1);

                        if (grid[randomCell.x, randomCell.y] == 0) {

                            //Set the cell value to -1, placing a destination
                            grid[randomCell.x, randomCell.y] = -1;
                            //Add destination to destination array 
                            destinations[i] = randomCell;

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



    //public bool ValidateGrid(int[,] grid) {
        
    //}

}
