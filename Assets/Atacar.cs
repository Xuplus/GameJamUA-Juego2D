using UnityEngine;
using System.Collections;

public class Atacar : MonoBehaviour {

    private bool letal;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetAxis("Fire1") >= 0.7)
        {
            AtacarMele();
        }
	}

    void AtacarMele()
    {
        anim.SetTrigger("atacarmele");
        letal = true;
    }

    void SetLetal(bool b)
    {
        letal = b;
    }

    bool GetLetal()
    {
        return letal;
    }
}
