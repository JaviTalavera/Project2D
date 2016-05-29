using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public enum DireccionH { Izquierda, Derecha }
	public enum NPlayer { Player1, Player2 }

	public float MaxHp;
	private float actualHp;
	public float VelocidadH;

	private Rigidbody2D rb;
	private IsGrounded ig;
	private ShootSkill ss;

	public NPlayer player;
	private DireccionH direccion;

	public GameObject pmPlayer1;
	public GameObject pmPlayer2;

	private KeyCode cJump;
	private KeyCode cAttack;


	// Use this for initialization
	void Start () {
		direccion = DireccionH.Derecha;
		ig = transform.Find ("IsGrounded").GetComponent<IsGrounded> ();
		rb = GetComponent<Rigidbody2D> ();
		ss = GetComponent<ShootSkill> ();
		actualHp = MaxHp;
		if (player == NPlayer.Player1) {
			GameObject inst = Instantiate (pmPlayer1, transform.position, Quaternion.identity) as GameObject;
			inst.transform.parent = transform;
			cJump = KeyCode.Space;
			cAttack = KeyCode.LeftControl;
		}
		else if (player == NPlayer.Player2) {
			GameObject inst = Instantiate (pmPlayer2, transform.position, Quaternion.identity) as GameObject;
			inst.transform.parent = transform;
			cJump = KeyCode.RightControl;
			cAttack = KeyCode.RightShift;
		}
	}
	
	void Update()
	{
		float x = 0;
		if (player == NPlayer.Player1) x = Input.GetAxis ("Horizontal");
		else x = Input.GetAxis ("Horizontal2");

		if (direccion == DireccionH.Derecha && x < 0) {
			direccion = DireccionH.Izquierda;
			Flip ();
		} else if (direccion == DireccionH.Izquierda && x > 0) {
			direccion = DireccionH.Derecha;
			Flip ();
		}

		Vector3 vSpeed = new Vector3 (VelocidadH * x, 0, 0);
		transform.Translate(vSpeed * Time.deltaTime);

		if (Input.GetKeyDown (cJump)) {
			if (ig.isGrounded()) 
				rb.velocity = new Vector2 (rb.velocity.x, 5f);
		}
		if (Input.GetKeyDown(cAttack)) {
			ss.Execute();
		}
		if (Input.GetKeyDown(KeyCode.Z)) {
			doDamage(10f);
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

	public float getHpPorcen () {
		return actualHp / MaxHp;
	}

	public void doDamage (float dmg) {
		actualHp -= dmg;
		if (actualHp < 0)
			actualHp = 0;
	}
}
