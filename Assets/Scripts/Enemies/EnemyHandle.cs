﻿using UnityEngine;
using System.Collections;

public class EnemyHandle : MonoBehaviour {

    public float timeBetweenAttacks = 3f;
    public GameObject projectile;
    protected int nPlayers = 0;
    public Transform thrower;

    protected Collider2D collider;
    protected Animator anim;
    protected EnemyStats es;

	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        es = GetComponent<EnemyStats>();
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().doDamage(es.damage);
            Physics2D.IgnoreCollision(other.collider, collider);
            StartCoroutine("ActiveCollision", other.collider);
        }
    }

    IEnumerator ActiveCollision (Collider2D other)
    {
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreCollision(other, collider, false);
    }
}