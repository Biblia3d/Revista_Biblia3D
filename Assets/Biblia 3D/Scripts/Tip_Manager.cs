using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Tip 
{
	public string name;
}

[Obsolete("Classe mal escrita para exibicao de informacoes de capitulo")]
public class Tip_Manager : MonoBehaviour {

	public static Tip_Manager Instance;

	private Animator anim;
	[Tooltip("As dicas dos paranaue")]
	public List<Tip> tips;

	public bool tipShow = false;


	void Awake ()
	{
		Instance = this;
		anim = GetComponent<Animator> ();
	}

	public void ShowTip(string name)
	{

		anim.SetTrigger ("Open");
        Invoke("CloseTip", 3);
        
	}

	public void CloseTip()
	{
		tipShow = false;
		anim.SetTrigger ("Close");
       
    }
		
	

}
