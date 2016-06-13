using UnityEngine;
using System.Collections;

public class MuelleHandle : MonoBehaviour {

    private Animator anim;
    public float force;

    void Start ()
    {
        anim = GetComponent<Animator>();
    }

	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.AddForce(force * Vector2.up);
            anim.SetTrigger("Bump");
        }
    }
}
