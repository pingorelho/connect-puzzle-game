using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName ="New Level Object", menuName ="Create New Level/Easy")]
public class EasyLevelScriptableObject : Level
{
    public void Awake()
    {

        Difficulty = Difficulty.Easy;

        CreateGrid();
    }

}
