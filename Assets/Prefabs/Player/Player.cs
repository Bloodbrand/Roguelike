using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float health;
    public float damage;

    public void TakeDamage(float damage)
    {
        health -= damage;
        GameMaster.uiComp.takeDamageUI(damage);
    }

    public virtual void CastSwipe(Vector2 start, float angle)
    { 

    }

    public virtual void CastHold(Vector2 position)
    {

    }
}
