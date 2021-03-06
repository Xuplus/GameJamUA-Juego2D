﻿using UnityEngine;
using System.Collections;
using System;

public class ControlJugador : MonoBehaviour {

	// Use this for initialization
	public int speed;
	public int jump;
	private Rigidbody2D body;
	private bool enSuelo;
    private float sentidoSprit;
	private Vector3 escala;
    //public AudioSource sonidoMuerte;

    Animator anim;
    private bool gameover;

    void Start () {
		body = GetComponent<Rigidbody2D> ();
        sentidoSprit = transform.localScale.x;
		escala = transform.localScale;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameover)
        {
            if (enSuelo) anim.SetTrigger("onground");
            Vector3 aux = body.velocity;
            float sentido = Input.GetAxis("Horizontal");
            body.velocity = new Vector3(speed * sentido, aux.y, aux.z);
            if (sentido > 0.5 || sentido < -0.5)
            {
                anim.SetBool("running", true);
            }
            else
            {
                anim.SetBool("running", false);
            }

            //Girar el sprit del jugador a la dirección en la que está
            if (sentido > 0.2)
            {
                transform.localScale = new Vector3(sentidoSprit, escala.y, escala.z);
            }
            else if (sentido < -0.2)
            {
                transform.localScale = new Vector3(-sentidoSprit, escala.y, escala.z);
            }

            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && enSuelo)
            {
                aux = body.velocity;
                body.velocity = new Vector3(aux.x, jump, aux.z);
                anim.SetTrigger("jump");
            }
        }
	}

    internal void GameOver()
    {
        anim.ResetTrigger("onground");
        anim.ResetTrigger("running");
        anim.ResetTrigger("jump");
        if (!gameover) GetComponent<AudioSource>().Play();
        gameover = true;
    }

    //	void OnCollisionEnter2D (Collision2D col) {
    //		if (col.gameObject.layer == LayerMask.NameToLayer("Suelo")) {
    //			enSuelo = true;
    //		}
    //	}
    //
    //	void OnCollisionExit2D (Collision2D col) {
    //		if (col.gameObject.layer == LayerMask.NameToLayer("Suelo")) {
    //			enSuelo = false;
    //		}
    //	}

    public void SetEnSuelo(bool valor){
		enSuelo = valor;
	}
    
}
