using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagGame_Controller : MonoBehaviour {
	public GameObject uiPag, buttons;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		uiPag.SetActive(GetComponent<Biblia3dTrackableEventHandler>().isTracking);
		//buttons.SetActive (!GetComponent<Vuforia.DefaultTrackableEventHandler> ().isTracking);

	}
}
