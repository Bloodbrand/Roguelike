using UnityEngine;
using System.Collections;

public class translate : MonoBehaviour {
    public Vector3 direction;
    public float speed;

	void Update () {
        transform.Translate(direction * speed * Time.deltaTime);
	}
}
