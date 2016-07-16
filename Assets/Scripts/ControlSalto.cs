using UnityEngine;
using System.Collections;

public class ControlSalto : MonoBehaviour {
	ControlJugador padre;
	// Use this for initialization
	void Start () {
		padre = transform.parent.gameObject.GetComponent<ControlJugador>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer("Suelo")) {
			padre.SetEnSuelo (true);
		}
	}

	void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer("Suelo")) {
			padre.SetEnSuelo (false);
		}
	}
}
