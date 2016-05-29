using UnityEngine;
using System.Collections;

public class ShootSkill : MonoBehaviour {

	public GameObject skill;
	public float maxSkillCd;
	private Transform thrower;
	private Transform sprite;
	public LayerMask layer;
	private float skillCd;

	// Use this for initialization
	void Start () {
		skillCd = 0f;
		sprite = transform.FindChild ("Cuerpo") as Transform;
		thrower = transform.FindChild ("Cuerpo/Thrower") as Transform;
	}
	
	// Update is called once per frame
	public void Execute () {
		if (skillCd < 0) {
			RaycastHit2D hit = Physics2D.Raycast(thrower.position, Vector2.down, 100f, layer);
			if (hit.collider != null) {
				GameObject go = Instantiate (skill, hit.point, skill.transform.rotation) as GameObject;
				go.GetComponent<SkillHandle> ().speed *= Mathf.Sign(sprite.localScale.x); 
				skillCd = maxSkillCd;
			}
		}
	}

	void FixedUpdate () {
		skillCd -= Time.fixedDeltaTime;
	}


	public float getCdPorcen () {
		return (maxSkillCd - skillCd) / maxSkillCd;
	}


}
