using UnityEngine;
using System.Collections;

public class SkillHandle : MonoBehaviour {

	public float speed;
	public GameObject ice;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * speed * Time.deltaTime);	
	}

	void OnTriggerEnter2D(Collider2D collider) {

	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.layer == LayerMask.NameToLayer ("Water")) {
			GameObject inst = Instantiate (ice, collision.contacts [0].point, Quaternion.identity) as GameObject;
		}
	}
}
