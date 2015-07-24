using UnityEngine;
using System.Collections;

public class skeleton : meleeEnemy {
    float walkTime = 3.0f;
    float idleTime = 1.0f;
    float maxTimeVariation = 1.0f;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(alternateWalk());
    }

    IEnumerator alternateWalk()
    {
       while (!attacking)
       {
           float randomVariation = Random.Range(0, maxTimeVariation);

            anim.SetBool(walkHash, false);
            anim.SetBool(idleHash, true);
            setSpeed(0, false);

            yield return new WaitForSeconds(idleTime + randomVariation);

            anim.SetBool(walkHash, true);
            anim.SetBool(idleHash, false);
            setSpeed(speed, true);

            yield return new WaitForSeconds(walkTime + randomVariation);
        }
        
    }    
}
