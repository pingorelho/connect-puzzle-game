using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Level Database", menuName ="Create New Database/Level Database")]
public class LevelDatabase : ScriptableObject, ISerializationCallbackReceiver
{
    public Level[] Levels;

    public Dictionary<int, Level> GetLevelFromID = new Dictionary<int, Level>();

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Levels.Length; i++)
        {
            Levels[i].LevelID = i;
            GetLevelFromID.Add(i, Levels[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetLevelFromID = new Dictionary<int, Level>();
    }

}
