using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    static Transform player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = player.position; 
	}
}
