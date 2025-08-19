using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceScript : MonoBehaviour {

	public static InterfaceScript Instance;

	public GameObject interfaceX, daviX, canvas, menuPanel, seta;

	public Biblia3dTrackableEventHandler pag;

	public bool active = false, mostrou = false;
    
	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (pag!=null&&pag.isTracking == true) {
            if (daviX != null)
			    daviX.SetActive (true);
			interfaceX.SetActive (false);
		} else if(!active){
            if (daviX != null)
                daviX.SetActive (false);
			interfaceX.SetActive (true);
		}
		if (pag!=null&&pag.isTracking == true&&seta!=null&&!mostrou) {
            if (seta != null)
			    seta.SetActive (true);
			mostrou = true;
		}
	}
	public void Capture(){
		active = true;
		canvas.SetActive (false);
        if(menuPanel!=null)
            menuPanel.SetActive(false);
        Invoke ("Disable", 0.5f);
	}

	void Disable(){
		canvas.SetActive (true);
        if (menuPanel != null)
            menuPanel.SetActive(true);
        active = false;
	}


}
