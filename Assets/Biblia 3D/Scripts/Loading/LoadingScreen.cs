using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Obsolete("Esta classe deve ser removida depois de retirar todas as referencias no Unity")]
public class LoadingScreen : MonoBehaviour {

    public GameObject load, txt;
    public Sprite[] screen;
    public AudioClip[] intro, introUs;
    public string scene;
    public GameObject davi, mao;
    private AudioSource audioSrc;
    public bool ok, ok1;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Update () {
        scene = Load_Manager.instance.sceneName;
        if (PlayerPrefs.GetString("Language") == "Portuguese")
        {
            txt.GetComponent<Text>().text = "Aponte a câmera para a Imagem.";
            if (!ok1)
                audioSrc.PlayOneShot(intro[15]);
            ok1 = true;
        }
        else
        {
            txt.GetComponent<Text>().text = "Point the camera at the Image.";
            if (!ok1)
                audioSrc.PlayOneShot(introUs[15]);
            ok1 = true;
        }
            
        switch (scene)
        {
            case "Card Jesus":
                load.GetComponent<Image>().sprite = screen[0];
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    txt.GetComponent<Text>().text = "Escolha sua animação favorita.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(intro[0]);
                    }
                    ok = true;
                }
                else
                {
                    txt.GetComponent<Text>().text = "Choose your Favorite animation.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(introUs[0]);
                    }
                    ok = true;
                }
				if (davi != null)
					davi.SetActive(false);
				if (mao != null)
					mao.SetActive(false);
                break;
            case "CardDG":
                load.GetComponent<Image>().sprite = screen[1];
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    txt.GetComponent<Text>().text = "Interaja com os personagens.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(intro[1]);
                    }
                    ok = true;
                }
                else
                {
                    txt.GetComponent<Text>().text = "Interact with the characters.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(introUs[1]);
                    }
                    ok = true;
                }
				if (davi != null)
					davi.SetActive(false);
				if (mao != null)
					mao.SetActive(false);
                break;
            
            case "Capa":
                load.GetComponent<Image>().sprite = screen[3];
                if (PlayerPrefs.GetString("Language") == "Portuguese")
                {
                    txt.GetComponent<Text>().text = "O ambiente tem que ter boa luz. Clicando na tela a imagem sai mais rápido.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(intro[3]);
                    }
                    ok = true;
                }
                else
                {
                    txt.GetComponent<Text>().text = "The environment has to have good light. Clicking on the screen, the image goes out faster.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(introUs[3]);
                    }
                    ok = true;
                }
				if (davi != null)
					davi.SetActive(false);
				if (mao != null)
					mao.SetActive(false);
                break;
            
            case "Scene 2":
                load.GetComponent<Image>().sprite = screen[4];
                if (PlayerPrefs.GetString("Language") == "Portuguese") { 
                    txt.GetComponent<Text>().text = "Davi aprendeu a tocar harpa quando trabalhava e era muito bom músico.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(intro[4]);
                    }
                    ok = true;
                }
                else
                {
                    txt.GetComponent<Text>().text = "David learned to play harp when he worked and was a very good musician.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(introUs[4]);
                    }
                    ok = true;
                }
				if (davi != null)
					davi.SetActive(false);
				if (mao != null)
					mao.SetActive(false);
                break;
            case "Scene 3":
                load.GetComponent<Image>().sprite = screen[5];
                if (PlayerPrefs.GetString("Language") == "Portuguese") { 
                    txt.GetComponent<Text>().text = "Vença o Leão e o Urso.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        //audioSrc.PlayOneShot(intro[5]);
                    }
                    ok = true;
                }
                else
                {
                    txt.GetComponent<Text>().text = "Beat the Lion and the Bear.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        //audioSrc.PlayOneShot(introUs[5]);
                    }
                    ok = true;
                }
				if (davi != null)
					davi.SetActive(false);
				if (mao != null)
					mao.SetActive(false);
                break;
            case "Scene 4":
                load.GetComponent<Image>().sprite = screen[6];
                if (PlayerPrefs.GetString("Language") == "Portuguese") { 
                    txt.GetComponent<Text>().text = "A pedido do seu pai Davi foi levar o almoço aos irmãos.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        //audioSrc.PlayOneShot(intro[6]);
                    }
                    ok = true;
                }
                else
                {
                    txt.GetComponent<Text>().text = "At the request of his father David he went to take his brothers' lunch.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        //audioSrc.PlayOneShot(introUs[6]);
                    }
                    ok = true;
                }
				if (davi != null)
					davi.SetActive(false);
				if (mao != null)
					mao.SetActive(false);
                break;
            case "Scene 5":
                load.GetComponent<Image>().sprite = screen[7];
                if (PlayerPrefs.GetString("Language") == "Portuguese") { 
                    txt.GetComponent<Text>().text = "O desafio foi lançado. Clique no personagem.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(intro[7]);
                    }
                    ok = true;
                }
                else
                {
                    txt.GetComponent<Text>().text = "The challenge was launched. Click on the character.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(introUs[7]);
                    }
                    ok = true;
                }
				if (davi != null)
					davi.SetActive(false);
				if (mao != null)
					mao.SetActive(false);
                break;
            case "Scene 6":
                load.GetComponent<Image>().sprite = screen[8];
                if (PlayerPrefs.GetString("Language") == "Portuguese") { 
                    txt.GetComponent<Text>().text = "Tá na hora do Combate! Derrote o Golias.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(intro[8]);
                    }
                    ok = true;
                }
                else
                {
                    txt.GetComponent<Text>().text = "It's fighting time! Defeat the Goliath.";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(introUs[8]);
                    }
                    ok = true;
                }
				if(davi!=null)
                    davi.SetActive(false);
				if (mao != null)
					mao.SetActive(false);
                break;
            case "Scene 7":
                load.GetComponent<Image>().sprite = screen[9];
                if (PlayerPrefs.GetString("Language") == "Portuguese") { 
                    txt.GetComponent<Text>().text = "Vitória no poder do Espírito Santo!";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(intro[9]);
                    }
                    ok = true;
                }
                else
                {
                    txt.GetComponent<Text>().text = "Victory in the power of the Holy Spirit!";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(introUs[9]);
                    }
                    ok = true;
                }
				if (davi != null)
					davi.SetActive(false);
				if (mao != null)
					mao.SetActive(false);
                break;
            case "Scene 9":
                load.GetComponent<Image>().sprite = screen[10];
                if (PlayerPrefs.GetString("Language") == "Portuguese") { 
                    txt.GetComponent<Text>().text = "O rei Saul desafia Davi a matar 100 Filisteus";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(intro[10]);
                    }
                    ok = true;
                }
                else
                {
                    txt.GetComponent<Text>().text = "King Saul challenges David to kill 100 Philistines";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(introUs[10]);
                    }
                    ok = true;
                }
                if(davi!=null)
                    davi.SetActive(false);
                if(mao!=null)
                    mao.SetActive(false);
                break;
            case "Scene 10":
                load.GetComponent<Image>().sprite = screen[11];
                if (PlayerPrefs.GetString("Language") == "Portuguese") { 
                    txt.GetComponent<Text>().text = "Davi foi traído pelos habitantes de Queila";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(intro[11]);
                    }
                    ok = true;
                }
                else
                {
                    txt.GetComponent<Text>().text = "David was betrayed by inhabitants of Queilah";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(introUs[11]);
                    }
                    ok = true;
                }
				if (davi != null)
					davi.SetActive(false);
				if (mao != null)
					mao.SetActive(false);
                break;
            case "Scene 11":
                load.GetComponent<Image>().sprite = screen[12];
                if (PlayerPrefs.GetString("Language") == "Portuguese") { 
                    txt.GetComponent<Text>().text = "Quando Saul morreu houve uma guerra para assumir o trono";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(intro[12]);
                    }
                    ok = true;
                }
                else
                {
                    txt.GetComponent<Text>().text = "When Saul died there was a war to take the throne";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(introUs[12]);
                    }
                    ok = true;
                }
				if (davi != null)
					davi.SetActive(false);
				if (mao != null)
					mao.SetActive(false);
                break;
            case "Scene 12":
                load.GetComponent<Image>().sprite = screen[13];
                if (PlayerPrefs.GetString("Language") == "Portuguese") { 
                    txt.GetComponent<Text>().text = "Davi organizou o exército para conquistar a fortaleza de Sião";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        //audioSrc.PlayOneShot(intro[13]);
                    }
                    ok = true;
                }
                else
                {
                    txt.GetComponent<Text>().text = "David organized the army to conquer the fortress of Zion";
                    if (!ok)
                    {
                        audioSrc.Stop();
                       // audioSrc.PlayOneShot(introUs[13]);
                    }
                    ok = true;
                }
				if (davi != null)
					davi.SetActive(false);
				if (mao != null)
					mao.SetActive(false);
                break;
            case "Scene 13":
                load.GetComponent<Image>().sprite = screen[14];
                if (PlayerPrefs.GetString("Language") == "Portuguese") { 
                    txt.GetComponent<Text>().text = "Davi invadiu a cidade pelo túnel subterrâneo e conquistou Jerusalém";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(intro[14]);
                    }
                    ok = true;
                }
                else
                {
                    txt.GetComponent<Text>().text = "David invaded the city through the underground tunnel and conquered Jerusalem";
                    if (!ok)
                    {
                        audioSrc.Stop();
                        audioSrc.PlayOneShot(introUs[14]);
                    }
                    ok = true;
                }
				if (davi != null)
					davi.SetActive(false);
				if(mao!=null)
                    mao.SetActive(false);
                break;
        }
    }
}

