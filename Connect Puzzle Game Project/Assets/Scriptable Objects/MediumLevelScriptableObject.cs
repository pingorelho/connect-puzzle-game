using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Level Object", menuName = "Create New Level/Medium")]
public class MediumLevelScriptableObject : Level
{
    public void Awake()
    {

        Difficulty = Difficulty.Medium;

        CreateGrid();
    }


}
