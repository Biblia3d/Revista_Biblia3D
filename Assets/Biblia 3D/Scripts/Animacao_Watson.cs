using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animacao_Watson : MonoBehaviour {
    public Sprite[] screens;
    public int fps = 0;
    public bool a = false;
    public float frames = 15;
	// Use this for initialization
	void Start () {
		
	}

    void FixedUpdate()
    {
        GetComponent<Image>().sprite = screens[fps];
        if (fps > 48)
        {
            fps = 0;
        }
        fps = (int)(Time.time*frames)%screens.Length;
    }

    // Update is called once per frame
    void Animate () {
		for(int i = 0; i < screens.Length; i++)
        {
            GetComponent<Image>().sprite = screens[i];
            print("Entrou");
        }
        a = false;
	}
}
