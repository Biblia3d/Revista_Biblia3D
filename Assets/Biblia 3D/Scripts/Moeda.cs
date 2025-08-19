using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour {

    public Biblia3D.Scene.Revista.Moeda.MoedaSceneComponent sceneComponent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DisableObject()
    {
        gameObject.SetActive(false);

        sceneComponent.CloseScene();
    }

    void Enable()
    {
    }

    public void EnableMoeda()
    {
        Invoke("Enable", 4);
    }
}
