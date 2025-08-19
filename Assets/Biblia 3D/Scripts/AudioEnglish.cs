using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("Esta classe nao sera mais desnecessaria, ao nao esta sendo usada em nenhuma parte do jogo deve ser removida, ja esta sendo usado um recurso melhor chamado de Localization")]
public class AudioEnglish : MonoBehaviour {
    public string audio;
    public AudioSource sound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show()
    {
        if (PlayerPrefs.GetInt("Usa") == 1)
        {
            gameObject.SetActive(true);
            PlayerPrefs.SetInt(audio, 1);
            Invoke("Disable", 5);
        }

    }

    public void Final()
    {
        if (PlayerPrefs.GetInt("Usa") == 1)
        {
            sound.mute = true;

            gameObject.SetActive(true);
            PlayerPrefs.SetInt(audio, 1);
            Invoke("Disable", 5);
        }
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}
