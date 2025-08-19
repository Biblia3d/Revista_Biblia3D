using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameToolkit.Localization;

public class BalaoRei : MonoBehaviour {
	public GameObject seta, setaDavi, davi, rei;
    public LocalizedTextBehaviour localizedTextBehaviour;

    public LocalizedText msg1LocalizedText, msg2LocalizedText, msg3LocalizedText, msg4LocalizedText;

    void Awake()
    {
        PlayerPrefs.SetInt("FalaReiNovo", 1);
    }

    private void OnEnable()
    {
		if (!setaDavi.activeSelf)
		{
			Show();
			rei.GetComponent<BoxCollider>().enabled = false;

		}
	}

    void Show()
    {
        /*if (PlayerPrefs.GetInt("FalaReiNovo") == 0)
        {
            PlayerPrefs.SetInt("FalaReiNovo", 1);
        }
        if (PlayerPrefs.GetInt("FalaReiNovo") > 4)
            PlayerPrefs.SetInt("FalaReiNovo", 1);*/

        /*if (PlayerPrefs.GetInt("FalaReiNovo") > 4)
		{
			PlayerPrefs.SetInt("FalaReiNovo", 0);
			print("ZEROU!");
		}*/
        switch (PlayerPrefs.GetInt("FalaReiNovo"))
        {
            case 1:
                if (localizedTextBehaviour != null) localizedTextBehaviour.LocalizedAsset = msg1LocalizedText;
                /*if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    GetComponent<TextMesh>().text = "Use minha\n armadura!";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    GetComponent<TextMesh>().text = "Use my\n armor!";
                }*/
				PlayerPrefs.SetInt("FalaReiNovo", PlayerPrefs.GetInt("FalaReiNovo") + 1);
				davi.GetComponent<BoxCollider>().enabled = false;
				rei.GetComponent<BoxCollider>().enabled = false;
				Invoke("SetaActive", 4);
				Invoke("EnableScripts", 5);
				seta.SetActive(false);

				break;
			case 2:
                if (localizedTextBehaviour != null) localizedTextBehaviour.LocalizedAsset = msg2LocalizedText;
                /*if (PlayerPrefs.GetString("Language") == "Portuguese")
				{
					GetComponent<TextMesh>().text = "Você precisa\n de Proteção";
				}
				else if (PlayerPrefs.GetString("Language") == "English")
				{
					GetComponent<TextMesh>().text = "You need\n protection";
				}*/
				PlayerPrefs.SetInt("FalaReiNovo", PlayerPrefs.GetInt("FalaReiNovo") + 1);
				davi.GetComponent<BoxCollider>().enabled = false;
				rei.GetComponent<BoxCollider>().enabled = false;

				Invoke("SetaActive", 4);
				Invoke("EnableScripts", 4);
				seta.SetActive(false);

				break;
			case 3:
                if (localizedTextBehaviour != null) localizedTextBehaviour.LocalizedAsset = msg3LocalizedText;
                /*if (PlayerPrefs.GetString("Language") == "Portuguese")
				{
					GetComponent<TextMesh>().text = "Você\nprecisa dela";
				}
				else if (PlayerPrefs.GetString("Language") == "English")
				{
					GetComponent<TextMesh>().text = "so it goes\n without armor";
				}*/

				PlayerPrefs.SetInt("FalaReiNovo", PlayerPrefs.GetInt("FalaReiNovo") + 1);
				davi.GetComponent<BoxCollider>().enabled = false;
				rei.GetComponent<BoxCollider>().enabled = false;

				Invoke("SetaActive", 4);
				Invoke("EnableScripts", 4);
				seta.SetActive(false);

				break;
			case 4:
                if (localizedTextBehaviour != null) localizedTextBehaviour.LocalizedAsset = msg4LocalizedText;
                /*if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    GetComponent<TextMesh>().text = "Então vá\n sem armadura";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    GetComponent<TextMesh>().text = "so it goes\n without armor";
                }*/

				PlayerPrefs.SetInt("FalaReiNovo", PlayerPrefs.GetInt("FalaReiNovo") + 1);
				davi.GetComponent<BoxCollider>().enabled = false;
				rei.GetComponent<BoxCollider>().enabled = false;

				Invoke("SetaActive", 4);
				Invoke("EnableScripts", 4);
				seta.SetActive(false);

				break;
        }
    }

	void SetaActive()
	{
		setaDavi.SetActive(true);
		

	}

	void EnableScripts()
	{
		davi.GetComponent<BoxCollider>().enabled = true;
	}
}
