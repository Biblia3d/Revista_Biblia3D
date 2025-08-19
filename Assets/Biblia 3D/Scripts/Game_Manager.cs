using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Vuforia;

using UnityEngine.UI;
using GameToolkit.Localization;

[Obsolete("Esta classe deve ser removida em nome da especializacao de recursos de cada scene, assim ao completar essa classe deve ser removida")]
public class Game_Manager : MonoBehaviour
{

    public GameObject load, checklist, txt;
    public Sprite[] screen;
    private bool continueCheck, ok =false;
    public GameObject arrow, arrow1;
    public GameObject tela, telaDelete;
    public GameObject musicSrc;
    public GameObject telaNome, pleaseName, telaNomeFim;
    public Text nomePlayer;
	public GameObject funda;
	public GameObject setaBarraca1;
	public TouchBarraca scriptBarraca;

	[SerializeField]
    public InputField nome = null;

    // Use this for initialization
    void Start()
    {
       
        //		PlayerPrefs.DeleteKey ("Tip:02");
        //		PlayerPrefs.DeleteKey ("Tip:03");
        //		PlayerPrefs.DeleteKey ("Tip:06");
        //		PlayerPrefs.DeleteKey ("Tip:08");
        //		PlayerPrefs.DeleteKey ("Tip:10");
        //		PlayerPrefs.DeleteKey ("Tip:11");
        //		PlayerPrefs.DeleteKey ("Ouviu");
        //		PlayerPrefs.DeleteKey ("Score");
        //		PlayerPrefs.DeleteKey ("TocouBarraca");

        if (!PlayerPrefs.HasKey("Stone"))
        {
            PlayerPrefs.SetString("Stone", "∞");
        }

        //		if (PlayerPrefs.GetInt ("Update")==1) {
        //			PlayerPrefs.DeleteAll ();
        //			PlayerPrefs.SetInt ("Update", 2);
        //		} else
        //			PlayerPrefs.SetInt ("Update", 2);

        if(!PlayerPrefs.HasKey("NomePlayer") || PlayerPrefs.GetString("NomePlayer")== "")
        {
            Invoke("NomePlayer", 5);
        }
        if(nomePlayer!=null)
        nomePlayer.text = PlayerPrefs.GetString("NomePlayer");

		if(SceneManager.GetActiveScene().name == "CardDG")
		{
			PlayerPrefs.DeleteKey("AddCard");
		}

		PlayerPrefs.DeleteKey("Fala");
		PlayerPrefs.DeleteKey("FalaRei");

	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.DeleteAll();
        }
        if (arrow != null && arrow1 != null)
        {
            if (PlayerPrefs.GetInt("ArrowInicial") < 1)
            {
                arrow.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("ArrowInicial") > 0 && PlayerPrefs.GetInt("ArrowInicial") < 2)
            {
                arrow1.SetActive(true);
            }
        }
        if (SceneManager.sceneCount == 2)
        {
			if (musicSrc != null)
			{
				if (!ok)
					musicSrc = GameObject.FindGameObjectWithTag("Music");
				ok = true;
				if (musicSrc != null)
				{
					//musicSrc.GetComponent<AudioSource>().mute = true;
					Debug.Log(SceneManager.GetActiveScene().name);
				}
				Debug.Log(SceneManager.GetActiveScene().name);
			}
        }
        else
        {
			if (musicSrc != null)
			{
				if (PlayerPrefs.GetInt("Mute") == 0)
					musicSrc.GetComponent<AudioSource>().mute = false;
			}
        }

		if (SceneManager.GetSceneByName("Scene").isLoaded)
		{
			if (SceneManager.GetSceneByName("Jogos").isLoaded)
			{
				if (funda != null)
				{
					if (funda.GetComponent<AudioSource>().isPlaying)
						funda.GetComponent<AudioSource>().Stop();
				}
			}
			else
			{
				if (funda != null)
				{
					if(!funda.GetComponent<AudioSource>().isPlaying)
					funda.GetComponent<AudioSource>().Play();
				}
			}
		}

    }

    public void ChangeSceneWithOutLoad(string scene)
    {
        Destroy(GameObject.FindWithTag("ActiveARCam"));
        SceneManager.LoadScene(scene);
        //Load_Manager.instance.ChangeSceneWithOutLoad(scene);
    }

    public void ChangeScene(string scene)
    {
        if (checklist != null)
        {
            checklist.SetActive(false);
        }
        if(Sound_Manager.Instance!=null)
            Sound_Manager.Instance.GetComponent<AudioSource>().Stop();

        //load.SetActive(true);
        switch (scene)
        {
            case "Card Jesus":
                load.GetComponent<UnityEngine.UI.Image>().sprite = screen[0];
                txt.GetComponent<Text>().text = "Ponha um Catão de cada vez.";
                break;
            case "CardDG":
                load.GetComponent<UnityEngine.UI.Image>().sprite = screen[1];
                txt.GetComponent<Text>().text = "Interaja com os personagens.";
                break;
            case "CardJogo":
                load.GetComponent<UnityEngine.UI.Image>().sprite = screen[2];
                txt.GetComponent<Text>().text = "Ajude Davi a enfrentar o Golias.";
                break;
            case "Capa":
                load.GetComponent<UnityEngine.UI.Image>().sprite = screen[3];
                txt.GetComponent<Text>().text = "O ambiente tem que ter boa luz. Você também pode clicar no celular para a imagem sair mais rápido.";
                break;
            case "Verso":
                load.GetComponent<UnityEngine.UI.Image>().sprite = screen[3];
                txt.GetComponent<Text>().text = "O ambiente tem que ter boa luz. Você também pode clicar no celular para a imagem sair mais rápido.";
                break;
            case "Scene 2":
                load.GetComponent<UnityEngine.UI.Image>().sprite = screen[4];
                txt.GetComponent<Text>().text = "Davi tocava harpa enquanto cuidava das ovelhas do seu pai com amor.";
                break;
            case "Scene 3":
                load.GetComponent<UnityEngine.UI.Image>().sprite = screen[5];
                txt.GetComponent<Text>().text = "Vença o Leão e o Urso.";
                break;
            case "Scene 4":
                load.GetComponent<UnityEngine.UI.Image>().sprite = screen[6];
                txt.GetComponent<Text>().text = "Davi foi levar almoço para seus irmãos. Clique nas 3 barracas azuis.";
                break;
            case "Scene 5":
                load.GetComponent<UnityEngine.UI.Image>().sprite = screen[7];
                txt.GetComponent<Text>().text = "O desafio foi lançado. Clique no Golias e no Davi.";
                break;
            case "Scene 6":
                load.GetComponent<UnityEngine.UI.Image>().sprite = screen[8];
                txt.GetComponent<Text>().text = "Tá na hora do pau! Derrote o Golias.";
                break;
            case "Scene 7":
                load.GetComponent<UnityEngine.UI.Image>().sprite = screen[9];
                txt.GetComponent<Text>().text = "Vitória no poder do Espírito Santo. Toque no Davi para finalizar!";
                break;
        }

        Destroy(GameObject.FindWithTag("ActiveARCam"));

		StartCoroutine(LoadManager(scene));
    }

	IEnumerator LoadManager(string scene)
	{
		if (scene == "CardDG" || scene == "Card Jesus" || scene == "Scene 2" || scene == "Scene 3" || scene == "Scene 4" || scene == "Scene 5"
			|| scene == "Scene 6" || scene == "Scene 7" || scene == "Scene 8" || scene == "Scene 9"
			|| scene == "Scene 10" || scene == "Scene 11" || scene == "Scene 12" || scene == "Scene 13")
		{
			yield return new WaitForSecondsRealtime(0);
            SceneManager.LoadSceneAsync(scene);
            //Load_Manager.instance.ChangeSceneWithLoad(scene);
		}
		else
		{
			yield return new WaitForSecondsRealtime(2);
            SceneManager.LoadSceneAsync(scene);
            //Load_Manager.instance.ChangeSceneWithLoad(scene);
		}
	}

    #region AsyncaSceneChangeWithButton

    //SceneChangeAsync
    public void ChangeSceneAsyncWithButton(string scene)
    {
        if (Sound_Manager.Instance != null)
            Sound_Manager.Instance.GetComponent<AudioSource>().Stop();
        load.SetActive(true);
        Destroy(GameObject.FindWithTag("ActiveARCam"));
        StartCoroutine(AsyncChange(scene));
    }

    public void ContinueSet(bool check)
    {
        continueCheck = check;
    }

    IEnumerator AsyncChange(string scene)
    {
        //yield return new WaitForSeconds (1);
        AsyncOperation nextScene = Application.LoadLevelAsync(scene);
        nextScene.allowSceneActivation = false;
        while (nextScene.progress < 0.9f)
        {
            yield return null;
        }
        load.GetComponent<Animator>().SetTrigger("Change");
        while (!continueCheck)
        {
            yield return null;
        }

        nextScene.allowSceneActivation = true;
    }

    #endregion

    #region AsyncaSceneChangeWithOutButton

    public void ChangeSceneAsyncWithOutButton(string scene)
    {
        load.SetActive(true);
        Destroy(GameObject.FindWithTag("ActiveARCam"));
        StartCoroutine(AsyncChangeWithOutButton(scene));
    }

    IEnumerator AsyncChangeWithOutButton(string scene)
    {
        //yield return new WaitForSeconds (1);
        AsyncOperation nextScene = Application.LoadLevelAsync(scene);

        while (nextScene.progress < 0.9f)
        {
            yield return null;
        }

        yield return null;
    }

    #endregion

    public void launchApp(string package)
    {
        if (IsAppInstalled(package))
        {
            AndroidJavaClass activityClass;
            AndroidJavaObject activity, packageManager;
            AndroidJavaObject launch;
            activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            activity = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
            packageManager = activity.Call<AndroidJavaObject>("getPackageManager");
            launch = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", package);
            activity.Call("startActivity", launch);
        }
        else
        {
            Application.OpenURL("https://play.google.com/store/apps/details?id=" + package);
        }
    }

    public bool IsAppInstalled(string bundleID)
    {
        AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");
        //Debug.Log(" ********LaunchOtherApp ");
        AndroidJavaObject launchIntent = null;
        //if the app is installed, no errors. Else, doesn't get past next line
        try
        {
            launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", bundleID);
            //        
            //        ca.Call("startActivity",launchIntent);
        }
        catch
        {
            Debug.Log("Horrible things happened!");
        }
        if (launchIntent == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void CallURL(string url)
    {
        Application.OpenURL("http://" + url);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void DeleteAllPrefsConfirm()
    {
        if (telaDelete != null)
        {
            telaDelete.SetActive(true);
        }
    }
    public void deleteAllprefs()
    {
        string nomePlayer = PlayerPrefs.GetString("NomePlayer");
        
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("NomePlayer", nomePlayer);
        PlayerPrefs.SetInt("Warning", 1);

        if (!PlayerPrefs.GetString("Language").Equals("Portuguese"))
        {
            
            Localization.Instance.CurrentLanguage = LocalizationSettings.Instance.AvailableLanguages[0];
        }else
            Localization.Instance.CurrentLanguage = LocalizationSettings.Instance.AvailableLanguages[1];

        SceneManager.LoadSceneAsync("Scene");
    }

    public void CountArrow()
    {
        PlayerPrefs.SetInt("ArrowInicial", PlayerPrefs.GetInt("ArrowInicial") + 1);
    }

    public void AddScene(string scene)
    {
		StartCoroutine(LoadScene(scene));
    }

	IEnumerator LoadScene(string scene)
	{
		yield return new WaitForSecondsRealtime(2);
		SceneManager.LoadScene(scene, LoadSceneMode.Additive);
	}

	public void AddSceneMenu(string scene)
	{
		if(!SceneManager.GetSceneByBuildIndex(23).isLoaded)
			SceneManager.LoadScene(scene, LoadSceneMode.Additive);
		else
		{
			SceneManager.UnloadSceneAsync(scene);
		}
	}

	public void UnloadScene(string scene)
    {
        GameObject arcam = GameObject.FindWithTag("ActiveARCam");
		GameObject funda = GameObject.FindWithTag("Funda");
		if (arcam != null)
        {

            arcam.GetComponent<ActiveGameobject>().Ativar();

        }

		if(funda != null)
		{
			funda.GetComponent<AudioSource>().mute = false;
		}
		if (SceneManager.GetActiveScene().name != "Scene")
		{
			ChangeSceneWithOutLoad("Scene");
		}
		else
		{
			SceneManager.UnloadSceneAsync(scene);
		}
        if (tela!=null){
            Invoke("LoadTela", 3);
        }

        
    }

    void LoadTela()
    {
        tela.SetActive(true);
    }

    public void ManagerMusic()
    {
        
        
    }

    void NomePlayer()
    {
        if (telaNome != null) telaNome.SetActive(true);
    }

    public void Preencher()
    {
        if(nome.text == "")
        {
            pleaseName.SetActive(true);
        }
        else
        {
            
            PlayerPrefs.SetString("NomePlayer", nome.text);
            nomePlayer.text = PlayerPrefs.GetString("NomePlayer");
            telaNomeFim.SetActive(true);
        }
    }

	public void CallSeta()
	{
		Invoke("SetaBarraca", 0);
	}
	public void SetaBarraca()
	{
		setaBarraca1.SetActive(true);
		scriptBarraca.enabled=true;
	}
    
}
