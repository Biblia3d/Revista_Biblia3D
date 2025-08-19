using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legendas : MonoBehaviour {
    public float inicio, fim;
    public GameObject msg;

	// Use this for initialization
	void OnEnable () {
        Invoke("Ativar", inicio);
	}
	
	// Update is called once per frame
	
    void Ativar()
    {
        
        msg.SetActive(true);
        Invoke("Desativar", fim);
    }

    void Desativar()
    {
        msg.SetActive(false);
    }
}
