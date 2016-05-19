using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {


    void OnTriggerEnter (Collider other)
    {
        Debug.Log("Hay Contacto");

    }


    private float dano;
    private float vida;

    // Use this for initialization
    void Start () {
        dano = 20;
        vida = 100;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    
    void OnCollisionEnter(Collision colision)
    {
        if (colision.collider.tag == "FirePlayer")
        {
            Debug.Log(vida -= dano);
            Debug.Log("Hay Contacto");

        }
        else {
            Debug.Log("No hay contacto");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hay Contacto");
    }


}
