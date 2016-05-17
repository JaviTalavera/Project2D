using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public float timeToDie;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, timeToDie);
	}
}
