using System;
using UnityEngine;

[Serializable]
public class Room
{
    public string Name;
    public GameObject Prefab;
    public float Probability;
    public int StartFrom;
    public float SelectedModifier;
    public int HowManyRepeats;
    public bool MaxSpawns;
    public int HowMany;
    public bool Link;
    public GameObject NextRoom;
    public int SpecialOptionsIndex = 0;

    public Room PickRoom()
    {
        this.Probability += this.SelectedModifier;
        return this;
    }
}
