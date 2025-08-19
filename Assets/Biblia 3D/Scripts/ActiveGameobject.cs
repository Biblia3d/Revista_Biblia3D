using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ActiveGameobject : MonoBehaviour {

    public GameObject obj, gm, foco;
    public GameObject[] tracks;

    private void Start()
    {
        tracks = GameObject.FindGameObjectsWithTag("Target");
    }
    public void Ativar()
    {
        obj.SetActive(true);
        gm.GetComponent<RefreshARCam>().Despausar();
        foco.SetActive(true);

    }

    public void DisableTargets()
    {
        for(int i = 0; i < tracks.Length; i++)
        {
            tracks[i].GetComponent<ImageTargetBehaviour>().enabled = false;
        }
    }

	public void Pausar()
	{
		gm.GetComponent<RefreshARCam>().Pausar();
	}

}
