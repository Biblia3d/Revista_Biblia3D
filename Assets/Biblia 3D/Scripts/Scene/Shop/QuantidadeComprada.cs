using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuantidadeComprada : MonoBehaviour
{

    public int quantidade = 0;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        quantidade = PlayerPrefs.GetInt(gameObject.name);
        text.text = quantidade.ToString();
    }
}
