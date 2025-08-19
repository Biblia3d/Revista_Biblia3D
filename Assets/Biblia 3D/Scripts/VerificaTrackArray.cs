using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class VerificaTrackArray : MonoBehaviour {

    public GameObject[] track;
    public GameObject[] disable;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < track.Length; i++)
        {
            if (track[i].GetComponent<Biblia3dTrackableEventHandler>().isTracking)
            {
                for(int j = 0; j < disable.Length; j++)
                {
                    disable[j].GetComponent<ImageTargetBehaviour>().enabled = false;
                }
            }

        }
        for (int i = 0; i < track.Length; i++)
        {
            if (!track[i].GetComponent<Biblia3dTrackableEventHandler>().isTracking)
            {
                for (int j = 0; j < disable.Length; j++)
                {
                    disable[j].GetComponent<ImageTargetBehaviour>().enabled = true;
                }
            }

        }

    }
}
