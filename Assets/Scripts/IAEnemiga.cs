using UnityEngine;
using System.Collections;

public class IAEnemiga : MonoBehaviour {
	public int speed;
	public int jump;
	private Rigidbody2D body;
	private GameObject player;
	int XDirection;
	int YDirection;
	private float distance;
    public float distanciaAtaque;
	private Animator anim;


	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		player = GameObject.FindWithTag ("Player");
		anim = GetComponentInChildren <Animator> ();
	}

    // 146 grados hay que restar a la direccion donde miras

	// Update is called once per frame
	void Update () {
		Vector3 currentVelocity = body.velocity;
		Vector3 playerPosition = player.transform.position;
		Vector3 enemyPosition = body.position;

		distance = Vector3.Distance (playerPosition, enemyPosition);

		if (distance < distanciaAtaque) {
			anim.SetBool("atacando", true);
		} else {
			anim.SetBool("atacando", false);
		}

        /*if (playerPosition.x - enemyPosition.x > 0) {
			XDirection = 1;
		} else {
			XDirection = -1;
		}
		if (playerPosition.y - enemyPosition.y > 0) {
			YDirection = 1;
		} else {
			YDirection = -1;
		}*/

        //body.velocity = new Vector3(speed * XDirection, speed * YDirection,currentVelocity.z);

        Vector3 distancia = player.transform.position - transform.position;
        Vector3 modulo = distancia.normalized;

        body.velocity = modulo * speed;

        //transform.rotation = Quaternion.LookRotation(modulo);
        

        float rot_z = Mathf.Atan2(modulo.y, modulo.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("Colisiona el enemigo");
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Vidas>().Damaged();
        }
    }
}
