using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("Remover esta classe quando nao for utilizada")]
public class Disable_GameObject : MonoBehaviour {
    public float time;
    public bool ivk = false;
	
	void OnEnable () {
        Invoke("Disable", time);
	}
	
	void Disable () {
        gameObject.SetActive(false);
	}

    private void OnDisable()
    {
        if (ivk)
            CancelInvoke("Disable");
    }
}
