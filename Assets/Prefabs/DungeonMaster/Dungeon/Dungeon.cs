using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dungeon 
{
    public List<Room> rooms = new List<Room>();

    public void AddRoom(Room room)
    {
        this.rooms.Add(room);
    }
}
