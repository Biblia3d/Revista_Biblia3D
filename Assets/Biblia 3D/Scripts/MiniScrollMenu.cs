using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Obsolete("Muitos problemas e dependencias desnecessarias, criar uma nova chamada e remover esta")]
public class MiniScrollMenu : MonoBehaviour {

	private GameObject cam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlaySound(string som)
	{
		Sound_Manager.Instance.PlayOneShot(som);
	}

	public void ChangeScene(string scene)
	{
		GameObject gManager = GameObject.FindGameObjectWithTag("GameManager");
		StartCoroutine(ChangeSceneWL(scene, gManager));
		
	}

	IEnumerator ChangeSceneWL(string scene, GameObject gManager)
	{
		yield return new WaitForSecondsRealtime(2);
		gManager.GetComponent<Game_Manager>().ChangeSceneWithOutLoad(scene);
	}

	public void ChangeSceneLoad(string scene)
	{
		GameObject gManager = GameObject.FindGameObjectWithTag("GameManager");
		gManager.GetComponent<Game_Manager>().ChangeScene(scene);
	}

	public void AddScene(string scene)
	{
		GameObject gManager = GameObject.FindGameObjectWithTag("GameManager");
		gManager.GetComponent<Game_Manager>().AddScene(scene);
		gManager.GetComponent<RefreshARCam>().Pausar();
		cam = GameObject.FindGameObjectWithTag("ARCam");
		if(cam.GetComponent<RefreshARCam>()!=null)
		cam.GetComponent<RefreshARCam>().enabled = false;
		cam.SetActive(false);
	}

	public void UnloadScene(string scene)
	{
		GameObject gManager = GameObject.FindGameObjectWithTag("GameManager");
		gManager.GetComponent<Game_Manager>().UnloadScene(scene);
		if (cam != null)
		{
			cam.SetActive(true);
			cam.GetComponent<RefreshARCam>().enabled = true;
			gManager.GetComponent<RefreshARCam>().Despausar();
		}
	}
}
