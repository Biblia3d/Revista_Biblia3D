using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSemMaterial : MonoBehaviour {
    public Animator balao1, balao2;
    public float time;
    public bool b1, b2;
    public Button btn;
    public GameObject seta;
    public int i, cont =0;
    public GameObject baloes;
	public string[] soundName;
	public GameObject soundManager;
    
    
    public GameObject[] texto;
	// Use this for initialization
	void Start () {
        Invoke("Balao1", time);
        texto[0].SetActive(true);
		soundManager.GetComponent<Sound_Manager>().PlayOneShot(soundName[0]);
        balao1.SetTrigger("Change");
        cont++;
    }
	
	void Balao1()
    {
        cont++;
        if (texto.Length >1)
        {
            balao1.SetTrigger("Change");
            balao2.SetTrigger("Change");
            texto[0].SetActive(false);
        
            Invoke("Balao2", time);
            texto[1].SetActive(true);
			soundManager.GetComponent<Sound_Manager>().PlayOneShot(soundName[1]);
		}
        if(cont==i)
        {
            if(btn!=null)
            btn.interactable = true;
            if (seta != null)
            {
                seta.SetActive(true);
            }
        }
        
    }

    void Balao2()
    {
        cont++;
        if (texto.Length >2)
        {
            balao2.SetTrigger("Change");
            balao1.SetTrigger("Change");
            texto[1].SetActive(false);
        
            Invoke("Balao3", time);
            texto[2].SetActive(true);
			soundManager.GetComponent<Sound_Manager>().PlayOneShot(soundName[2]);
		}
        if (cont == i)
        {
            if (btn != null)
                btn.interactable = true;
            if (seta != null)
            {
                seta.SetActive(true);
            }
        }

    }

    void Balao3()
    {
        cont++;
        if (texto.Length >3)
        {
            balao1.SetTrigger("Change");
            balao2.SetTrigger("Change");
            texto[2].SetActive(false);

            Invoke("Balao4", time);
            texto[3].SetActive(true);
			soundManager.GetComponent<Sound_Manager>().PlayOneShot(soundName[3]);
		}
        if (cont == i)
        {
            if (btn != null)
                btn.interactable = true;
            if (seta != null)
            {
                seta.SetActive(true);
            }
        }

    }

    void Balao4()
    {
       // cont++;
        if (cont > 4)
        {
            balao2.SetTrigger("Change");
            balao1.SetTrigger("Change");
            texto[3].SetActive(false);
            Invoke("Balao5", time);
            texto[4].SetActive(true);
		}
        if (texto.Length == i)
        {
            if (btn != null)
                btn.interactable = true;
            if (seta != null)
            {
                seta.SetActive(true);
            }
        }
    }

    void Balao5()
    {

        texto[4].SetActive(false);
        balao2.SetTrigger("Change");
        
            if (btn != null)
                btn.interactable = true;
        if (seta != null)
        {
            seta.SetActive(true);
        }

    }

    public void FecharBalao()
    {
        if (b1)
        {
            balao1.SetTrigger("Change");
        }
        if (b2)
        {
            balao2.SetTrigger("Change");
        }

        if (baloes != null) {
            Invoke("Balao", 5);
        }
    }

    void Balao()
    {
        baloes.SetActive(true);
        gameObject.SetActive(false);
    }
}
