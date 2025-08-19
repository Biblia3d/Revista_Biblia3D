using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject startScreeen, warning, swipeIndicator;
    // Use this for initialization
    void Start()
    {
        if (!PlayerPrefs.HasKey("Language"))
        {
            SetLanguage();
        }

        PlayerPrefs.DeleteKey("AddCard");
        //PlayerPrefs.DeleteKey("Perguntas");


    }

    private void OnEnable()
    {

        if (!PlayerPrefs.HasKey("Language") || PlayerPrefs.GetString("Language") == null || PlayerPrefs.GetString("Language") == "")
        {
            SetLanguage();
        }

        if (PlayerPrefs.GetInt("Warning") == 0)
        {
            warning.SetActive(true);
            Invoke("StartScreen", 5);
            PlayerPrefs.SetInt("Warning", 1);
        }
        else
        {
            startScreeen.GetComponent<Animator>().enabled = true;
        }
    }

    public void StartAnimationSwipeIndicator()
    {
        if (swipeIndicator != null)
        {
            swipeIndicator.GetComponent<Animator>().SetBool("Start", true);
            Invoke("StopAnimationSwipeIndicator", 4);
        }
    }

    public void StopAnimationSwipeIndicator()
    {
        if (swipeIndicator != null)
        {
            swipeIndicator.GetComponent<Animator>().SetBool("Start", false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartApp()
    {
        Application.LoadLevel("MainScene");
    }

    public void StartScreen()
    {
        startScreeen.GetComponent<Animator>().enabled = true;
        warning.SetActive(false);
    }

    void SetLanguage()
    {
        //*************Código comentado para evitar a troca de idioma do jogo
        /*
        if (Application.systemLanguage == SystemLanguage.Portuguese)
        {
            PlayerPrefs.SetString("Language", SystemLanguage.Portuguese.ToString());
        }
        else
        {
            PlayerPrefs.SetString("Language", SystemLanguage.English.ToString());
        }*/

        //*************Código comentado para evitar a troca de idioma do jogo

        PlayerPrefs.SetString("Language", SystemLanguage.Portuguese.ToString()); //eliminar essa linha quando voltar a mudar o idioma do jogo

    }
}
