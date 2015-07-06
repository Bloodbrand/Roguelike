using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonMaster : MonoBehaviour
{
    public int maxRooms;
    [HideInInspector] public List<Room> PossibleRooms = new List<Room>();

    void Start()
    {
        GenerateDungeon(maxRooms);
    }

    Dungeon GenerateDungeon(int maxRooms)
    {
        Dungeon dungeon = new Dungeon();

        for (int room = 0; room < maxRooms; room++)
        {
            dungeon.AddRoom(pickRandomRoom(room));
        }

        return dungeon;
    }

    Room pickRandomRoom(int roomNumber)
    {
        int randomNum = UnityEngine.Random.Range(0, (int)totalProbabilityValue());
        float currentProbability = 0; 

        for (int i = 0; i < PossibleRooms.Count; i++)
        {
            Debug.Log(i);
            if (checkRoomSkip(roomNumber, PossibleRooms[i])) continue;

            currentProbability += PossibleRooms[i].Probability;
            if (randomNum <= currentProbability) return PossibleRooms[i].PickRoom();
        }
        return null;                
    }

    public double totalProbabilityValue()
    {
        double total = 1;
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
}
