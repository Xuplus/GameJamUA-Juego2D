using UnityEngine;
using System.Collections;
using System;

public class Control_Juego : MonoBehaviour {
    private bool gameover;
    public Canvas canvas;

	// Use this for initialization
	void Start () {
        canvas.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setGameOver(bool b)
    {
        gameover = b;
        if (gameover) GameOver();
    }

    private void GameOver()
    {
        canvas.gameObject.SetActive(true);
    }
}
