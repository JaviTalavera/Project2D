using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public float timeToDie;
	public GameObject animation;

	// Use this for initialization
	void Start () {
		if (animation != null)
			StartCoroutine ("instantiateAnimation");
		Destroy (gameObject, timeToDie);
	}

	public IEnumerator instantiateAnimation () {
		yield return new WaitForSeconds (timeToDie-0.1f	);
		Instantiate (animation, transform.position, animation.transform.rotation);
	}
}
