using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "New Level Object", menuName = "Create New Level/Medium")]
public class MediumLevelScriptableObject : ScriptableObject
{
    public bool LevelIsCompleted;
    public Level Level;
    public void Awake()
    {
        if (Level == null)
        {
            Level = new Level(Difficulty.Medium);
        }
    }
}
