using UnityEngine;
using System.Collections;

public class EnemyRockHandle : EnemyHandle {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Contains("Player"))
        {
            if (nPlayers == 0)
                attack = true;
            nPlayers++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Contains("Player"))
        {
            nPlayers--;
            if (nPlayers == 0)
                attack = false;
        }
    }

    public override void Attack()
    {
        if (es.stat != EnemyStats.Stat.CONGELADO)
        {
            anim.SetTrigger("Attack");
            GameObject go = Instantiate(projectile, thrower.position, projectile.transform.rotation) as GameObject;
            go.GetComponent<Rigidbody2D>().AddForce(100 * (Vector2.up + Vector2.right * Mathf.Sign(transform.localScale.x)));
        }
    }
}
