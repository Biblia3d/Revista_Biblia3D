using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vuforia;
public class Seta : MonoBehaviour {
	public GameObject seta,track;
	public bool ok=false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (track.GetComponent<Biblia3dTrackableEventHandler>().isTracking){
			if (PlayerPrefs.GetInt ("Ouviu") == 0 && seta != null) {
				Invoke ("Enable", 2);
			}
		}
		if (!track.GetComponent<Biblia3dTrackableEventHandler>().isTracking){
			if (seta != null) {
				CancelInvoke ("Disable");
				DisableOk ();
			}
		}
			
	}

	public void Disable(){
		PlayerPrefs.SetInt ("Ouviu", 1);
		seta.SetActive (false);
		CancelInvoke ("Disable");
		CancelInvoke ("Enable");
	}
	void DisableOk(){
		seta.SetActive (false);
	}
	void Enable(){
		seta.SetActive (true);
		//Invoke ("Disable", 7);
	}

	public void Ouviu(){
		PlayerPrefs.SetInt ("Ouviu", 1);

	}
}
