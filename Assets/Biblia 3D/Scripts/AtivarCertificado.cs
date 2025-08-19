using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarCertificado : MonoBehaviour {
    public GameObject cert;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Ativar()
    {
        cert.SetActive(true);
    }
}
