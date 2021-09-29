using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="New World Scriptable Object", menuName ="Create New World/Hard")]
public class HardWorldScript : ScriptableObject
{
    public bool WorldIsCompleted;
    public List<HardLevelScriptableObject> WorldLevels;
    public List<bool> IsLevelComplete;

    public void Awake()
    {
        if (WorldLevels==null)
        {
            WorldLevels = new List<HardLevelScriptableObject>();
        }

        if (IsLevelComplete == null)
        {
            IsLevelComplete = new List<bool>();
        }
    }
}

