using UnityEngine;
using System.Collections;

public class SkillHandle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().AddForce(5*Vector2.right);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		//Debug.Log (collider.gameObject.layer);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		//Debug.Log (collision.gameObject.layer);
	}
}
