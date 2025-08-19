using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud_Text : MonoBehaviour {

	public Text score, coin, stone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		score.GetComponent<Text> ().text = PlayerPrefs.GetInt ("Score").ToString();
		stone.GetComponent<Text> ().text = PlayerPrefs.GetString ("Stone");
		coin.GetComponent<Text> ().text = PlayerPrefs.GetInt ("Coin").ToString();
	}
}
