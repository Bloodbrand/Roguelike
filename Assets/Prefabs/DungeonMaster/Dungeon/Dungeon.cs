using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dungeon 
{
    public List<Room> Rooms = new List<Room>();
    public Room currentRoom;

    int roomIndex = 0;

    public Room NextRoom()
    {
        if (roomIndex == Rooms.Count)
        {
            Debug.Log("Reached end of the dungeon.");
            return null;
        }

        return Rooms[++roomIndex];
    }

    public void AddRoom(Room room)
    {
        this.Rooms.Add(room);
    }
}
