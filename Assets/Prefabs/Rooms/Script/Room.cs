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
    public int HowManySpawns;
    public bool Link;
    public GameObject NextRoom;
    public int SpecialOptionsIndex = 0;

    public Room PickRoom()
    {
        Debug.Log(this.Name);
        this.Probability += this.SelectedModifier;
        return this;
    }
}
