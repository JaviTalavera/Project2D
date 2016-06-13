using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

    public enum Stat {NORMAL, CONGELADO}

    public Stat stat;
    public float maxHealth;
    private float health;

    public GameObject inst;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
