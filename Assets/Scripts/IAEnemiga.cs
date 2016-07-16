using UnityEngine;
using System.Collections;

public class IAEnemiga : MonoBehaviour {
	public int speed;
	public int jump;
	private Rigidbody2D body;
	private GameObject player;
	int XDirection;
	int YDirection;


	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		player = GameObject.FindWithTag ("Player");
	}

    // 146 grados hay que restar a la direccion donde miras

	// Update is called once per frame
	void Update () {
		Vector3 currentVelocity = body.velocity;
		Vector3 playerPosition = player.transform.position;
		Vector3 enemyPosition = body.position;

		if (playerPosition.x - enemyPosition.x > 0) {
			XDirection = 1;
		} else {
			XDirection = -1;
		}
		if (playerPosition.y - enemyPosition.y > 0) {
			YDirection = 1;
		} else {
			YDirection = -1;
		}
			
		body.velocity = new Vector3(speed * XDirection, speed * YDirection,currentVelocity.z);
	}
}
