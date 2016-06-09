using UnityEngine;
using System.Collections;

public class EnemyHandle : MonoBehaviour {

    public float timeBetweenAttacks = 3f;
    public GameObject projectile;
    private int nPlayers = 0;
    public Transform thrower;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator Attack ()
    {
        while (true)
        {
            anim.SetTrigger("Attack");
            GameObject go = Instantiate(projectile, thrower.position, projectile.transform.rotation) as GameObject;
            go.GetComponent<Rigidbody2D>().AddForce(100*(Vector2.up+Vector2.right*Mathf.Sign(transform.localScale.x)));
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
}
