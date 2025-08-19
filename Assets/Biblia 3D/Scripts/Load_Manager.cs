using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Obsolete("Esta classe deve ser removida depois de retirar todas as referencias no Unity")]
public class Load_Manager : MonoBehaviour {

    public static Load_Manager instance;
	public GameObject[] load;
    public GameObject button;
    public Text pagina, pagina1;
    private GameObject arCam;
    //public GameObject[] flag;
    public string sceneName;

	public bool ButtonToChange = true;


    private void Start()
    {
        arCam = GameObject.FindWithTag("ARCam");
        instance = this;
    }

    private void Update()
    {

        if (pagina1 == null)
            return;

        switch (sceneName)
        {
            case "Scene 2":

                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina1.text = "2";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina1.text = "2";
                }
                break;
            case "Scene 3":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina1.text = "4";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina1.text = "4";
                }
                break;
            case "Scene 4":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina1.text = "6";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina1.text = "6";
                }
                break;
            case "Scene 5":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina1.text = "8";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina1.text = "8";
                }
                break;
            case "Scene 6":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina1.text = "10";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina1.text = "10";
                }
                break;
            case "Scene 7":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina1.text = "12";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina1.text = "12";
                }
                break;
            case "Scene 9":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina1.text = "14";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina1.text = "14";
                }
                break;
            case "Scene 10":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina1.text = "16";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina1.text = "16";
                }
                break;
            case "Scene 11":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina1.text = "18";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina1.text = "18";
                }
                break;
            case "Scene 12":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina1.text = "20";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina1.text = "20";
                }
                break;
            case "Scene 13":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina1.text = "22";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina1.text = "22";
                }
                break;
            case "Capa":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina1.text = "Capa";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina1.text = "Cover";
                }
                break;
			case "Verso":
				if (PlayerPrefs.GetString("Language") == "Portuguese")
				{
					pagina1.text = "Verso";
				}
				else if (PlayerPrefs.GetString("Language") == "English")
				{
					pagina1.text = "Verse";
				}
				break;

			case "Scene 0":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina1.fontSize = 40;
                    pagina1.text = "Revista";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina1.fontSize = 40;
                    pagina1.text = "Magazine";
                }
                break;
			case "Scene 0 Caneca":
				if (PlayerPrefs.GetString("Language") == "Portuguese")
				{
					pagina1.fontSize = 40;
					pagina1.text = "Caneca";
				}
				else if (PlayerPrefs.GetString("Language") == "English")
				{
					pagina1.fontSize = 40;
					pagina1.text = "Mug";
				}
				break;
			default:
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina1.fontSize = 40;
                    pagina1.text = "Cartões";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina1.fontSize = 40;
                    pagina1.text = "Cards";
                }
                break;
        }
    }
    //Troca de Cena com tela de Loading
    public void ChangeSceneWithLoad(string scene){
        if(RefreshARCam.instance!=null)
        RefreshARCam.instance.StopAllCoroutines();

        if (arCam != null)
            arCam.SetActive(false);
        sceneName = scene;
		Invoke ("ActiveLoad", 1);
			StartCoroutine (AsyncChange (scene));
	}

	//Troca de Cena sem Loading
	public void ChangeSceneWithOutLoad(string scene){
        sceneName = scene;

        SceneManager.LoadScene (scene);
	}

	IEnumerator AsyncChange (string scene)
    {
        sceneName = scene;

        //yield return new WaitForSeconds (1);
        AsyncOperation nextScene = GetNextScene(scene);
        nextScene.allowSceneActivation = false;
        while (nextScene.progress < 0.9f)
        {
            yield return null;
        }
        button.SetActive(true);
        //for(int i=0;i<flag.Length;i++)
        //flag[i].SetActive(false);


        while (ButtonToChange)
        {
            yield return null;
        }

        nextScene.allowSceneActivation = true;
    }

    private static AsyncOperation GetNextScene(string scene)
    {
        return SceneManager.LoadSceneAsync(scene);
    }

    public void PressToChange(){
        switch (sceneName)
        {
            case "Scene 2":

                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina.text = "Página 2";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina.text = "Page 2";
                }
                break;
            case "Scene 3":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina.text = "Página 4";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina.text = "Page 4";
                }
                break;
            case "Scene 4":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina.text = "Página 6";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina.text = "Page 6";
                }
                break;
            case "Scene 5":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina.text = "Página 8";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina.text = "Page 8";
                }
                break;
            case "Scene 6":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina.text = "Página 10";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina.text = "Page 10";
                }
                break;
            case "Scene 7":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina.text = "Página 12";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina.text = "Page 12";
                }
                break;
            case "Scene 9":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina.text = "Página 14";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina.text = "Page 14";
                }
                break;
            case "Scene 10":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina.text = "Página 16";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina.text = "Page 16";
                }
                break;
            case "Scene 11":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina.text = "Página 18";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina.text = "Page 18";
                }
                break;
            case "Scene 12":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina.text = "Página 20";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina.text = "Page 20";
                }
                break;
            case "Scene 13":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina.text = "Página 22";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina.text = "Page 22";
                }
                break;
            case "Capa":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina.text = "Capa";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina.text = "Cover";
                }
                break;

            case "Scene 0":
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina.text = "Revista";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina.text = "Magazine";
                }
                break;
            default:
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    pagina.text = "Cartões";
                }
                else if (PlayerPrefs.GetString("Language") == "English")
                {
                    pagina.text = "Cards";
                }
                break;
        }

		ButtonToChange = false;

	}

    void ActiveLoad()
    {

        load[0].SetActive(true);
    }

}
