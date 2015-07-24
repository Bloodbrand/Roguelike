using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Room 
{
    public string Name;
    public GameObject Prefab;
    public float Probability;
    public int StartFrom;
    public int SelectedModifier;
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

    public void EnterRoom(int doors)
    {
        TriggerSpawners();
        PlaceDoors(doors);
    }

    void TriggerSpawners()
    {
        GameObject spawnerHolder = gameObject.transform.FindChild("spawners").gameObject;

        for (int i = 0; i < spawnerHolder.transform.childCount; i++)
        {
            GameObject go = spawnerHolder.transform.GetChild(i).gameObject;
            Spawner spawner = go.GetComponent<Spawner>();
            spawner.StartSpawning();
        }
    }

    void PlaceDoors(int doorsNum)
    {
        GameObject doorHolder = gameObject.transform.FindChild("props").FindChild("doors").gameObject;
        Doors door = doorHolder.GetComponent<Doors>();
        door.PlaceDoors(doorsNum);
    }
}
