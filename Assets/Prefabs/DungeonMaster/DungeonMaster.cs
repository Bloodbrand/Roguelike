using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonMaster : MonoBehaviour
{
    public int TotalRooms;
    [HideInInspector] public List<Room> PossibleRooms = new List<Room>();

    void Start()
    {
        GenerateDungeon(TotalRooms);
    }

    Dungeon GenerateDungeon(int totalRooms)
    {
        Dungeon dungeon = new Dungeon();

        for (int roomNum = 0; roomNum < totalRooms; roomNum++)
        {
            dungeon.AddRoom(pickRandomRoom(roomNum));
            Debug.Log(dungeon.Rooms[roomNum].Name);
        }
            

        instantiateRoom(dungeon.Rooms[0]);

        return dungeon;
    }

    Room pickRandomRoom(int roomNum)
    {
        int randomNum = UnityEngine.Random.Range(0, (int)totalProbabilityValue());
        float currentProbability = 0; 

        for (int i = 0; i < PossibleRooms.Count; i++)
        {
            if (checkRoomSkip(i, PossibleRooms[i])) continue;
            currentProbability += PossibleRooms[i].Probability;
            if (randomNum <= currentProbability) return PossibleRooms[i].PickRoom();
        }
        return null;                
    }

    public double totalProbabilityValue()
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
        //Debug.Log(room.Name);
        if (room.Probability == 0) return true;
        //if (roomNumber < room.StartFrom) return true;
        return false; 
    }

    public void AddNew()
    {
        PossibleRooms.Add(new Room());
    }

    ///////////////////////////////////////////////////////////////////////

    void instantiateRoom(Room room)
    {
        Instantiate(room.Prefab, Vector3.zero, Quaternion.identity);
    }
}
