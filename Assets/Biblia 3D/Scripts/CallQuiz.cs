using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallQuiz : MonoBehaviour {
    public GameObject pergunta;
    public Text txt;
    public GameObject msg, msg2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pergunta()
    {
        pergunta.SetActive(true);
    }

    void ChangeTextFlag()
    {
        if (PlayerPrefs.GetInt("Usa") == 0)
        {
            txt.text = "Em breve mudaremos essa página";
        }
        else
        {
            txt.text = "We will soon change this page";
        }

        if (msg !=null)
            msg.SetActive(true);
        if(msg2!=null)
            msg2.SetActive(false);
        
    }

    void DisableScript()
    {
        gameObject.GetComponent<Interact_Obj>().enabled = false;
    }
}
