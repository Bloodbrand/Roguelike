using System;
using UnityEngine;

[Serializable]
public class Room
{
    public string name;
    public float probability;
    public bool repeat;
    public int howManyTimes;
    public bool link;
    public GameObject nextRoom;
    public GameObject Mesh;
    public int[] intarr = new int[0];
}
