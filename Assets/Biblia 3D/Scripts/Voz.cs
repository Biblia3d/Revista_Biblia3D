using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Vuforia;

public class Voz : MonoBehaviour {
	private GameObject story, page;
	public GameObject voz, seta;
	// Use this for initialization
	void Start () {
		story = GameObject.FindWithTag ("Story_Manager");
		gameObject.GetComponent<Button> ().interactable = true;
		page = GameObject.FindWithTag ("Story_Manager");
	}
	
	void Enable(){
		voz.GetComponent<Button> ().interactable = true;
		seta.SetActive (true);
	}

	public void Play(){
		if (page.GetComponent<Story_Manager> ().atualTrack == "08") {
			gameObject.GetComponent<Button> ().interactable = false;
			//Invoke ("Enable", story.GetComponent<Story_Manager> ().storySounds [3].clip.length);
		}
	}

}
