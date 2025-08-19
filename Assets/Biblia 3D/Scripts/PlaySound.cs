using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameToolkit.Localization;
using Biblia3D.Scene.Subtitle;

public class PlaySound : MonoBehaviour {

    public GameObject fim;
    public GameObject balao, balao1;
    public GameObject[] txt;
    public AudioSource audioSource;
    public SubtitleScriptableObject subtitleScriptableObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play(string nome)
    {
        Sound_Manager.Instance.PlayOneShot(nome);
    }

    public void FinalStory()
    {
        if (subtitleScriptableObject != null)
        {
            SubtitleSceneRequest subtitleSceneRequest = new SubtitleSceneRequest();
            subtitleSceneRequest.subtitleScriptableObject = subtitleScriptableObject;
            SubtitleSceneComponent.LoadScene(subtitleSceneRequest, (outcome) => { });
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void Fim()
    {
        fim.SetActive(true);
    }

    void TextoPar(int i)
    {
       
        txt[i].SetActive(true);
        balao.GetComponent<Animator>().SetTrigger("Change");

    }

    void TextoImpar(int i)
    {

        txt[i].SetActive(true);
        balao1.GetComponent<Animator>().SetTrigger("Change");

    }



    void BalaoOut(int i)
    {
        txt[i].SetActive(false);
        balao.GetComponent<Animator>().SetTrigger("Change");
    }

    void BalaoOut1(int i)
    {
        txt[i].SetActive(false);
        balao1.GetComponent<Animator>().SetTrigger("Change");
    }




}
