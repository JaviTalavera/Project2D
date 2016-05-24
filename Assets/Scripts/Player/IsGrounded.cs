using UnityEngine;
using System.Collections;

public class IsGrounded : MonoBehaviour {

	private bool bGrounded;

	public bool isGrounded () {
		return bGrounded;
	}

	public void LateUpdate () {
		bGrounded = false;
	}

	public void OnTriggerStay2D(Collider2D collider) {
		if (collider.gameObject.layer == 8)
			bGrounded = true;
	}
}
