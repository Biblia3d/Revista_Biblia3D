using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sombra  : MonoBehaviour {

	public static Sombra instance;
	public Vector3 posIni;
	public GameObject davi;
	public float z;
	bool ok;
	// Use this for initialization
	void Start(){
		instance = this;   
	}
	
	// Update is called once per frame
	void Update () {
		posIni = davi.transform.localPosition;
		if (!ok)
		{
			transform.localPosition = new Vector3(posIni.x, posIni.y, z);
		}
		else
		{
			transform.localPosition = new Vector3(posIni.x, posIni.y, -0.19f);

		}
	}

	public void GrudarEmGolias()
	{
		ok = true;
	}
}
