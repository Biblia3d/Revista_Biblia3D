using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuforiaStarted : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //var vInit = Vuforia.VuforiaARController.Instance;
        //vInit.RegisterVuforiaInitializedCallback(OnVuforiaStarted);
    }

    public void OnVuforiaStarted()
    {
        //Vuforia.CameraDevice.Instance.SetFocusMode(Vuforia.CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
