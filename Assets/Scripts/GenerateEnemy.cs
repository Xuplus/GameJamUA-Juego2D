using UnityEngine;
using System.Collections;

public class GenerateEnemy : MonoBehaviour {

	public GameObject angel;
	public GameObject angelFuerte;
	private int limit;
    private bool gameOver;

	// Use this for initialization
	void Start () {
		limit = 9900;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameOver)
        {
            int XPosition = Random.Range(-6, 6);
            int dice = Random.Range(0, 10000);
            bool hit = dice > limit ? true : false;

            if (hit)
            {
				if (Random.Range(1,10) > 8) {
					createAngelFuerte(new Vector3(XPosition, 5.5f, 0));
				
				} else {
					createAngel(new Vector3(XPosition, 5.5f, 0));	
				}
                
                limit -= 5;
            }
        }
	}

	void createAngel(Vector3 position) {
		Instantiate(angel, position, Quaternion.Euler(0,0,0));
	}

	void createAngelFuerte(Vector3 position) {
		Instantiate(angelFuerte, position, Quaternion.Euler(0,0,0));
	}

    public void setGameOver(bool b)
    {
        gameOver = b;
    }

}
