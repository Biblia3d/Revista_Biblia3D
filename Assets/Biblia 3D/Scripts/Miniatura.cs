using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vuforia;
public class Miniatura : MonoBehaviour {

	public GameObject track;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CallEnable(){
		if (track.GetComponent<Biblia3dTrackableEventHandler> ().isTracking)
		Invoke ("Enable", 0.5f);
	}

	void Enable(){
		
			anim.SetTrigger("Change");
			
	
	}
}
