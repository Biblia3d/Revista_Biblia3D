using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rei : MonoBehaviour {
    public static Rei instance;
    public GameObject canvas;
	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void fala()
    {
        canvas.SetActive(true);
        Invoke("fim", 3);
    }

    void fim()
    {
        canvas.SetActive(false);
    }

}
