using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour {

    public AudioClip Contacto;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(Contacto, transform.position, PlayerData.Instance.EffectsVolume);
        }
    }
}
