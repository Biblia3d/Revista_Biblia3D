using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vuforia;
public class Bird_Control : MonoBehaviour {

	private Biblia3dTrackableEventHandler tracker;
    public Sound_Manager sound_Manager;
    // Use this for initialization
    void Start () {
		tracker = GetComponentInParent<Biblia3dTrackableEventHandler> ();
        if (sound_Manager == null)
        {
            sound_Manager = Sound_Manager.Instance;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PlaySound(string clipName){
		if (tracker != null && !tracker.isTracking)
			return;
        sound_Manager.PlayOneShot (clipName);
	}
}
