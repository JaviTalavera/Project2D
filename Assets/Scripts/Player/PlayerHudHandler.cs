using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHudHandler : MonoBehaviour {

	public enum NPlayer { Player1, Player2 }

	public NPlayer player;
	private ShootSkill ss;
	private PlayerMovement pm;

	public Image imgHp;
	public Image imgCd;

	// Use this for initialization
	void Start () {
		if (player == NPlayer.Player1) {
			ss = GameObject.FindGameObjectWithTag ("Player1").GetComponent<ShootSkill> ();
			pm = GameObject.FindGameObjectWithTag ("Player1").GetComponent<PlayerMovement> ();
		}
		else if (player == NPlayer.Player2) {
			ss = GameObject.FindGameObjectWithTag ("Player2").GetComponent<ShootSkill> ();
			pm = GameObject.FindGameObjectWithTag ("Player2").GetComponent<PlayerMovement> ();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		imgHp.fillAmount = pm.getHpPorcen ();
		imgCd.fillAmount = ss.getCdPorcen ();
	}
}
