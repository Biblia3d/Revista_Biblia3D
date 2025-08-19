using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chao : MonoBehaviour {

    Vector3 posIni;
	// Use this for initialization
	void Start(){
        posIni = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = posIni;
	}
}
