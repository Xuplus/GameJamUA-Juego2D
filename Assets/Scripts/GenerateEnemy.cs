using UnityEngine;
using System.Collections;

public class GenerateEnemy : MonoBehaviour {

	public GameObject angel;
	private float limit;

	// Use this for initialization
	void Start () {
		limit = 98f;
	}
	
	// Update is called once per frame
	void Update () {
		int XPosition = Random.Range (-6, 6);
		int dice = Random.Range (0, 100);
		bool hit = dice > limit ? true : false;

		if (hit) {
			createAngel(new Vector3(XPosition, 5.5f, 0));
			limit -= 0.2f;
		}
	}

	void createAngel(Vector3 position) {
		Instantiate(angel, position, Quaternion.Euler(0,0,0));
	}


}
