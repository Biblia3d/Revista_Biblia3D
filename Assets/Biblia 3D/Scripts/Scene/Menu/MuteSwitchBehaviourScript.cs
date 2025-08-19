using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSwitchBehaviourScript : MonoBehaviour
{
    [Header("Informacoes basicas")]
    public Sprite on;
    public Sprite off;

    [Header("Informacoes basicas")]
    public Image image;

    public AudioSource music;
    private GameObject musicSource;

    // Start is called before the first frame update
    void Awake()
    {
        musicSource = GameObject.FindGameObjectWithTag("Music");

        if(musicSource != null)
        music = musicSource.GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("Mute") == 0)
        {
            image.sprite = on;
            if (music != null)
            {
                music.volume = 0.3f;
            }
        }
        else
        {
            image.sprite = off;
            if (music != null)
            {
                music.volume = 0;
            }
        }

        ChangeSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        if (PlayerPrefs.GetInt("Mute") == 0)
        {
            image.sprite = off;
            PlayerPrefs.SetInt("Mute", 1);
            if(music!=null)
            {
                music.volume = 0;
            }
        } else
        {
            image.sprite = on;
            PlayerPrefs.SetInt("Mute", 0);
            if (music != null)
            {
                music.volume = 0.3f;
            }
        }
    }

    public void ChangeSprite()
    {
        if (PlayerPrefs.GetInt("Mute") == 0)
        {
            image.sprite = on;
        }
        else
        {
            image.sprite = off;
            
        }
    }
}
