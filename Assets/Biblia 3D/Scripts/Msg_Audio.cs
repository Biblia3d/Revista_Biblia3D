using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Msg_Audio : MonoBehaviour {

    private Scene scene;
    public GameObject msg;

    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "Scene 2":
                if(PlayerPrefs.GetInt("Ouviu02") < 1)
                {
                    msg.SetActive(true);
                }
                break;
            case "Scene 3":
                if (PlayerPrefs.GetInt("Ouviu03") < 1)
                {
                    //msg.SetActive(true);
                }
                break;
            case "Scene 4":
                if (PlayerPrefs.GetInt("Ouviu06") < 1)
                {
                    //msg.SetActive(true);
                }
                break;
            case "Scene 5":
                if (PlayerPrefs.GetInt("Ouviu08") < 1)
                {
                    msg.SetActive(true);
                }
                break;
            case "Scene 6":
                if (PlayerPrefs.GetInt("Ouviu10") < 1)
                {
                    msg.SetActive(true);
                }
                break;
            case "Scene 7":
                
                break;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
