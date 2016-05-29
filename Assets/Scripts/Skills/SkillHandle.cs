using UnityEngine;
using System.Collections;

public class SkillHandle : MonoBehaviour {

	public enum Element { HIELO, FUEGO }

	public float speed;
	public GameObject hitSkill;
	public GameObject hitWater;
	public Element elemento;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * speed * Time.deltaTime);	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.layer == LayerMask.NameToLayer ("Water")) {
			if (elemento == Element.HIELO) {
				GameObject inst = Instantiate (hitWater, collision.contacts [0].point, Quaternion.identity) as GameObject;
				Instantiate (hitSkill, collision.contacts [0].point, hitSkill.transform.rotation); 
				Destroy (gameObject);
			}
		} else {
			if (elemento == Element.FUEGO && collision.gameObject.tag == "Hielo") {
				GameObject inst = Instantiate (hitWater, collision.contacts [0].point, Quaternion.identity) as GameObject;
				Destroy (collision.gameObject);
			}
			// Soltamos los hijos para que termine la animación de las partículas y planificamos una destrucción en un 0.5 segundos.
			Transform particulas = transform.GetChild(0).transform;
			particulas.parent = null;
			Destroy (particulas.gameObject, 0.5f);
			// Instanciamos el golpe por postureo ...
			Instantiate (hitSkill, collision.contacts [0].point, hitSkill.transform.rotation); 
			// Y destruímos el objeto padre. Las partículas se destruirán solas
			Destroy(gameObject);
		}
	}
}
