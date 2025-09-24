using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Funda : MonoBehaviour
{
	public GameObject davi;

	private GameObject pag;
	// Use this for initialization
	void Start () {
		pag = GameObject.FindWithTag ("Story_Manager");
	}


    public void Shoot(){
		if (pag.GetComponent<Story_Manager> ().atualTrack == "04"||pag.GetComponent<Story_Manager> ().atualTrack == "10" || pag.GetComponent<Story_Manager>().atualTrack == "Caneca" || pag.GetComponent<Story_Manager> ().atualTrack == "VersoCarta") {
            //if (PlayerPrefs.GetInt ("Stone") > 0) {
            if (davi.GetComponent<Davi_InGame>().isActiveAndEnabled)
                print("entrou no if");
            davi.GetComponent<Davi_InGame> ().Atira();
            //PlayerPrefs.SetInt ("Stone", PlayerPrefs.GetInt ("Stone") - 1);
            //}
            
		}
	}

    void DisableAnimator()
    {
        GetComponent<Animator>().enabled = false;
    }
    public void EnableAnimator()
    {

        GetComponent<Animator>().enabled = true;
    }

    public void StopAnimation()
    {
        GetComponent<Animator>().SetTrigger("Change");
        Invoke("DisableAnimator", 1);
    }
}
