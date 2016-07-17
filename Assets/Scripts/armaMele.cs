using UnityEngine;
using System.Collections;

public class armaMele : MonoBehaviour {

    private Control_Juego control;
    private float spawnTime;
    private bool gameover;

    // Use this for initialization
    void Start () {
        spawnTime = Time.time;
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<Control_Juego>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - spawnTime >= 0.08) Destroy(this.gameObject);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("muere");
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemigo"))
        {
            Destroy(col.gameObject);
            control.AddKill(1);
        }
    }

    void GameOver()
    {
        gameover = true;
    }
}
