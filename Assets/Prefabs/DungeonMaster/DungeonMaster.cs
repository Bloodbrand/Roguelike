using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonMaster : MonoBehaviour
{
    public int TotalRooms;
    [HideInInspector] public List<Room> PossibleRooms = new List<Room>();
    Dungeon dungeon;

    void Start()
    {
        GenerateDungeon(TotalRooms);
    }

    Dungeon GenerateDungeon(int totalRooms)
    {
        dungeon = new Dungeon();

        for (int roomNum = 0; roomNum < totalRooms; roomNum++)
        {
            dungeon.AddRoom(pickRandomRoom(roomNum));
            //Debug.Log(dungeon.Rooms[roomNum].Name);
        }

        dungeon.currentRoom = dungeon.Rooms[0];
        goToRoom(dungeon.currentRoom);

        return dungeon;
    }

    Room pickRandomRoom(int roomNum)
    {
        int randomNum = UnityEngine.Random.Range(0, (int)CalculateTotalProbabilityValue());
        float currentProbability = 0; 

        for (int i = 0; i < PossibleRooms.Count; i++)
        {
            if (checkRoomSkip(i, PossibleRooms[i])) continue;
            currentProbability += PossibleRooms[i].Probability;
            if (randomNum <= currentProbability) return PossibleRooms[i].PickRoom();
        }
        return null;                
    }

    //TODO: make this work for all lists
    public double CalculateTotalProbabilityValue()
    {
        double total = 0;
        for (int i = 0; i < PossibleRooms.Count; i++)
        {
            double prob = PossibleRooms[i].Probability;
            if (prob < 0) prob = 0;
            total += prob;
        }
        return total;
    }

    bool checkRoomSkip(int roomNumber, Room room)
    {
        if (room.Probability == 0) return true;
        //if (roomNumber < room.StartFrom) return true;
        return false; 
    }

    public void AddNewRoom()
    {
        PossibleRooms.Add(new Room());
    }


    void goToRoom(Room room)
    {
        destroyRoom(dungeon.currentRoom);
        instantiateRoom(room);
        room.triggerSpawners();
        dungeon.currentRoom = room;
    }

    public void NextRoom()
    {
        goToRoom(dungeon.NextRoom());
    }

    /*****************Scene Methods*****************/

    void instantiateRoom(Room room)
    {
        room.GameObject = Instantiate(room.Prefab, Vector3.zero, Quaternion.identity) as GameObject;               
    }

    void destroyRoom(Room room)
    {
        Destroy( room.GameObject );
    }
}
