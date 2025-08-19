using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vuforia;

[Obsolete("Depreciado, deve ser substituido por um componente que faca mais sentido")]
public class Mute : MonoBehaviour {
    public static Mute instance;
	public AudioSource AudioSrc;
	public GameObject buttonMuteOn, buttonMuteOff, buttonMuteOn1, buttonMuteOff1;
    private Biblia3dTrackableEventHandler tracker;

    // Use this for initialization
    void Start () {
        instance = this;
        tracker = GetComponentInParent<Biblia3dTrackableEventHandler>();

        if (PlayerPrefs.GetInt ("Mute") == 0) {
            if (AudioSrc != null) AudioSrc.mute = false;
            if (buttonMuteOff != null)
			    buttonMuteOff.SetActive (true);

            if (buttonMuteOn != null)
			    buttonMuteOn.SetActive (false);

            if (buttonMuteOff1 != null && buttonMuteOn1 != null)
            {
                buttonMuteOff1.SetActive(true);
                buttonMuteOn1.SetActive(false);
            }

        } else {
            if (AudioSrc != null) AudioSrc.mute = true;
			if(buttonMuteOn!=null)
				buttonMuteOn.SetActive (true);
			if(buttonMuteOff!=null)
				buttonMuteOff.SetActive (false);
            if (buttonMuteOff1 != null && buttonMuteOn1 != null)
            {
                buttonMuteOn1.SetActive(true);
                buttonMuteOff1.SetActive(false);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Mute") == 0) {
            if (AudioSrc != null) AudioSrc.mute = false;
		}
		else
            if (AudioSrc != null) AudioSrc.mute = true;

        if (tracker != null)
        {
            if (AudioSrc != null)
            {
                if (tracker.isTracking && !AudioSrc.isPlaying)
                {
                    AudioSrc.Play();
                }
                if (!tracker.isTracking && AudioSrc.isPlaying)
                {
                    AudioSrc.Stop();
                }
            }
        }

    }

	public void muteOn(){
		PlayerPrefs.SetInt ("Mute", 1);

        if (buttonMuteOn != null)
		    buttonMuteOn.SetActive(true);

        if (buttonMuteOff != null)
		    buttonMuteOff.SetActive (false);

        if (buttonMuteOff1 != null && buttonMuteOn1 != null)
        {
            buttonMuteOn1.SetActive(true);
            buttonMuteOff1.SetActive(false);
        }
    }
	public void muteOff(){
		PlayerPrefs.SetInt ("Mute", 0);

        if (buttonMuteOff != null)
		    buttonMuteOff.SetActive(true);

        if (buttonMuteOn != null)
		    buttonMuteOn.SetActive (false);

        if (buttonMuteOff1 != null && buttonMuteOn1 != null)
        {
            buttonMuteOff1.SetActive(true);
            buttonMuteOn1.SetActive(false);
        }
    }
}
