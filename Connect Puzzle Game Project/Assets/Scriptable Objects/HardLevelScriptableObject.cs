using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "New Level Object", menuName = "Create New Level/Hard")]
public class HardLevelScriptableObject : ScriptableObject
{
    public Level Level;
    public void Awake()
    {
        if (Level == null)
        {
            Level = new Level(Difficulty.Hard);
        }
    }
}
