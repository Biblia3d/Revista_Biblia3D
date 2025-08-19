using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pag06_Controller : MonoBehaviour {

	public GameObject uiPag06;
	public int cont;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		uiPag06.SetActive(GetComponent<Biblia3dTrackableEventHandler> ().isTracking);
			
	}

	public void InstantiateObjects (GameObject go)
	{
		if(cont<4){
		GameObject aux = Instantiate (go, Vector3.zero, Quaternion.identity) as GameObject;
		Vector3 auxV3 = aux.transform.localScale;
		aux.transform.SetParent(this.transform);
		aux.transform.localPosition = new Vector3(0f,0.023f,0f);
		aux.transform.localRotation = go.transform.localRotation;
		//aux.transform.localScale = auxV3;
		}
		cont++;

	}

}
