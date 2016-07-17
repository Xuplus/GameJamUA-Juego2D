using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Control_Juego : MonoBehaviour {
    private bool gameover;
    public Canvas canvas;
    private int killcount;
    public Text puntuacion;

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

    public void Tienda()
    {
        SaveData();
        SceneManager.LoadScene(2);
    }

    public void AddKill(int i)
    {
        killcount += i;
        puntuacion.text = "Score: " + killcount;
    }

    public void SaveData()
    {

    }
}
