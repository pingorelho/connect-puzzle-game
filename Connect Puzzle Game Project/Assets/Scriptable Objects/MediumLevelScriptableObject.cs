using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Level Object", menuName = "Create New Level/Medium")]
public class MediumLevelScriptableObject : ScriptableObject
{
    public int levelNumber;
    private Grid grid;
    private int width;
    private int height;

    //Generate a grid passing the dimensions and the difficulty
    public void Awake()
    {
        width = Random.Range(4, 6);
        height = Random.Range(4, 6);

        grid = new Grid(width, height, Difficulty.Medium);
    }

}
