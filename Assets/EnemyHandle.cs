using UnityEngine;
using System.Collections;

public class EnemyHandle : MonoBehaviour {

    public float timeBetweenAttacks = 3f;
    public GameObject projectile;
    private int nPlayers = 0;
    public Transform thrower;

    private Animator anim;
    private EnemyStats es;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        es = GetComponent<EnemyStats>();
	}

    public IEnumerator Attack ()
    {
        while (true)
        {
            if (es.stat != EnemyStats.Stat.CONGELADO) {
                anim.SetTrigger("Attack");
                GameObject go = Instantiate(projectile, thrower.position, projectile.transform.rotation) as GameObject;
                go.GetComponent<Rigidbody2D>().AddForce(100 * (Vector2.up + Vector2.right * Mathf.Sign(transform.localScale.x)));
            }
            yield return new WaitForSeconds(timeBetweenAttacks);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Contains("Player"))
        {
            if (nPlayers == 0)
                StartCoroutine("Attack");
            nPlayers++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Contains("Player"))
        {
            nPlayers--;
            if (nPlayers == 0)
                StopAllCoroutines();
        }
    }

    public bool Congelar ()
    {
        if (es.stat != EnemyStats.Stat.CONGELADO)
        {
            es.stat = EnemyStats.Stat.CONGELADO;
            anim.speed = 0;
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
            return true;
        }
        return false;
    }
}
