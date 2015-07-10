using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
    //[HideInInspector] 
    public List<Prop> Props = new List<Prop>();

    public void Spawn()
    {
        int num = Random.Range(0, Props.Count);
        Transform spawned = Instantiate(Props[num].Prefab, transform.position, transform.rotation) as Transform;
        spawned.parent = transform;
    }
}
