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
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(force * Vector2.up);
            anim.SetTrigger("Bump");
        }
    }
}
