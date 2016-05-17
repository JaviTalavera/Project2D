using UnityEngine;
using System.Collections;

public class ShootSkill : MonoBehaviour {

	public GameObject skill;
	public float maxSkillCd;

	private float skillCd;

	// Use this for initialization
	void Start () {
		skillCd = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z) && skillCd < 0) {
			GameObject go = Instantiate (skill, transform.position, skill.transform.rotation) as GameObject;
			go.GetComponent<SkillHandle> ().speed *= transform.localScale.x; 
			skillCd = maxSkillCd;
		}
		skillCd -= Time.deltaTime;
	}


}
