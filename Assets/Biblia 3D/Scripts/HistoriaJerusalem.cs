using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoriaJerusalem : MonoBehaviour {
	public static HistoriaJerusalem instance;
	public GameObject[] balao;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	public void ChangeBalao(int i)
	{
		if (i > 0)
		{
			balao[i-1].SetActive(false);
			balao[i].SetActive(true);
		}
	}
}
