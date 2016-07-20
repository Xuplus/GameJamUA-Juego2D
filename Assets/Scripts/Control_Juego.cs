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
    public Text score;
    public bool menuInicio;

	// Use this for initialization
	void Start () {
        if (!menuInicio) canvas.gameObject.SetActive(false);
        else
        {
            LoadData();
            score.text = "RECORD :  " + killcount + "  /  100.000";
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (gameover && Input.GetKeyDown("r"))
        {
            Restart();
        }

        if (menuInicio && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
	}

    public void setGameOver(bool b)
    {
        gameover = b;
        if (gameover) GameOver();
    }

    private void GameOver()
    {
        canvas.gameObject.SetActive(true);
        SaveData();
    }

    public void Tienda()
    {
        SaveData();
        SceneManager.LoadScene(2);
    }

    public void AddKill(int i)
    {
        killcount += i;
        puntuacion.text = "Score: " + killcount + " / 100.000";
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("score", killcount);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            killcount = PlayerPrefs.GetInt("score");

        }
    }

    public void Restart()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
}
