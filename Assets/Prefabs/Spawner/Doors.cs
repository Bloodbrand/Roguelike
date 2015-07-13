using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Doors : MonoBehaviour {
    public List<Transform> NormalDoors = new List<Transform>();

    public void PlaceDoors(int doorsNum)
    {
        List<int> chosenNumbers = new List<int>();
        int randomDoor, randomPos;

        for (int i = 0; i < doorsNum; i++)
        {
            do randomPos = UnityEngine.Random.Range(0, transform.childCount);
            while (chosenNumbers.Contains(randomPos));
            chosenNumbers.Add(randomPos);

            Transform chosenChild = transform.GetChild(randomPos); 
            randomDoor = UnityEngine.Random.Range(0, NormalDoors.Count);

            Transform doorGO = Instantiate(NormalDoors[randomDoor], chosenChild.position, chosenChild.rotation) as Transform;
            doorGO.parent = chosenChild;
        }
    }
}
