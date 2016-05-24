using UnityEngine;
using System.Collections;

public class ShootSkill : MonoBehaviour {

	public GameObject skill;
	public float maxSkillCd;
	public Transform thrower;
	public LayerMask layer;
	private float skillCd;

	// Use this for initialization
	void Start () {
		skillCd = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z) && skillCd < 0) {
			RaycastHit2D hit = Physics2D.Raycast(thrower.position, Vector2.down, 100f, layer);
			if (hit.collider != null) {
				GameObject go = Instantiate (skill, hit.point, skill.transform.rotation) as GameObject;
				go.GetComponent<SkillHandle> ().speed *= transform.localScale.x; 
				skillCd = maxSkillCd;
			}
		}
		skillCd -= Time.deltaTime;
	}


}
