using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class player1 : Player
{
    public Transform forceWave;
    int times = 0;

    public override void CastSwipe(Vector2 position, float angle)
    {
        base.CastSwipe(position, angle);
        Vector3 v3Start = GameMaster.cam.ScreenToWorldPoint(new Vector3(position.x, position.y, GameMaster.cameraY));
        v3Start.y = 0;
        Instantiate(forceWave, v3Start, Quaternion.Euler(0, angle, 0));
    }

    public override void CastHold(Vector2 position)
    {
        base.CastHold(position);
        Vector3 v3Start = GameMaster.cam.ScreenToWorldPoint(new Vector3(position.x, position.y, GameMaster.cameraY));

        float angle = 0;
        float steps = 8;
        float increment = 360 / steps;

        for (int i = 0; i < steps; i++)
        {
            angle += increment;
            Instantiate(forceWave, v3Start, Quaternion.Euler(0, angle, 0));
        }

        addExplosion(v3Start);
    }

    void addExplosion(Vector3 pos)
    {
        float radius = 100;
        float force = 1000;
        float upward = 30;
        Collider[] colliders = Physics.OverlapSphere(pos, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null) rb.AddExplosionForce(force, pos, radius, upward);
        }
    }
}
