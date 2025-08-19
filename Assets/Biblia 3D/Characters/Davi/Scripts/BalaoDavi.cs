using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameToolkit.Localization;

public class BalaoDavi : MonoBehaviour {

	public GameObject msg;
	public GameObject armadura;
	public GameObject seta, setaRei;
	public GameObject rei, davi;
    public LocalizedTextBehaviour localizedTextBehaviour;

    public LocalizedText msg1LocalizedText, msg2LocalizedText, msg3LocalizedText, msg4LocalizedText;

    private void OnEnable()
    {
		if (!setaRei.activeSelf)
		{
			Show();
			davi.GetComponent<BoxCollider>().enabled = false;
		}
		}

		// Update is called once per frame
		void Update () {
		
	}

    void Show()
    {
		if (PlayerPrefs.GetInt("Fala") == 0)
		{
			PlayerPrefs.SetInt("Fala", 1);
		}
        if(PlayerPrefs.GetInt("Fala")>4)
            PlayerPrefs.SetInt("Fala", 1);

        switch (PlayerPrefs.GetInt("Fala"))
        {
            case 1:
                if (localizedTextBehaviour != null) localizedTextBehaviour.LocalizedAsset = msg1LocalizedText;
                /*if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    GetComponent<TextMesh>().text = "Não consigo\n me mexer!";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    GetComponent<TextMesh>().text = "I can't move!";
                }*/
				PlayerPrefs.SetInt("Fala", PlayerPrefs.GetInt("Fala") + 1);
				rei.GetComponent<Interact_Obj>().enabled = false;
				davi.GetComponent<BoxCollider>().enabled = false;

				Invoke("SetaActive", 4);
				Invoke("EnableScripts",4);
				seta.SetActive(false);

				break;
            case 2:
                if (localizedTextBehaviour != null) localizedTextBehaviour.LocalizedAsset = msg2LocalizedText;
                /*if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    GetComponent<TextMesh>().text = "É grande\n e pesada pra\n mim!";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    GetComponent<TextMesh>().text = "It's Big\n and\n heavy for\n me";
                }*/
				PlayerPrefs.SetInt("Fala", PlayerPrefs.GetInt("Fala") + 1);
				rei.GetComponent<Interact_Obj>().enabled = false;
				davi.GetComponent<BoxCollider>().enabled = false;

				Invoke("SetaActive", 4);
				Invoke("EnableScripts", 4);
				seta.SetActive(false);

				break;
            case 3:
                if (localizedTextBehaviour != null) localizedTextBehaviour.LocalizedAsset = msg3LocalizedText;
                /*if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    GetComponent<TextMesh>().text = "Não vou\n lutar assim";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    GetComponent<TextMesh>().text = "I will\n not fight\n like this";
                }*/
				PlayerPrefs.SetInt("Fala", PlayerPrefs.GetInt("Fala") + 1);
				rei.GetComponent<Interact_Obj>().enabled = false;
				davi.GetComponent<BoxCollider>().enabled = false;

				Invoke("SetaActive", 4);
				Invoke("EnableScripts", 4);
				seta.SetActive(false);

				break;
            case 4:
                if (localizedTextBehaviour != null) localizedTextBehaviour.LocalizedAsset = msg4LocalizedText;
                /*if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    GetComponent<TextMesh>().text = "Me ajude\n a tirar";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    GetComponent<TextMesh>().text = "help me\n out";
                }*/
				PlayerPrefs.SetInt("Fala", PlayerPrefs.GetInt("Fala") + 1);
				rei.GetComponent<BoxCollider>().enabled = false;
				davi.GetComponent<BoxCollider>().enabled = false;

				seta.SetActive(false);

				msg.SetActive(true);
				armadura.SetActive(true);
                break;

        }
    }

    void ResetFala()
    {
        PlayerPrefs.SetInt("Fala", 1);
    }

	void SetaActive()
	{
		setaRei.SetActive(true);
		

	}

	void EnableScripts()
	{
		rei.GetComponent<BoxCollider>().enabled = true;
	}
}
