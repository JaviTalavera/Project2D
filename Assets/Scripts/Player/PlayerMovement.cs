using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public enum DireccionH { Izquierda, Derecha }

	public float VelocidadH;
	private Rigidbody2D rb;
	private IsGrounded ig;
	private DireccionH direccion;

	// Use this for initialization
	void Start () {
		direccion = DireccionH.Derecha;
		ig = transform.Find ("IsGrounded").GetComponent<IsGrounded> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	void Update()
	{
		float x = Input.GetAxis ("Horizontal");

		if (direccion == DireccionH.Derecha && x < 0) {
			direccion = DireccionH.Izquierda;
			Flip ();
		} else if (direccion == DireccionH.Izquierda && x > 0) {
			direccion = DireccionH.Derecha;
			Flip ();
		}

		Vector3 vSpeed = new Vector3 (VelocidadH * x, 0, 0);
		transform.Translate(vSpeed * Time.deltaTime);

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (ig.isGrounded()) 
				rb.velocity = new Vector2 (rb.velocity.x, 5f);
		}

	}

	void Flip () {
		Vector3 vFlip = new Vector3 (-1*transform.localScale.x, transform.localScale.y, transform.localScale.z);
		transform.localScale = vFlip;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.layer == LayerMask.NameToLayer ("Water")) { 
			GetComponent<Collider2D> ().enabled = false;
		}
	}
}
