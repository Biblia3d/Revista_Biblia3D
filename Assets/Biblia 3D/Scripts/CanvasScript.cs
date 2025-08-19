using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {

    public GameObject cam;
	public GameObject canvas;
	// Use this for initialization
	void Start () {
        if (cam == null)
            cam = GameObject.FindWithTag("ARCam");

        GetComponent<Canvas>().worldCamera = cam.GetComponent<Camera>();

        if (canvas == null)
		    canvas = GameObject.FindWithTag("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisableCam()
    {
        cam.SetActive(false);
		canvas.SetActive(false);
    }

    public void EnableCam()
    {
        cam.SetActive(true);
    }
}
