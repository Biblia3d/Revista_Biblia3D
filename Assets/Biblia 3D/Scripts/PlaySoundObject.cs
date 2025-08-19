using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundObject : MonoBehaviour {

    public bool autoPlay;
    public string nome;

    private void Start()
    {
        if (autoPlay)
        {
            PlaySound(nome);
        }
    }

	private void OnEnable()
	{
		if (autoPlay)
		{
			PlaySound(nome);
		}
	}
	public void PlaySound(string name)
    {
        if(Sound_Manager.Instance)
        Sound_Manager.Instance.PlayOneShot(name);
    }

	void PlayMusic()
	{
		//Sound_Manager.Instance.bgSrc.Play();
	}
}
