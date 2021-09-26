using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Level Database", menuName ="Create New Database/Level Database")]
public class LevelDatabase : ScriptableObject, ISerializationCallbackReceiver
{
    public EasyLevelScriptableObject[] EasyLevels;
    //public MediumLevelScriptableObject[] MediumLevels;
    //public HardLevelScriptableObject[] HardLevels;

    public Dictionary<EasyLevelScriptableObject, int> LevelNumber = new Dictionary<EasyLevelScriptableObject, int>();

    public void OnAfterDeserialize()
    {
        LevelNumber = new Dictionary<EasyLevelScriptableObject, int>();
        for (int i = 0; i < EasyLevels.Length; i++)
        {
            LevelNumber.Add(EasyLevels[i], i);
        }
    }

    public void OnBeforeSerialize()
    {
    }

}
