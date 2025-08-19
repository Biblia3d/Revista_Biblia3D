using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class VerificaTrack : MonoBehaviour {

    public GameObject golias,davi, jesus, jogo;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (golias.GetComponent<Biblia3dTrackableEventHandler>().isTracking||davi.GetComponent<Biblia3dTrackableEventHandler>().isTracking)
        {
           jogo.GetComponent<ImageTargetBehaviour>().enabled = false;
           jesus.GetComponent<ImageTargetBehaviour>().enabled = false;

        }
        else
        {
            jogo.GetComponent<ImageTargetBehaviour>().enabled = true;
            jesus.GetComponent<ImageTargetBehaviour>().enabled = true;

        }
    }
}
