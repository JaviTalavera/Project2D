using UnityEngine;
using System.Collections;

public class SkillHandle : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * speed * Time.deltaTime);	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		//Debug.Log (collider.gameObject.layer);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		//Debug.Log (collision.gameObject.layer);
	}
}
