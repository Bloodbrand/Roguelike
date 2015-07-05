using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonMaster : MonoBehaviour
{
    public List<Room> RoomList = new List<Room>(1);

    void Start()
    {
        Debug.Log(RoomList[0].repeat);
        Debug.Log(RoomList[1].repeat);

        Debug.Log(RoomList[0].probability);
        Debug.Log(RoomList[1].probability);
    }

    void AddNew()
    {        
        RoomList.Add(new Room());
    }

    void Remove(int index)
    {
        RoomList.RemoveAt(index);
    }
}
