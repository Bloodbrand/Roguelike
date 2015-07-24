using UnityEngine;
using System.Collections;

public class scale : MonoBehaviour {
    public Vector3 newScale;
    public float speed;

    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x + newScale.x * Time.deltaTime * speed,
                                           transform.localScale.y + newScale.y * Time.deltaTime * speed, 
                                           transform.localScale.z + newScale.z * Time.deltaTime * speed); 
	}
}
