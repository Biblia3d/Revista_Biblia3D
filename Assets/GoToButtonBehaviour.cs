using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToButtonBehaviour : MonoBehaviour
{
    public Sprite sprite;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
        if(SceneManager.GetSceneByName("Scene 3").isLoaded || SceneManager.GetSceneByName("Scene 6").isLoaded)
        {
            Image image = gameObject.GetComponent<Image>();
            //image.sprite = sprite;
            //image.color = new Color(191, 63, 50, 255);

            if (PlayerPrefs.GetString("Language").Equals("Portuguese"))
                text.text = "Hora de Atacar!";
            else
                text.text = "Attack time!";

            text.color = Color.white;
            GetComponent<Button>().enabled = false;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
