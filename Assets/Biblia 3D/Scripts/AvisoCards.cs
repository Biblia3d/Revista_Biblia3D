using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvisoCards : MonoBehaviour {

    public GameObject dica;

    private void Start()
    {
        if (PlayerPrefs.GetInt("MostrouDica") <= 2)
        {
            dica.SetActive(true);
        }
    }
    void OnEnable () {
        if (PlayerPrefs.GetInt("MostrouDica") <= 2)
        {
            PlayerPrefs.SetInt("MostrouDica", PlayerPrefs.GetInt("MostrouDica") + 1);
        }
	}
	
}
