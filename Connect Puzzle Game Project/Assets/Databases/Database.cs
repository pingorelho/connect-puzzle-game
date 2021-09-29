using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="New Database", menuName ="Create New Database")]
public class Database : ScriptableObject
{
    public List<EasyWorldScript> EasyWorlds;
    public List<MediumWorldScript> MediumWorlds;
    public List<HardWorldScript> HardWorlds;

    public void Awake()
    {
        if (EasyWorlds == null)
        {
            EasyWorlds = new List<EasyWorldScript>();
        }
        if (MediumWorlds == null)
        {
            MediumWorlds = new List<MediumWorldScript>();
        }
        if (HardWorlds == null)
        {
            HardWorlds = new List<HardWorldScript>();
        }

    }
}
