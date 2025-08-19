using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDavi : MonoBehaviour {
    public GameObject davi;
	// Use this for initialization
	void Start () {
        Invoke("Active", 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Active()
    {
        davi.SetActive(true);
    }
}
