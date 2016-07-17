using UnityEngine;
using System.Collections;

public class Atacar : MonoBehaviour {

    public GameObject cajaEspada;
    private bool letal;
    private Animator anim;
    private GameObject jugador;
    private float lastTimeAttack;
    public float freqAtaque;
    private bool gameover;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        jugador = GameObject.FindGameObjectWithTag("Player");
        lastTimeAttack = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameover)
        {
            if (Input.GetAxis("Fire1") >= 0.7)
            {
                AtacarMele();
            }
        }
	}

    void AtacarMele()
    {
        Debug.Log(lastTimeAttack + " - " + freqAtaque);
        if (lastTimeAttack + freqAtaque <= Time.time)
        {
            anim.SetTrigger("atacarmele");
            letal = true;
            if (jugador.transform.localScale.x > 0)
                Instantiate(cajaEspada, transform.position, Quaternion.Euler(0, 0, 0));
            else Instantiate(cajaEspada, transform.position, Quaternion.Euler(0, 0, 180));
            lastTimeAttack = Time.time;
        }
    }

    void SetLetal(bool b)
    {
        letal = b;
    }

    bool GetLetal()
    {
        return letal;
    }

    public void GameOver()
    {
        gameover = true;
    }
}
