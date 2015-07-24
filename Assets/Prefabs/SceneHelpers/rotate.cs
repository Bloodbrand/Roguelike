using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

    public float rotateX, rotateY, rotateZ;
	
	void Update () {
        transform.Rotate(new Vector3(rotateX * Time.deltaTime, rotateY * Time.deltaTime, rotateZ * Time.deltaTime));
	}
}
