using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	public float limit;
	private GameObject[] respawnPoints;

	// Use this for initialization
	void Start () {
		respawnPoints = GameObject.FindGameObjectsWithTag ("RespawnPoint");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.y < limit) {
			transform.position = respawnPoints[Random.Range(0, respawnPoints.Length-1)].transform.position;
		}
	}
}
