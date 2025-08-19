using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Tick : MonoBehaviour {
	
	public GameObject tick1, tick2, tick3, cheklist;
	private Scene scene;

	// Use this for initialization
	void Start () {
		scene = SceneManager.GetActiveScene ();
	}
	
	// Update is called once per frame
	void Update () {

		switch (scene.name) {

		case "Scene 2":
			if (PlayerPrefs.GetInt ("TocouDavi") == 1 || PlayerPrefs.GetInt ("TocouBush") >= 1|| PlayerPrefs.GetInt ("TocouRock") >= 1||PlayerPrefs.GetInt ("TocouTree") >= 1&& PlayerPrefs.GetInt ("Tick1Scene2") >= 1) {
				tick1.SetActive (true);
				PlayerPrefs.SetInt ("Tick1Scene2", 1);
			}
			if (PlayerPrefs.GetInt ("TocouOvelha") >= 1 && PlayerPrefs.GetInt ("Tick2Scene2") != 1) {
				tick2.SetActive (true);
				PlayerPrefs.SetInt ("Tick2Scene2", 1);
			}
			if (PlayerPrefs.GetInt("Ouviu02")!=0&& PlayerPrefs.GetInt ("Tick3Scene2") != 1) {
				tick3.SetActive (true);
				PlayerPrefs.SetInt ("Tick3Scene2", 1);
			}
			break;
		}

		if (tick1.activeSelf==true && tick2.activeSelf==true && tick3.activeSelf==true) {
			
			Invoke ("DisableTicks", 1.3f);
		}
	}

	void DisableTicks(){
		tick1.SetActive(false);
		tick2.SetActive(false);
		tick3.SetActive(false);
		EnableChecklist();
	}

	void EnableChecklist(){
		cheklist.SetActive (true);
		Invoke ("EnableChecklistOut", 3);

	}
	void EnableChecklistOut(){
		cheklist.SetActive (false);
	}
}
