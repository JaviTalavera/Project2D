using UnityEngine;
using System.Collections;

public class desliza : MonoBehaviour {


    public float Velocidad_Desliza;
    private float VelocidadH_Ori;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Contains("Player")) // TO DO
        {
            VelocidadH_Ori = other.gameObject.GetComponent<PlayerMovement>().VelocidadH;
            other.gameObject.GetComponent<PlayerMovement>().VelocidadH = Velocidad_Desliza;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag.Contains("Player")) // TO DO
            other.gameObject.GetComponent<PlayerMovement>().VelocidadH = VelocidadH_Ori;

    }

}
