using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Level Object", menuName = "Create New Level/Hard")]
public class HardLevelScriptableObject : ScriptableObject
{
    public int levelNumber;
    private Grid grid;
    private int width;
    private int height;

    //Generate a grid passing the dimensions and the difficulty
    public void Awake()
    {
        width = Random.Range(5, 8);
        height = Random.Range(5, 8);

        grid = new Grid(width, height, Difficulty.Hard);
    }

}
