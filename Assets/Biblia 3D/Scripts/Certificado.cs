using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameToolkit.Localization;

public class Certificado : MonoBehaviour {
    public float time;
    public LocalizedTextBehaviour msg;
    public GameObject certificado;
    public GameObject tela;
    public GameObject next;
    public GameObject subtitle;
    public LocalizedText LocalizedText;

	// Use this for initialization
	void Start () {
        Invoke("TrocarMsg", 5);
	}
	
	// Update is called once per frame
    void CallDescer()
    {
        Invoke("Descer", time);
    }

	void Descer()
    {
        if (subtitle != null)
        {
            subtitle.SetActive(true);
        }

        certificado.GetComponent<Animator>().SetTrigger("Play");
        Invoke("Tela", 7);
    }

    void Next()
    {
        next.SetActive(true);
    }

    void TrocarMsg()
    {
        msg.LocalizedAsset = LocalizedText;

        CallDescer();
    }

    void Tela()
    {
        tela.SetActive(true);
    }
}
