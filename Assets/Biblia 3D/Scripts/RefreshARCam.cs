using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Vuforia;

[Obsolete("Esta classe deve ser removida apos modificar o recurso melhor de uso das mensagens, pois as mesas estao sendo ditas o tempo todo, quando deveria ser dita quando nao estivesse conseguindo ver a imagem")]
public class RefreshARCam : MonoBehaviour {

    public static RefreshARCam instance;
    public GameObject ArCam;
    public Biblia3dTrackableEventHandler[]track;
    public int count = 0;
	public bool pause;
	public int chave = 0;
    public Text txt;
	public int cont = 0;
	public int desativado=0;

	// Use this for initialization
	void Start () {
        instance = this;
		//if (!SceneManager.GetActiveScene().name.Contains("Card"))
		//{
		//	if (PlayerPrefs.GetString("Language") == "Portuguese")
		//	{
		//		if (txt != null)
		//			txt.text = "USE A PÁGINA DA DIREITA";
		//		Sound_Manager.Instance.PlayOneShot("Informacao");
		//	}
		//	else
		//	{
		//		if (txt != null)
		//			txt.text = "USES THE RIGHT PAGE";
		//		Sound_Manager.Instance.PlayOneShot("Information");
		//	}
		//}
		//else
		//{
		//	if (PlayerPrefs.GetString("Language") == "Portuguese")
		//	{
		//		if (txt != null)
		//			txt.text = "VERIFIQUE SE ESTÁ NA IMAGEM CERTA";
		//		Sound_Manager.Instance.PlayOneShot("Informacao");
		//	}
		//	else
		//	{
		//		if (txt != null)
		//			txt.text = "MAKE SURE IT'S THE RIGHT IMAGE";
		//		Sound_Manager.Instance.PlayOneShot("Information");
		//	}
		//}
		//StartCoroutine(Refresh());
		
	}
	
	
    IEnumerator Refresh()
    {
        yield return new WaitForSeconds(4);

		for(int i = 0; i < track.Length; i++)
		{
            if (track[i] != null)
            {
                if (track[i].isTracking)
                {
                    cont++;
                    count = 0;
                }
                else
                {
                    desativado++;
                }
            }
		}

		if(desativado == track.Length)
		{
			cont = 0;
		}

        if (cont==0)
        {
            if (!pause)
            {
				for (int i = 0; i < track.Length; i++)
				{
					/*if (track[i] != null && !track[i].isTracking)
						ArCam.SetActive(false);
					ArCam.SetActive(true);*/
				}
                count++;
                if (count == 3)
                {
                    if (!SceneManager.GetActiveScene().name.Contains("Card"))
                    {
                        if (PlayerPrefs.GetString("Language") == "Portuguese")
                        {
                            if (txt != null)
                                txt.text = "USE A PÁGINA DA DIREITA";
							if (chave == 0) {
								Sound_Manager.Instance.PlayOneShot("Informacao");
								chave ++;
							}
							else if(chave == 1)
							{
								Sound_Manager.Instance.PlayOneShot("Iluminacao");
								chave ++;
							}
							else
							{
								Sound_Manager.Instance.PlayOneShot("Brilho");
								chave = 0;
							}
                        }
                        else
                        {
                            if (txt != null)
                                txt.text = "USES THE RIGHT PAGE";
							if (chave == 0)
							{
								Sound_Manager.Instance.PlayOneShot("Information");
								chave ++;
							}
							else if(chave == 1)
							{
								Sound_Manager.Instance.PlayOneShot("Ilumination");
								chave++;
							}
							else
							{
								Sound_Manager.Instance.PlayOneShot("Shine");
								chave = 0;
							}
						}
                    }
                    else
                    {
                        if (PlayerPrefs.GetString("Language") == "Portuguese")
                        {
                            if (txt != null)
                                txt.text = "VERIFIQUE SE ESTÁ NA IMAGEM CERTA";
							if (chave == 0)
							{
								Sound_Manager.Instance.PlayOneShot("Informacao");
								chave++;
							}
							else if(chave == 1)
							{
								Sound_Manager.Instance.PlayOneShot("Iluminacao");
								chave++;
							}
							else
							{
								Sound_Manager.Instance.PlayOneShot("Brilho");
								chave = 0;
							}
						}
                        else
                        {
                            if (txt != null)
                                txt.text = "MAKE SURE IT'S THE RIGHT IMAGE";
							if (chave == 0)
							{
								Sound_Manager.Instance.PlayOneShot("Information");
								chave ++;
							}
							else if(chave == 1)
							{
								Sound_Manager.Instance.PlayOneShot("Ilumination");
								chave ++;
							}
							else
							{
								Sound_Manager.Instance.PlayOneShot("Shine");
								chave=0;
							}
						}
                    }

                    count = 0;
                }
            }
        }

		cont = 0;
		desativado = 0;
		
        StartCoroutine( Refresh());
        Debug.Log("REFRESH");
        
       
    }

    public void Pausar()
    {
        pause = true;
    }

    public void Despausar()
    {
        pause = false;
    }
}
