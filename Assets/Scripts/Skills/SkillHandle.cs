using UnityEngine;
using System.Collections;

public class SkillHandle : MonoBehaviour {

	public float speed;
	public GameObject ice;
	public GameObject spike;
	public float timeBetweenSpikes;

	// Use this for initialization
	void Start () {
		StartCoroutine ("InstantiateSprite");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * speed * Time.deltaTime);	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.layer == LayerMask.NameToLayer ("Water")) {
			GameObject inst = Instantiate (ice, collision.contacts [0].point, Quaternion.identity) as GameObject;
			Destroy (gameObject);
		}
	}

	public IEnumerator InstantiateSprite () {
		while (true) {
			GameObject inst = Instantiate (spike, transform.position, spike.transform.rotation) as GameObject;
			Vector3 vFlip = new Vector3 (-1*Mathf.Sign (speed)*inst.transform.localScale.x, inst.transform.localScale.y, inst.transform.localScale.z);
			inst.transform.localScale = vFlip;
			yield return new WaitForSeconds (timeBetweenSpikes);
		}
	}
}
