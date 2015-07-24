using UnityEngine;
using System.Collections;

public class forceWave : MonoBehaviour {
    public float damage;

    void Start()
    {
        Destroy(gameObject.transform.parent.gameObject, 2);
    }

    void OnTriggerEnter(Collider col)
    {
        Enemy colEnemy = col.GetComponent<Enemy>();
        if (colEnemy != null) doDamage(colEnemy);

        Destructible destr = col.GetComponent<Destructible>();
        if (destr != null) destr.explode();
    }

    void doDamage(Enemy colEnemy)
    {
        colEnemy.takeDamage(damage);
    }
}
