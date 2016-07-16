using UnityEngine;
using System.Collections;

public class ControlJugador : MonoBehaviour {

	// Use this for initialization
	public int speed;
	public int jump;
	private Rigidbody2D body;
	private bool enSuelo;
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 aux = body.velocity;
		body.velocity = new Vector3 (speed * Input.GetAxis("Horizontal"), aux.y, aux.z);

		if (Input.GetKey(KeyCode.Space) && enSuelo) {
			aux = body.velocity;
			body.velocity = new Vector3 (aux.x, jump, aux.z);
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer("Suelo")) {
			enSuelo = true;
		}
	}

	void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer("Suelo")) {
			enSuelo = false;
		}
	}
}
