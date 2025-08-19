using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Vuforia;
using UnityEngine.UI;

public class AutoFocus2 : MonoBehaviour {

	void Start()
	{
		CameraDevice.Instance.SetFocusMode(
			CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			StartCoroutine (Focus());
		}
	}

	IEnumerator Focus()
	{
		CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
		yield return new WaitForSeconds (1);
		CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}



}
