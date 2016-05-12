using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerNetwork : NetworkBehaviour {

	public override void OnStartLocalPlayer ()
	{
		GetComponent<Player> ().enabled = true;
		GetComponent<Controller2D> ().enabled = true;
	}
}
