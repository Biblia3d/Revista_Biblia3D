using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public Text moedas, score;
    //public Button[] botao;
    public GameObject bloqueio;
    public  int cont = 0;

    
    // Start is called before the first frame update
    void OnEnable()
    {
        cont = 0;
        string scene = "CompleteScene";
        for (int i = 2; i <= 6; i++)
        {
            if (PlayerPrefs.GetInt(scene + i) == 1)
            {
                cont++;
            }
        }
        if(PlayerPrefs.GetInt("DragTheStonesToGoliathToStumble")==1 && cont== 5)
        {
            LiberarLoja();
        }
    }

    // Update is called once per frame
    void Update()
    {
        moedas.text = "Moedas: $" + PlayerPrefs.GetInt("Moedas");
        score.text = "Score:" + PlayerPrefs.GetInt("Score");
    }

    public void LiberarLoja()
    {
        
            bloqueio.SetActive(false);
        cont = 0;
        
    }

    public void ShopRockMusic()
    {
        //PlayerPrefs.SetString("RockMusicEnabled", "true");
        if (PlayerPrefs.GetInt("Moedas") >= 500)
        {
            PlayerPrefs.SetInt("Moedas", PlayerPrefs.GetInt("Moedas") - 500);
            PlayerPrefs.SetInt("RockMusic", PlayerPrefs.GetInt("RockMusic") + 1);
            PlayerPrefs.SetInt("RockMusicQtd", PlayerPrefs.GetInt("RockMusicQtd") + 1);
        }
    }
    public void ShopPokeBall()
    {
        PlayerPrefs.SetString("PokeballEnabled", "true");
        if (PlayerPrefs.GetInt("Moedas") >= 500)
        {
            PlayerPrefs.SetInt("Moedas", PlayerPrefs.GetInt("Moedas") - 500);
            PlayerPrefs.SetInt("Pokeball", PlayerPrefs.GetInt("Pokeball") + 1);
            PlayerPrefs.SetInt("PokeballQtd", PlayerPrefs.GetInt("PokeballQtd") + 1);
        }
    }

    public void PlaySound(string sound)
    {
        Sound_Manager.Instance.PlayOneShot(sound);
    }

    public void Comprar(int value)
    {
        if (PlayerPrefs.GetInt("Moedas") >= value)
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - value);
    }
}
