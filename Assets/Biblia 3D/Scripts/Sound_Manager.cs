using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Obsolete("Esta classe deve ser removida depois de retirar todas as referencias no Unity")]
[ExecuteInEditMode]
public class Sound_Manager : MonoBehaviour
{
	//Instance
	public static Sound_Manager Instance;

	//Privates
	private AudioSource audioSrc;
	private GameObject music;

	//Publics
	public List<Sound> sounds;

	// Use this for initialization
	void Awake ()
	{
		Instance = this;

		if (!GetComponent<AudioSource> ())
			this.gameObject.AddComponent <AudioSource>();

		audioSrc = GetComponent<AudioSource> ();

		music = GameObject.FindWithTag ("Music");

	}

	void Update(){
		
	}

	public void PlayOneShot(string clipName)
	{
		foreach (Sound i in sounds) 
		{
			if (i.name == clipName) 
			{
				audioSrc.PlayOneShot (i.clip,i.volume);
				return;
			}
		}

		Debug.Log ("The sound named \""+clipName+"\" doesnt exists in Sound_Manager");
	}
	public void PlayStory08(string clipName){
		foreach (Sound i in sounds) {
			if (i.name == clipName) {
				audioSrc.PlayOneShot (i.clip, i.volume);
				return;
			}
		}
		if (music.GetComponent<AudioSource>().isPlaying) {
			music.GetComponent<AudioSource> ().volume = 0.15f;
		} else
			music.GetComponent<AudioSource> ().volume = 1f;
	}

    public void ChangeBgSound(AudioClip clip)
    {
        audioSrc.Stop();
        audioSrc.PlayOneShot(clip);
    }

	public void PlayMusic()
	{
		if (!music.GetComponent<AudioSource>().isPlaying)
		{
			music.GetComponent<AudioSource>().Play();
		}
	}

	public void StopMusic()
	{
        if (music != null)
		    music.GetComponent<AudioSource>().Stop();
	}

}

