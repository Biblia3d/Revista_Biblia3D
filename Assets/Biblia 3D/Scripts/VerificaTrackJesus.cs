using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VerificaTrackJesus : MonoBehaviour {

    public GameObject davi, golias, jogo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.GetComponent<Biblia3dTrackableEventHandler>().isTracking)
        {
            golias.GetComponent<ImageTargetBehaviour>().enabled = false;
            davi.GetComponent<ImageTargetBehaviour>().enabled = false;
            jogo.GetComponent<ImageTargetBehaviour>().enabled = false;

        }
        else
        {
            golias.GetComponent<ImageTargetBehaviour>().enabled = true;
            davi.GetComponent<ImageTargetBehaviour>().enabled = true;
            jogo.GetComponent<ImageTargetBehaviour>().enabled = true;

        }
	}
}
