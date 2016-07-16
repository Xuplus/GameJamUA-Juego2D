using UnityEngine;
using System.Collections;
using System;

public class Vidas : MonoBehaviour {

    public int vidas;

	// Use this for initialization
	void Start () {
	    
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
        Debug.Log("Game Over");
    }

    public void Damaged()
    {
        vidas--;
    }

    int GetVidas()
    {
        return vidas;
    }

    void SetVidas(int num)
    {
        vidas = num;
    }

    void AddVidas(int num)
    {
        vidas += num;
    }
}
