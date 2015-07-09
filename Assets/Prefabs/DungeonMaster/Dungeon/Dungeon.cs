using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dungeon 
{
    public List<Room> Rooms = new List<Room>();

    public void AddRoom(Room room)
    {
        this.Rooms.Add(room);
    }
}
