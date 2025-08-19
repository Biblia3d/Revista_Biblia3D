using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[Obsolete("Depreciado em virtude do Localization, deve ser removido apos ser substituir em todos os lugares do projeto")]
public class Translate : MonoBehaviour
{
    public Scene scene;
    public Text texto;
    public TextMesh text;

    [TextArea]
    public string textAreaBr, textAreaUsa;
    public bool ok;
    // Use this for initialization

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    void Update()
    {
        if (scene.name == "Scene")
        {
            if (PlayerPrefs.GetString("Language") == "Portuguese")
            {
                texto.text = textAreaBr;
            }
            else if (PlayerPrefs.GetString("Language") == "English")
            {
                texto.text = textAreaUsa;
            }
        }
        else
        {
            if (PlayerPrefs.GetString("Language") == "Portuguese" && !ok)
            {
                if(text != null)
                {
                    text.text = textAreaBr;
                }else
                    texto.text = textAreaBr;

                ok = true;
            }
            else if (PlayerPrefs.GetString("Language") == "English" && !ok)
            {
                if (text != null)
                {
                    text.text = textAreaUsa;
                }
                else
                    texto.text = textAreaUsa;
                ok = true;
            }
        }

    }
 
}
