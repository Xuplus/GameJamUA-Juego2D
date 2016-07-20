using UnityEngine;
using System.Collections;
using System;

public class Vidas : MonoBehaviour {

    public int vidas;
    private GenerateEnemy generator;
    public Control_Juego control;

	// Use this for initialization
	void Start () {
        generator = GameObject.FindGameObjectWithTag("EnemyGenerator").GetComponent<GenerateEnemy>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (vidas <= 0)
        {
            GameOver();
        }
	}

    private void GameOver()
    {
        //Debug.Log("Game Over");
        generator.setGameOver(true);
        control.setGameOver(true);
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.freezeRotation = false;
        GetComponent<ControlJugador>().GameOver();
        GameObject.FindGameObjectWithTag("Mano").GetComponent<Atacar>().GameOver();
    }

    public void Damaged()
    {
        vidas--;
    }

    public int GetVidas()
    {
        return vidas;
    }

    public void SetVidas(int num)
    {
        vidas = num;
    }

    public void AddVidas(int num)
    {
        vidas += num;
    }

    public void Tienda()
    {

    }
}
