using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Licoes : MonoBehaviour {
    
    public Text txt;
    public float time;
    public GameObject davi, msg;
	// Use this for initialization
	void Start () {
        Invoke("SetTxt1", time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetTxt1()
    {
        if (PlayerPrefs.GetInt("Usa") == 0)
        {
            txt.text = "A confiança e a obediência fizeram dele um vencedor!";
        }
        else
        {
            txt.text = "Trust and obedience made him a winner!";
        }
        Invoke("Davi", time);
    }

    void Davi()
    {
        davi.GetComponent<Animator>().SetTrigger("Change");
        msg.SetActive(false);
    }
}
