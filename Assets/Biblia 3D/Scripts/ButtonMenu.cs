using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenu : MonoBehaviour {

    private Animator anim;
    public bool on;
    [Tooltip("Utilizado no Menu inicial do jogo")]
    [Header("Telas do Menu Principal")]
    public GameObject tela;
    public GameObject tela1;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    private void OnEnable()
    {
        on = false;
    }

    public void Show()
    {
        if (!on)
        {
            anim.SetTrigger("Show");
            on = true;
        }
        else
        {
            anim.SetTrigger("Close");
            on = false;
        }
    }

    public void Close()
    {
        if (on)
        {
            anim.SetTrigger("Close");
            on = false;
        }
    }

    void On()
    {
        on = false;
    }

    public void Exit()//Utilizado no botao Exit das telas Biblia3D, Batalhas de Davi e Davi Cards
    {
        anim.SetTrigger("Close");
        on = false;
        Invoke("Disable", 1);
    }

    void Disable()
    {
        tela.SetActive(false);
        tela1.SetActive(true);
    }

}
