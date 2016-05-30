using UnityEngine;
using System.Collections;

public class IsGrounded : MonoBehaviour {

	public LayerMask layer;

	public bool isGrounded () {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 10f, layer);
		if (hit.collider != null) {
			float distance = Mathf.Abs(hit.point.y - transform.position.y);
			if (distance < 0.25f)
				return true;
		}
		return false;
	}
}
