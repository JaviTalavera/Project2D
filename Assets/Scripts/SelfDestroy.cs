using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public float timeToDie;
	public GameObject anim;

	// Use this for initialization
	void Start () {
		if (anim != null)
			StartCoroutine ("instantiateAnimation");
		Destroy (gameObject, timeToDie);
	}

	public IEnumerator instantiateAnimation () {
		yield return new WaitForSeconds (timeToDie-0.1f	);
		Instantiate (anim, transform.position, anim.transform.rotation);
	}
}
