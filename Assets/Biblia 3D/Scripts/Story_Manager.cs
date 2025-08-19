using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class Sound
{
	public string name;
	public AudioClip clip;
	[Range(0,1)]
	public float volume = 1f;
}

[ExecuteInEditMode]
public class Story_Manager : MonoBehaviour
{
	//Instance
	public static Story_Manager Instance;

	//Privates
	public AudioSource audioSrc;

	//Publics
	public List<Sound> storySounds;

    public GameObject[] musicSource;

	public string atualTrack;

	public string aux ;

	public GameObject buttonVoz;
	public bool playing = false;

	public AudioSource music;
    
	public Button funda;
	// Use this for initialization
	void Awake ()
	{
		Instance = this;

		if (!GetComponent<AudioSource> ())
			this.gameObject.AddComponent <AudioSource>();

		audioSrc = GetComponent<AudioSource> ();

        musicSource = GameObject.FindGameObjectsWithTag("Music");
	}

	void Update()
	{
		//Debug.Log (atualTrack);
        if (aux != atualTrack)
        {
            audioSrc.Pause();
            playing = false;
        }
        else
        {
            audioSrc.UnPause();
            playing = true;
        }

        if (audioSrc.isPlaying)
        {
            if (atualTrack == "Verso" || atualTrack == "Capa")
            {
                for (int i = 0; i < musicSource.Length; i++)
                {
                    musicSource[i].GetComponent<AudioSource>().volume = 0.15f;
                }
            }
            if (music != null)
            {
                music.GetComponent<AudioSource>().volume = 0.15f;
            }
        }
        else
        {
            if (atualTrack == "Verso" || atualTrack == "Capa")
            {
                for (int i = 0; i < musicSource.Length; i++)
                {
                    musicSource[i].GetComponent<AudioSource>().volume = 0.2f;
                }
            }
            if (music != null)
            {
                music.GetComponent<AudioSource>().volume = 0.2f;
            }
        }

		if(atualTrack == "10" && playing)
		{
			if (!audioSrc.isPlaying)
			{
				funda.interactable = true;
			}
		}
	}

//	public void PlayOneShot(string clipName)
//	{
//		foreach (Sound i in sounds) 
//		{
//			if (i.name == clipName) 
//			{
//				audioSrc.PlayOneShot (i.clip,i.volume);
//				return;
//			}
//		}
//
//		Debug.Log ("The sound named \""+clipName+"\" doesnt exists in Sound_Manager");
//	}

	public void PlayStory()
	{

        if (!audioSrc.isPlaying)
        {
            aux = atualTrack;
            if (PlayerPrefs.GetString("Language") == "Portuguese")
            {
                if (aux == "02" || aux == "03" || aux == "06" || aux == "08" || aux == "10" || aux == "Capa" || aux == "Verso" || aux == "12" || aux == "14" || aux == "16" || aux == "18" || aux == "20"|| aux == "22")
                {
                    playing = true;
                    PlayerPrefs.SetInt("Ouviu" + atualTrack, 1);
                    //music.Pause ();
                    foreach (Sound i in storySounds)
                    {
                        if (i.name == atualTrack)
                        {
                            audioSrc.PlayOneShot(i.clip, i.volume);
                            Invoke("wait", i.clip.length);
                            return;
                        }

                    }

                }
            }
            else if (PlayerPrefs.GetString("Language") == "English")
            {
                if (aux == "02" || aux == "03" || aux == "06" || aux == "08" || aux == "10" || aux == "Capa" || aux == "Verso" || aux == "12" || aux == "14" || aux == "16" || aux == "18" || aux == "20"||aux == "22")
                {
                    playing = true;
                    PlayerPrefs.SetInt("Ouviu" + atualTrack, 1);
                    //music.Pause ();
                    foreach (Sound i in storySounds)
                    {
                        if (i.name == atualTrack+"Us")
                        {
                            audioSrc.PlayOneShot(i.clip, i.volume);
                            Invoke("wait", i.clip.length);
                            return;
                        }

                    }

                }
            }
            else
            {
                audioSrc.Stop();
                playing = false;
                CancelInvoke("wait");
            }
        }
		

		Debug.Log ("The sound named \""+atualTrack+"\" doesnt exists in Sound_Manager");
	}

	public void PlayUrso(){
		
        if(PlayerPrefs.GetString("Language") == "Portuguese")
		foreach (Sound i in storySounds) {
			if (i.name == "Urso") {
				audioSrc.PlayOneShot (i.clip, i.volume);
				return;
			}
            }
        else
        {
            foreach (Sound i in storySounds)
            {
                if (i.name == "UrsoUs")
                {
                    audioSrc.PlayOneShot(i.clip, i.volume);
                    return;
                }
            }

        }
	}

    public void PlayFinal22()
    {

        if (PlayerPrefs.GetString("Language") == "Portuguese")
            foreach (Sound i in storySounds)
            {
                if (i.name == "Final")
                {
                    audioSrc.PlayOneShot(i.clip, i.volume);
                    return;
                }
            }
        else
        {
            foreach (Sound i in storySounds)
            {
                if (i.name == "FinalUS")
                {
                    audioSrc.PlayOneShot(i.clip, i.volume);
                    return;
                }
            }

        }
    }

    void wait(){
        if(buttonVoz!=null)
		buttonVoz.GetComponent<Button> ().interactable = true;
	}

}

