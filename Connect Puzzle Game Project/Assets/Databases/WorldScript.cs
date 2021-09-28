using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="New World Scriptable Object", menuName ="Create New World")]
public class WorldScript : ScriptableObject
{
    //public LevelDatabase database;

    public List<HardLevelScriptableObject> WorldLevels;

    public void Awake()
    {
        if (WorldLevels==null)
        {
            WorldLevels = new List<HardLevelScriptableObject>();
        }
    }
}
