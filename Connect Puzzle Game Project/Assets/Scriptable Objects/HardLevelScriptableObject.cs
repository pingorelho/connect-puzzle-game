using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Level Object", menuName = "Create New Level/Hard")]
public class HardLevelScriptableObject : Level
{
    public void Awake()
    {

        Difficulty = Difficulty.Hard;

        CreateGrid();
    }


}
