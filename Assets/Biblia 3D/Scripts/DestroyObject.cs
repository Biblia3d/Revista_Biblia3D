using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

	public float time;
    public bool byTime = true;
	// Use this for initialization
	void Start () {
        if(byTime)
		Invoke ("DestroyGameObject", time);
		
	}
	
	public void DestroyGameObject(){
		Destroy(this.gameObject);
	}

}
