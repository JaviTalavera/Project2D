using UnityEngine;
using System.Collections;

public class RockHandle : MonoBehaviour {

    private Rigidbody2D rb;
    public float force;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Vector2 v = rb.velocity;
            v.y = 0;
            rb.velocity = v;
            rb.AddForce(force * Vector2.up);
        }
        else if (other.gameObject.tag.Contains("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().doDamage(50f);
            Destroy(gameObject);
        }
    }
}
