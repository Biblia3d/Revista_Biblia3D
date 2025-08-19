using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    public GameObject focoImg;
    public GameObject focoTxt1;
    public GameObject focoTxt2;
    public GameObject tuto1;
    public GameObject tuto2;
    public GameObject tuto3;
    public GameObject button, buttonTuto;
    public GameObject scriptAR;
    bool ok = false;

    // Use this for initialization
    void Start () {

        
        if (PlayerPrefs.GetInt("ExibiuTuto") <2)
        {
            PlayerPrefs.DeleteKey("Tutorial");
        }
    }
	
	// Update is called once per frame
	void Update () {


        if (SceneManager.GetActiveScene().name == "Scene 0"|| SceneManager.GetActiveScene().name == "Scene 0 Cards")
            if (PlayerPrefs.GetInt("Tutorial") > 1)
            {
                if (!ok) { 
                    PlayerPrefs.SetInt("ExibiuTuto", PlayerPrefs.GetInt("ExibiuTuto") + 1);
                    ok = true;
                }
                focoImg.GetComponent<Image>().enabled = true;
            focoTxt1.SetActive(true);
            focoTxt2.SetActive(true);
                scriptAR.GetComponent<RefreshARCam>().enabled = true;
        }
        else
        {
            focoImg.GetComponent<Image>().enabled = false;
            focoTxt1.SetActive(false);
            focoTxt2.SetActive(false);
                scriptAR.GetComponent<RefreshARCam>().enabled = false;

            }
        switch (PlayerPrefs.GetInt("Tutorial"))
        {
            case 0:
                tuto2.SetActive(true);
                break;
            case 1:
                tuto2.SetActive(false);
                tuto3.SetActive(true);
                if (button != null)
                    button.SetActive(false);
                buttonTuto.SetActive(true);
                break;
            case 2:
                tuto1.SetActive(false);
                tuto2.SetActive(false);
                tuto3.SetActive(true);
                if (button != null)
                    button.SetActive(false);
                buttonTuto.SetActive(false);
                break;

            default:
                tuto1.SetActive(false);
                tuto2.SetActive(false);
                tuto3.SetActive(false);
                if (button != null)
                    button.SetActive(false);
                buttonTuto.SetActive(false);

                break;
        }
		
	}

    public void Clicou()
    {
        PlayerPrefs.SetInt("Tutorial", PlayerPrefs.GetInt("Tutorial") + 1);
    }
}
