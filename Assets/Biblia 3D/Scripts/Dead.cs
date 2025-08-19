using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour {
	int cont=1000000;
	bool i;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		while(i){
			cont*=cont;
			Debug.Log (cont);
		}
	}
}
