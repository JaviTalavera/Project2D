using UnityEngine;
using System.Collections;


public class EnemyDamage : MonoBehaviour {

    private float dano;
    private float vida;

    private PlayerMovement PlayerMovement;


    // Use this for initialization
    void Start () {
        dano = 20f;
        vida = 100;
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Hay Contacto");

        if (other.gameObject.tag.Contains("Player")) // TO DO
            other.gameObject.GetComponent<PlayerMovement>().doDamage(dano);

        Debug.Log(GetComponent<PlayerMovement>().doDamage(dano));

    }


}
