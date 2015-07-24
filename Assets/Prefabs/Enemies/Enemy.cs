using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    [SerializeField] protected float hp;
    [SerializeField] protected float dmg;
    [SerializeField] protected float attSpeed;
    [SerializeField] protected float speed;

    protected Transform player;
    protected NavMeshAgent navAgent;
    protected bool attackRange = false;
    protected bool attacking = false;

    #region animation
    protected Animator anim;
    protected int walkHash = Animator.StringToHash("walk");
    protected int idleHash = Animator.StringToHash("idle");
    protected int attackHash = Animator.StringToHash("attack");
    #endregion

    protected virtual void Start () {
        anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent.destination = player.position;
        setSpeed(speed, true);
	}

    void Update()
    {
        checkDistance();
    }

    void OnMouseDown()
    {
        takeDamage(GameMaster.playerComp.damage);
    }

    public virtual void takeDamage(float damage)
    {
        hp -= damage;
        checkDeath();
    }

    public virtual void checkDeath()
    {
        if (hp <= 0) die();
    }

    public virtual void die()
    {
        Destroy(gameObject);
    }

    #region attack

    protected virtual IEnumerator attack()
    {
        yield return new WaitForSeconds(0.0f);
    }

    protected void doDamage(float damage)
    {
        GameMaster.playerComp.TakeDamage(damage);
    }

    #endregion

    public virtual void checkDistance()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= navAgent.stoppingDistance) attackRange = true;
        else attackRange = false;

        if (!attackRange) return;
        if (attacking) return;

        StartCoroutine(attack());
    }

    public virtual void setSpeed(float newSpeed, bool couple)
    {
        /*couple dictates if anim speed should be coupled to move speed
        this is not always true ex: skeleton look anim*/
        if (couple) navAgent.speed = anim.speed = newSpeed;
        else navAgent.speed = newSpeed;
    }
}
