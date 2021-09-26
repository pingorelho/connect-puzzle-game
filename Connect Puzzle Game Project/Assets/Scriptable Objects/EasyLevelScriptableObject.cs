using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName ="New Level Object", menuName ="Create New Level/Easy")]
public class EasyLevelScriptableObject : ScriptableObject
{
    public int levelNumber;
    private Grid grid;
    private int width;
    private int height;

    //Generate a grid passing the dimensions and the difficulty
    public void Awake()
    {
        width = Random.Range(2, 4);
        height = Random.Range(2, 4);

        grid = new Grid(width, height, Difficulty.Easy);
    }

}
