using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("Nao sei para serve, nao parece que nenhum objeto chama este recurso global, se continuar nao encontrando irei remover o componente e a classe")]
public class Photo_Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Photo()
	{
		ScreenshotManager.SaveScreenshot ("Foto","Biblia3D","jpg");
	}

}
