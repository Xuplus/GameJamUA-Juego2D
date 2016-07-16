using UnityEngine;
using System.Collections;

public class ControlJugador : MonoBehaviour {

	// Use this for initialization
	public int speed;
	public int jump;
	private Rigidbody2D body;
	private bool enSuelo;
    private float sentidoSprit;

    Animator anim;
	void Start () {
		body = GetComponent<Rigidbody2D> ();
        sentidoSprit = transform.localScale.x;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (enSuelo) anim.SetTrigger("onground");
		Vector3 aux = body.velocity;
        float sentido = Input.GetAxis("Horizontal");
		body.velocity = new Vector3 (speed * sentido, aux.y, aux.z);
        if (sentido > 0.5 || sentido < -0.5)
        {
            anim.SetBool("running", true);
        }
        else{
            anim.SetBool("running", false);
        }

        //Girar el sprit del jugador a la dirección en la que está
        if ( sentido > 0.2)
        {
            transform.localScale = new Vector3(sentidoSprit,0.2f,0.2f);
        }else if (sentido < -0.2)
        {
            transform.localScale = new Vector3(-sentidoSprit, 0.2f, 0.2f);
        }

		if (Input.GetKey(KeyCode.Space) && enSuelo) {
			aux = body.velocity;
			body.velocity = new Vector3 (aux.x, jump, aux.z);
            anim.SetTrigger("jump");
		}
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
