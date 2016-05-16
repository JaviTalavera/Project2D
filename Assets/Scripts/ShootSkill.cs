using UnityEngine;
using System.Collections;

public class ShootSkill : MonoBehaviour {

	public GameObject skill;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z)) {
			Instantiate (skill, transform.position, skill.transform.rotation);
		}
	}


}
