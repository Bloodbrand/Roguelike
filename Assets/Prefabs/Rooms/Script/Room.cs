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
    public bool MaxRepeats;
    public int Repeats;
    public bool MaxSpawns;
    public int Spawns;
    public bool Link;
    public GameObject NextRoom;
    public int SpecialOptionsIndex = 0;

    GameObject gameObject;

    public GameObject GameObject
    {
        get
        {
            return this.gameObject;
        }
        set
        {
            this.gameObject = value;
        }
    }

    public Room PickRoom()
    {        
        this.Probability += this.SelectedModifier;
        return this;
    }

    public void triggerSpawners()
    {
        GameObject holder = gameObject.transform.FindChild("spanwers").gameObject;

        for (int i = 0; i < holder.transform.childCount; i++)
        {
            GameObject go = holder.transform.GetChild(i).gameObject;
            Spawner spawner = go.GetComponent<Spawner>();
            spawner.Spawn();
        }
    }
}
