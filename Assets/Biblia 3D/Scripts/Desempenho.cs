using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Desempenho : MonoBehaviour {
	public GameObject t1,t2,t3,t4,t5,t6,t7,t8,t9,t10,t11,t12,t13,t14,t15, msg;
	public GameObject txt;
	public bool ok = false;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("CompleteScene2") == 1) {
			t1.SetActive (true);
			t2.SetActive (true);
			t3.SetActive (true);
		} else if (PlayerPrefs.GetInt ("CompleteScene2") == 0) {
			if(PlayerPrefs.GetInt ("Tick1Scn2") == 1){
				t1.SetActive (true);
			}
			if (PlayerPrefs.GetInt ("Tick2Scn2") == 1)
				t2.SetActive (true);
			if (PlayerPrefs.GetInt ("Tick3Scn2") == 1)
				t3.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("CompleteScene3") == 1) {
			t4.SetActive (true);
			t5.SetActive (true);
			t6.SetActive (true);
		} else if (PlayerPrefs.GetInt ("CompleteScene3") == 0) {
			if(PlayerPrefs.GetInt ("Tick1Scn3") == 1){
				t4.SetActive (true);
			}
			if (PlayerPrefs.GetInt ("Tick2Scn3") == 1)
				t5.SetActive (true);
			if (PlayerPrefs.GetInt ("Tick3Scn3") == 1)
				t6.SetActive (true);
		}
			
		if (PlayerPrefs.GetInt ("CompleteScene4") == 1) {
			t7.SetActive (true);
			t8.SetActive (true);
			t9.SetActive (true);
		} else if (PlayerPrefs.GetInt ("CompleteScene4") == 0) {
			if(PlayerPrefs.GetInt ("Tick1Scn4") == 1){
				t7.SetActive (true);
			}
			if (PlayerPrefs.GetInt ("Tick2Scn4") == 1)
				t8.SetActive (true);
			if (PlayerPrefs.GetInt ("Tick3Scn4") == 1)
				t9.SetActive (true);
		}

		if (PlayerPrefs.GetInt ("CompleteScene5") == 1) {
			t10.SetActive (true);
			t11.SetActive (true);
			t12.SetActive (true);
		} else if (PlayerPrefs.GetInt ("CompleteScene5") == 0) {
			if(PlayerPrefs.GetInt ("Tick1Scn5") == 1){
				t10.SetActive (true);
			}
			if (PlayerPrefs.GetInt ("Tick2Scn5") == 1)
				t11.SetActive (true);
			if (PlayerPrefs.GetInt ("Tick3Scn5") == 1)
				t12.SetActive (true);
		}

		if (PlayerPrefs.GetInt ("CompleteScene6") == 1) {
			t13.SetActive (true);
			t14.SetActive (true);
			t15.SetActive (true);
		} else if (PlayerPrefs.GetInt ("CompleteScene6") == 0) {
			if(PlayerPrefs.GetInt ("Tick1Scn5") == 1){
				t13.SetActive (true);
			}
			if (PlayerPrefs.GetInt ("Tick2Scn5") == 1)
				t14.SetActive (true);
			if (PlayerPrefs.GetInt ("Tick3Scn5") == 1)
				t15.SetActive (true);
		}

		//txt.GetComponent<Text> ().text = PlayerPrefs.GetInt ("Score").ToString ();
			
	}
	
	// Update is called once per frame
	void Update () {
		if (t1.activeSelf && t2.activeSelf && t3.activeSelf && t4.activeSelf && t5.activeSelf && 
			t6.activeSelf && t7.activeSelf && t8.activeSelf && t9.activeSelf && t10.activeSelf && 
			t11.activeSelf && t13.activeSelf && t14.activeSelf && t15.activeSelf&&!ok) {

			Invoke ("Parabens",1);
			ok = true;
		}
	}

	void Parabens(){
        GetComponent<AudioSource>().Play();
        msg.SetActive(true);

	}
}
