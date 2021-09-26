using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New World Scriptable Object", menuName ="Create New World")]
public class WorldScript : ScriptableObject
{
    public LevelDatabase database;
    public List<Level> WorldLevels = new List<Level>();

    public void AddLevel(Level level) {
        WorldLevels.Add(level);
    }
}
