using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

    public enum Stat {NORMAL, CONGELADO}

    public Stat stat;
    public float maxHealth;
    private float health;
    public float damage;

    public GameObject inst;
}
