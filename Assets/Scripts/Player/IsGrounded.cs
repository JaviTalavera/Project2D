using UnityEngine;
using System.Collections;

public class IsGrounded : MonoBehaviour {

	public LayerMask layer;

	public bool isGrounded () {
        if (Physics2D.IsTouchingLayers(GetComponent<Collider2D>(), layer))
            return true;
		return false;
	}
}
