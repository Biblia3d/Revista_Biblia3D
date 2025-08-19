using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtivarSinalDeMais : MonoBehaviour
{

    public Text textPlus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Text>().text == "    Interatividade" || gameObject.GetComponent<Text>().text == "    Interactivity")
        {
            textPlus.gameObject.SetActive(true);
        }
    }
}
