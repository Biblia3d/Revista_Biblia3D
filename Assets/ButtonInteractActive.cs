using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractActive : MonoBehaviour
{
    public string nome;
    // Start is called before the first frame update
    void Start()
    {
        nome = gameObject.name;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!nome.Equals("Pedra")&&!nome.Equals("Harpa"))
        {
            if (PlayerPrefs.GetInt(nome) > 0)
            {
                gameObject.GetComponent<Button>().interactable = true;
               
            }
            else
            {
                gameObject.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void GastaItem()
    {
        if (PlayerPrefs.GetInt(nome) > 0)
        {
            PlayerPrefs.SetInt(nome, PlayerPrefs.GetInt(nome) - 1);
            PlayerPrefs.SetInt(nome + "Qtd", PlayerPrefs.GetInt(nome));
        }
    }
    
}
