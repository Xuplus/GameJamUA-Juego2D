using UnityEngine;
using System.Collections;

public class armaMele : MonoBehaviour {

    private float spawnTime;
	// Use this for initialization
	void Start () {
        spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - spawnTime >= 0.1) Destroy(this.gameObject);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("muere");
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemigo"))
        {
            Destroy(col.gameObject);
        }
    }
}
