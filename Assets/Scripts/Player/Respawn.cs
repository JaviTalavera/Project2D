using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	public float limit;
    private PlayerMovement pm;

	// Use this for initialization
	void Start () {
        pm = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.y < limit) {
            pm.ResetPosition();
		}
	}
}
