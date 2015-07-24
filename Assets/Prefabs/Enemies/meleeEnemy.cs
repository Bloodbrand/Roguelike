using UnityEngine;
using System.Collections;

public class meleeEnemy : Enemy {

    protected override IEnumerator attack()
    {        
        anim.SetBool(walkHash, false);
        while (attackRange)
        {
            anim.SetTrigger(attackHash);
            attacking = true;
            doDamage(dmg);
            yield return new WaitForSeconds(attSpeed);
        }
        base.attack();
    }
}
