using UnityEngine;
using System.Collections;

public class SkillHandle : MonoBehaviour {

	public enum Element { HIELO, FUEGO }

	public float speed;
	public GameObject hitSkill;
	public GameObject hitWater;
    public GameObject hitIce;
	public Element elemento;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * speed * Time.deltaTime);	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.layer == LayerMask.NameToLayer ("Water")) {
			if (elemento == Element.HIELO) {
				Instantiate (hitWater, collision.contacts [0].point, Quaternion.identity);
				Instantiate (hitSkill, collision.contacts [0].point, hitSkill.transform.rotation); 
				Destroy (gameObject);
			}
            else if (elemento == Element.FUEGO) {
                Instantiate(hitWater, collision.contacts[0].point, Quaternion.identity);
                Destroy(gameObject);
            }
		} else {
			if (elemento == Element.FUEGO && collision.gameObject.tag == "Hielo") {
				Instantiate (hitIce, collision.contacts [0].point, Quaternion.identity);
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
