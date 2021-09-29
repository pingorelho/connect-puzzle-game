using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New World Scriptable Object", menuName = "Create New World/Easy")]
public class EasyWorldScript : ScriptableObject
{
    public bool WorldIsCompleted;
    public List<EasyLevelScriptableObject> WorldLevels;
    public List<bool> IsLevelComplete;

    public void Awake()
    {
        if (WorldLevels == null)
        {
            WorldLevels = new List<EasyLevelScriptableObject>();
        }

        if (IsLevelComplete == null)
        {
            IsLevelComplete = new List<bool>();
        }
    }
}

