using UnityEngine;
using System.Collections;

public class EnemyHandle : MonoBehaviour {

    protected int nPlayers = 0;
    public Transform thrower;

    public bool attack;
    public GameObject projectile;
    public float timeBetweenAttacks = 3f;
    private float maxTimeBetweenAttacks;

    protected Collider2D cachedCollider;
    protected Rigidbody2D rb;
    protected Animator anim;
    protected EnemyStats es;

	// Use this for initialization
	void Start () {
        cachedCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        es = GetComponent<EnemyStats>();
        maxTimeBetweenAttacks = timeBetweenAttacks;

    }

    void Update ()
    {
        if (attack)
        {
            if (timeBetweenAttacks < 0)
            {
                Attack();
                timeBetweenAttacks = maxTimeBetweenAttacks;
            }
            timeBetweenAttacks -= Time.deltaTime;
        }
    }

    public virtual void Attack()
    {
        if (es.stat != EnemyStats.Stat.CONGELADO)
        {
            //anim.SetTrigger("Attack");
            GameObject go = Instantiate(projectile, thrower.position, projectile.transform.rotation) as GameObject;
            //go.GetComponent<Rigidbody2D>().AddForce(100 * (Vector2.up + Vector2.right * Mathf.Sign(transform.localScale.x)));
        }
    }

    public bool Congelar ()
    {
        if (es.stat != EnemyStats.Stat.CONGELADO)
        {
            es.stat = EnemyStats.Stat.CONGELADO;
            anim.speed = 0;
            rb.gravityScale = 1;
            return true;
        }
        return false;
    }

    public bool Descongelar()
    {
        if (es.stat == EnemyStats.Stat.CONGELADO)
        {
            if (es.inst != null)
                es.inst.GetComponent<SelfDestroy>().ForceDestroy();
            es.stat = EnemyStats.Stat.NORMAL;
            anim.speed = 1;
            rb.gravityScale = 0;
            return true;
        }
        return false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().doDamage(es.damage);
            Physics2D.IgnoreCollision(other.collider, cachedCollider);
            StartCoroutine("ActiveCollision", other.collider);
        }
    }

    IEnumerator ActiveCollision (Collider2D other)
    {
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreCollision(other, cachedCollider, false);
    }
}
