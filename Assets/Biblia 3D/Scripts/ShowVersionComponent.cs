using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Exibe a versao da versao do jogo
 */
public class ShowVersionComponent : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
        text.text = Application.version;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
