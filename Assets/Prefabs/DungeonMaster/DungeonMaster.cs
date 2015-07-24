using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonMaster : MonoBehaviour
{
    public int TotalRooms;
    public int DoorsNum = 1;

    [HideInInspector] public List<Room> PossibleRooms = new List<Room>();
    Dungeon dungeon;

    #region player
    public Transform Player1;
    Transform selectedPlayer;
    Vector3 playerPosition;
    #endregion

    void Start()
    {
        GenerateDungeon(TotalRooms);
        spawnPlayer();
    }

    Dungeon GenerateDungeon(int totalRooms)
    {
        dungeon = new Dungeon();

        for (int roomNum = 0; roomNum < totalRooms; roomNum++)
            dungeon.AddRoom(pickRandomRoom(roomNum));

        dungeon.currentRoom = dungeon.Rooms[0];
        goToRoom(dungeon.currentRoom);

        return dungeon;
    }

    void spawnPlayer()
    {
        selectedPlayer = Player1;
        playerPosition = GameObject.Find("PlayerPosition").transform.position;
        Instantiate(selectedPlayer, playerPosition, Quaternion.identity);
    }

    Room pickRandomRoom(int roomNum)
    {
        //increment because random is uninclusive of last number
        float randomNum = UnityEngine.Random.Range(0, helpers.CalculateTotalProbabilityValue(PossibleRooms)); 
        float currentProbability = 0; 

        for (int i = 0; i < PossibleRooms.Count; i++)
        {
            if (checkRoomSkip(i, PossibleRooms[i])) continue;
            currentProbability += PossibleRooms[i].Probability;
            if (randomNum <= currentProbability) return PossibleRooms[i].PickRoom();
        }
        return null;                
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
        room.EnterRoom(DoorsNum);
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
