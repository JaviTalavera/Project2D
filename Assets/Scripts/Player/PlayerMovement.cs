﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public enum DireccionH { Izquierda, Derecha }

	public float MaxHp;
	private float actualHp;
	public float VelocidadH;
    public float VelocidadV;

    private Rigidbody2D rb;
	private IsGrounded ig;
	private ShootSkill ss;
	private Animator anim;
	private Transform sprite;
    
	private DireccionH direccion;

	public GameObject pmPlayer1;
	public GameObject pmPlayer2;
    public GameObject lblDamage;

	public KeyCode cJump;
	public KeyCode cAttack;
    public string xAxis;

    private GameObject[] respawnPoints;
    public GameObject pmPlayerAux;

    // Use this for initialization
    void Awake () {
		direccion = DireccionH.Derecha;
        respawnPoints = GameObject.FindGameObjectsWithTag("RespawnPoint");
        ig = transform.FindChild ("Cuerpo/IsGrounded").GetComponent<IsGrounded> ();
		rb = GetComponent<Rigidbody2D> ();
		ss = GetComponent<ShootSkill> ();
		anim = GetComponent<Animator> ();
		sprite = transform.FindChild ("Cuerpo") as Transform;
		actualHp = MaxHp;

	}

    void OnEnable ()
    {
        /*if (player == NPlayer.Player1)
        {
            pmPlayerAux = Instantiate(pmPlayer1, transform.position, Quaternion.identity) as GameObject;
            pmPlayerAux.transform.parent = transform;
            cJump = KeyCode.Space;
            cAttack = KeyCode.LeftControl;
            xAxis = "Horizontal";
        }
        else if (player == NPlayer.Player2)
        {
            pmPlayerAux = Instantiate(pmPlayer2, transform.position, Quaternion.identity) as GameObject;
            pmPlayerAux.transform.parent = transform;
            cJump = KeyCode.RightControl;
            cAttack = KeyCode.RightShift;
            xAxis = "Horizontal2";
        }*/
    }

    void OnDisable()
    {
        Destroy(pmPlayerAux);
    }

    void Update()
	{
		float x = 0;
        //if (player == NPlayer.Player1) x = Input.GetAxis ("Horizontal");
        //else x = Input.GetAxis ("Horizontal2");
        x = Input.GetAxis(xAxis);

		if (direccion == DireccionH.Derecha && x < 0) {
			direccion = DireccionH.Izquierda;
			Flip ();
		} else if (direccion == DireccionH.Izquierda && x > 0) {
			direccion = DireccionH.Derecha;
			Flip ();
		}

		Vector3 vSpeed = new Vector3 (VelocidadH * x, 0, 0);
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPos.x > 0 && direccion == DireccionH.Izquierda || viewPos.x < 1 && direccion == DireccionH.Derecha)
            transform.Translate(vSpeed * Time.deltaTime);

		if (Input.GetKeyDown (cJump)) {
			if (ig.isGrounded()) 
				rb.velocity = new Vector2 (rb.velocity.x, VelocidadV);
		}
		if (Input.GetKeyDown(cAttack)) {
			ss.Execute();
		}
        if (actualHp <= 0)
        {
            ResetPlayer();
        }
	}

	void Flip () {
		Vector3 vFlip = new Vector3 (-1*sprite.localScale.x, sprite.localScale.y, sprite.localScale.z);
		sprite.localScale = vFlip;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.enabled)
        {
            if (collision.gameObject.tag == "Unplayer")
            {
                //collision.gameObject.GetComponent<PlayerMovement>().player = this.player;
                //collision.gameObject.tag = gameObject.tag;
                //collision.gameObject.GetComponent<PlayerMovement>().enabled = true;

                //Destroy(gameObject);
            }
        }
        if (this.enabled)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                doDamage(20f);
            }
        }
    }

	public float getHpPorcen () {
		return actualHp / MaxHp;
	}

    public void ResetPosition  ()
    {
        transform.position = respawnPoints[Random.Range(0, respawnPoints.Length - 1)].transform.position;
    }

    public void ResetPlayer ()
    {
        actualHp = MaxHp;
        ResetPosition();
    }

	public void doDamage (float dmg) {
		actualHp -= dmg;
		anim.SetTrigger ("damaged");
        GameObject inst = Instantiate(lblDamage, transform.position + new Vector3(0.5f,0,0), Quaternion.identity) as GameObject;
        inst.GetComponent<Text>().text = dmg+"";
        inst.transform.SetParent( pmPlayerAux.transform.Find("Canvas").transform);
		if (actualHp < 0)
			actualHp = 0;
	}
}
