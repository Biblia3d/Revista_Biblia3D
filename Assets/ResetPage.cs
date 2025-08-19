using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetPage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PiscarZero();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetAtividades()
    {
        switch (SceneManager.GetActiveScene().name)
        {

            default:
                if (SceneManager.GetSceneByBuildIndex(15).isLoaded)
                {
                    PlayerPrefs.SetInt("DragTheStonesToGoliathToStumble", 0);
                    PlayerPrefs.SetInt("OuvirCapa", 0);
                    SceneManager.UnloadSceneAsync("Capa");
                    SceneManager.LoadScene("Capa",LoadSceneMode.Additive);
                }

                break;
            case "Scene 2":
                PlayerPrefs.SetInt("TocouRock", 0);
                PlayerPrefs.SetInt("TocouTree", 0);
                PlayerPrefs.SetInt("Tick1Scn2", 0);

                PlayerPrefs.SetInt("TocouOvelha", 0);
                PlayerPrefs.SetInt("Tick2Scn2", 0);
                PlayerPrefs.SetInt("Ouviu02", 0);
                PlayerPrefs.SetInt("Tick3Scn2",0 );
                PlayerPrefs.SetInt("CompleteScene2", 0); //esse valor é setado como 1 no Update do Script ChecklistSceneComponent
                SceneManager.LoadScene("Scene 2");
                break;

            case "Scene 3":
                PlayerPrefs.SetInt("Ouviu03", 0);
                PlayerPrefs.SetInt("Ouviu04", 0);
                PlayerPrefs.SetInt("DeadUrso", 0);
                PlayerPrefs.SetInt("DeadLeao", 0);
                PlayerPrefs.SetInt("Tick1Scn3", 0);
                PlayerPrefs.SetInt("Tick3Scn3", 0);
                PlayerPrefs.SetInt("Tick2Scn3", 0);
                PlayerPrefs.SetInt("CompleteScene3", 0);
                SceneManager.LoadScene("Scene 3");
                break;

                case "Scene 4":
                PlayerPrefs.SetInt("TocouBarraca", 0);
                PlayerPrefs.SetInt("TocouBarraca1", 0);
                PlayerPrefs.SetInt("TocouBarraca2", 0);
                PlayerPrefs.SetInt("Tick1Scn4", 0);
                PlayerPrefs.SetInt("Tick2Scn4", 0);
                PlayerPrefs.SetInt("Tick3Scn4", 0);

                PlayerPrefs.SetInt("TocouOvelha", 0);
                PlayerPrefs.SetInt("Ouviu06", 0);
                PlayerPrefs.SetInt("CertaResposta", 0);
                PlayerPrefs.SetInt("CompleteScene4", 0);
                SceneManager.LoadScene("Scene 4");
                break;
            case "Scene 5":
                
                PlayerPrefs.SetInt("Tick1Scn5", 0);
                PlayerPrefs.SetInt("Tick2Scn5", 0);
                PlayerPrefs.SetInt("Tick3Scn5", 0);

                PlayerPrefs.SetInt("TocouDavi", 0);
                PlayerPrefs.SetInt("TocouDaviArmor", 0);
                PlayerPrefs.SetInt("Ouviu08", 0);
                PlayerPrefs.SetInt("CompleteScene5", 0);
                SceneManager.LoadScene("Scene 5");
                break;

            case "Scene 6":
                PlayerPrefs.SetInt("Tick1Scn6", 0);
                PlayerPrefs.SetInt("Tick2Scn6", 0);

                PlayerPrefs.SetInt("Ouviu10", 0);
                PlayerPrefs.SetInt("DeadGolias", 0);
                PlayerPrefs.SetInt("CompleteScene6", 0);
                SceneManager.LoadScene("Scene 6");
                break;
        }

    }

    public void PiscarZero()
    {
        switch (SceneManager.GetActiveScene().name)
        {

            default:
                if (SceneManager.GetSceneByBuildIndex(15).isLoaded)
                {
                    int count =
                    PlayerPrefs.GetInt("DragTheStonesToGoliathToStumble") +
                    PlayerPrefs.GetInt("OuvirCapa");
                    if(count>=2)
                        GetComponent<Animator>().enabled = true;
                }

                break;
            case "Scene 2":
                
                if(PlayerPrefs.GetInt("CompleteScene2")>0)
                GetComponent<Animator>().enabled = true;
                break;

            case "Scene 3":
                
                if(PlayerPrefs.GetInt("CompleteScene3")> 0)
                    GetComponent<Animator>().enabled = true; 
                break;

            case "Scene 4":
                
                if(PlayerPrefs.GetInt("CompleteScene4")> 0)
                    GetComponent<Animator>().enabled = true;
                break;
            case "Scene 5":

                if(PlayerPrefs.GetInt("CompleteScene5")> 0)
                GetComponent<Animator>().enabled = true;
                break;

            case "Scene 6":
                if(PlayerPrefs.GetInt("CompleteScene6")> 0)
                    GetComponent<Animator>().enabled = true;
                break;
        }
    }
}
