using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

[Obsolete("Classe mal construida")]
public class Checklist : MonoBehaviour {

	public GameObject tick1, tick2, tick3;
	public GameObject check1;
	public bool ok=false, task1 = false, task2 = false, task3 = false;
    public float time;
	private Scene scene;
	// Use this for initialization
	void Start () {
		scene = SceneManager.GetActiveScene ();
	}
	
	// Update is called once per frame
	void Update () {
		switch(scene.name){

		case "Scene 2":
			if ((PlayerPrefs.GetInt ("AchouOvelha") >=1 &&PlayerPrefs.GetInt("TocouTree")>=1&&PlayerPrefs.GetInt("TocouTree")>=1)&&!task1) {
				task1 = true;
				Invoke ("EnableTick3", 0.5f);
				PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 10);
				PlayerPrefs.SetInt ("Tick1Scn2",1);
				print ("Pontuando Tick 1");

			}
			if (PlayerPrefs.GetInt ("TocouOvelha") >= 1&&!task2) {
				task2 = true;
				Invoke ("EnableTick2", 0.5f);
				PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 10);
				PlayerPrefs.SetInt ("Tick2Scn2",1);
				print ("Pontuando Tick 2");

			}
			if (PlayerPrefs.GetInt ("Ouviu02") == 1&&!task3) {
				task3 = true;
				EnableTick1();
				PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 10);
				PlayerPrefs.SetInt ("Tick3Scn2",1);
				print ("Pontuando Tick 3");


			}

			if(tick1.activeSelf&&tick2.activeSelf&&tick3.activeSelf&&!ok){
				PlayerPrefs.SetInt ("CompleteScene2", 1);
				Invoke ("Parabens", time);
				Invoke ("naoExibir", 2.1f);
				ok = true;
				print ("Pontuando AllTick");
			}
			break;

		case "Scene 3":
			if (PlayerPrefs.GetInt ("Ouviu03")==1&&PlayerPrefs.GetInt ("Ouviu04")==1) {
				tick1.SetActive (true);
				PlayerPrefs.SetInt ("Tick1Scn3",1);
			}
			if (PlayerPrefs.GetInt ("DeadLeao") == 1) {
				tick2.SetActive (true);
				PlayerPrefs.SetInt ("Tick2Scn3",1);
			}
			if (PlayerPrefs.GetInt ("DeadUrso") == 1) {
				tick3.SetActive (true);
				PlayerPrefs.SetInt ("Tick3Scn3",1);
			}

			if(PlayerPrefs.GetInt ("Ouviu03")==1&&PlayerPrefs.GetInt ("Ouviu04")==1&&PlayerPrefs.GetInt ("DeadLeao") == 1&&PlayerPrefs.GetInt ("DeadUrso") == 1){
				PlayerPrefs.SetInt ("CompleteScene3", 1);
			}
			break;

		case "Scene 4":
			if ((PlayerPrefs.GetInt ("TocouBarraca") > 2 || PlayerPrefs.GetInt ("TocouRock_LG_Scene4") > 0 || PlayerPrefs.GetInt ("TocouRock_LG_01_Scene4") > 0)&&!task1) {
				task1 = true;
				Invoke ("EnableTick3", 0.5f);
				PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 10);
				PlayerPrefs.SetInt ("Tick1Scn4",1);
			}
			if (PlayerPrefs.GetInt ("CertaResposta") >= 3 && !task2) {
				task2 = true;
				Invoke ("EnableTick2", 0.5f);
				PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 10);
				PlayerPrefs.SetInt ("Tick2Scn4",1);
				//ok = true;
			}
			if (PlayerPrefs.GetInt ("Ouviu06") == 1&&!task3) {
				task3 = true;
				EnableTick1();
				PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 10);
				PlayerPrefs.SetInt ("Tick3Scn4",1);
			}
			if (tick1.activeSelf && tick2.activeSelf && tick3.activeSelf && !ok&&PlayerPrefs.GetInt("Scene 4")==0) {
				PlayerPrefs.SetInt ("CompleteScene4", 1);
				Invoke ("Parabens", time);
				Invoke ("naoExibir", 2.1f);
				ok = true;
			}
			break;
			case "Scene 5":
			if ((PlayerPrefs.GetInt ("TocouGoliasChallenge") >0||PlayerPrefs.GetInt ("TocouDaviArmor") >0)&&!task1) {
				task1 = true;
				tick2.SetActive (true);
				PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 10);
				PlayerPrefs.SetInt ("Tick2Scn5",1);
			}
			/*if (PlayerPrefs.GetInt ("Ouviu081") >0&&!task2) {
				task2 = true;
				tick2.SetActive (true);
				PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 10);
				PlayerPrefs.SetInt ("Tick2Scn5",1);
			}*/
			if (PlayerPrefs.GetInt ("Ouviu08") == 1&&!task3) {
				task3 = true;
				tick1.SetActive (true);
				PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 10);
				PlayerPrefs.SetInt ("Tick1Scn5",1);
			}
			if (tick1.activeSelf && tick2.activeSelf && !ok&&PlayerPrefs.GetInt("Scene 5")==0) {
				PlayerPrefs.SetInt ("CompleteScene5", 1);
				//Invoke ("Parabens", time);
				Invoke ("naoExibir", 2.1f);
				ok = true;
			}
			break;

		case "Scene 6":
			if (PlayerPrefs.GetInt ("Ouviu10") >= 1) {
				//tick1.SetActive (true);
				PlayerPrefs.SetInt ("Tick1Scn6",1);
			}
			if (PlayerPrefs.GetInt ("TocouOvelha") == 3) {
				//tick2.SetActive (true);
				PlayerPrefs.SetInt ("Tick2Scn6",1);
			}
			if (PlayerPrefs.GetInt ("Ouviu02") == 1) {
				//tick3.SetActive (true);
				PlayerPrefs.SetInt ("Tick3Scn6",1);
			}

			if(PlayerPrefs.GetInt ("Ouviu10")>=1&&PlayerPrefs.GetInt ("Escudo") == 1&&PlayerPrefs.GetInt ("DeadGolias") == 1){
				PlayerPrefs.SetInt ("CompleteScene6", 1);
			}
			break;
		}


	}

	public void Check(){
		if (gameObject.activeSelf == true) {
			gameObject.GetComponent<Animator> ().SetTrigger ("Change");
		} else
			gameObject.SetActive (true);
	}

//	public void Enable(){
//		check1.SetActive (true);
//		//ok = 1;
//	}

	public void Disable(){
		gameObject.SetActive (false);
	}

	void EnableTick1(){
		tick1.SetActive (true);
	}
	void EnableTick2(){
		tick2.SetActive (true);
	}
	void EnableTick3(){
		tick3.SetActive (true);
	}

	public void Parabens(){
		check1.SetActive (true);
		ok = true;
	}

	public void PlaySound(){
		GetComponent<AudioSource> ().Play ();
	}

	public void Ouviu(){
		PlayerPrefs.SetInt ("Ouviu081", 1);
	}

	public void Ouviu1(){
		PlayerPrefs.SetInt ("Ouviu04", 1);
	}

	void naoExibir(){
		PlayerPrefs.SetInt (scene.name,1);
	}
}
