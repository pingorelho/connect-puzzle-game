using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New World Scriptable Object", menuName = "Create New World/Medium")]
public class MediumWorldScript : ScriptableObject
{
    public bool WorldIsCompleted;
    public List<MediumLevelScriptableObject> WorldLevels;
    public List<bool> IsLevelComplete;

    public void Awake()
    {
        if (WorldLevels == null)
        {
            WorldLevels = new List<MediumLevelScriptableObject>();
        }

        if (IsLevelComplete == null)
        {
            IsLevelComplete = new List<bool>();
        }
    }
}

