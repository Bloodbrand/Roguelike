using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public int Times;
    public float Interval;
    public List<Prop> Props = new List<Prop>();

    public void StartSpawning()
    {
        int randomNum = UnityEngine.Random.Range(0, helpers.CalculateTotalProbabilityValue(Props));
        float currentProbability = 0;

        for (int i = 0; i < Props.Count; i++)
        {
            currentProbability += Props[i].Probability;
            if (randomNum <= currentProbability)
            {
                StartCoroutine(spawn());
                break;
            }
        }   
    }

    IEnumerator spawn()
    {
        for (int i = 0; i < Times; i++)
        {
            int num = Random.Range(0, Props.Count);
            Transform spawned = Instantiate(Props[num].Prefab, transform.position, transform.rotation) as Transform;
            spawned.parent = transform;

            yield return new WaitForSeconds(Interval);            
        }
    }
}
