using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    // Start is called before the first frame update
    public int cont = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cont == 3)
        {
            ApplyCheat();
        }
    }

    public void GoCheat()
    {
        CancelInvoke("Clear");
        cont++;

        Invoke("Clear", 3);
    }

    public void Clear()
    {
        cont = 0;
    }

    public void ApplyCheat()
    {
        PlayerPrefs.SetInt("Moedas", 100000);
        PlayerPrefs.SetString("PokeballEnabled", "true");
        PlayerPrefs.SetInt("CompleteScene", 1);
        PlayerPrefs.SetInt("CompleteScene2", 1);
        PlayerPrefs.SetInt("CompleteScene3", 1);
        PlayerPrefs.SetInt("CompleteScene4", 1);
        PlayerPrefs.SetInt("CompleteScene5", 1);
        PlayerPrefs.SetInt("CompleteScene6", 1);
        PlayerPrefs.SetInt("DragTheStonesToGoliathToStumble", 1);
        Clear();
    }
}
