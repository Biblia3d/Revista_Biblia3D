using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Vuforia;

[Obsolete("Em funcao da confusao de desenvolvimento e isolamento de scenes")]
public class Interact_Obj : MonoBehaviour {

	// Use this for initialization
	public Biblia3dTrackableEventHandler tracker;

	private Animator anim;
	private GameObject ave;
    public GameObject seta, seta1;
    public bool ativarSeta;
    public GameObject objeto = null;
    public GameObject golias;
    public GameObject ovelha1, ovelha2, ovelha3, ovelha4; //Ovelhas que vão berrar quando tocar na árvore Pag 2
    public Sound_Manager sound_Manager;
    public AudioClip audioStory;
    public bool wait = false, mouse;
    public GameObject aguarde;
    bool aguardou = false;

    // Use this for initialization
    void Start () {
        mouse = true;
		if(tracker==null)
			tracker = GetComponentInParent<Biblia3dTrackableEventHandler> ();
		anim = GetComponent<Animator> ();
		ave = GameObject.FindWithTag ("Bird");
        if (sound_Manager == null)
        {
            sound_Manager = Sound_Manager.Instance;
        }
	}

    public void OnEnable()
    {
        mouse = true;

        Scene scene = SceneManager.GetActiveScene();

        switch (scene.name)
        {
            case "Scene 9":
                wait = true;
                break;
            case "Scene 10":
                wait = true;
                break;
            case "Scene 11":
                wait = true;
                break;
            default:
                wait = false;
                break;

        }

        
    }

    // Update is called once per frame
    void Update ()
	{
		/*if (Input.GetMouseButtonDown (0)) { // if left button pressed...
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.name == this.gameObject.name) {
					Debug.Log ("Teste");
					anim.SetTrigger ("Change");
					PlayerPrefs.SetInt ("Tocou"+this.gameObject.name,PlayerPrefs.GetInt ("Tocou"+gameObject.name)+1);
                    if (ativarSeta && SceneManager.GetActiveScene().name != "Scene 5")
                    {
                        Seta();
					}
					else
					{
						Invoke("Seta", 3);
						Invoke("EnableInteractScript", 3);
					}

                    if(gameObject.name == "Golias")
                    {
                        
                        golias.GetComponent<GoliasIdle>().stop = true;
                        golias.GetComponent<GoliasIdle>().time = 10;
                        if (golias.transform.eulerAngles.y != 180)
                        {
                            golias.transform.eulerAngles = new Vector3(golias.transform.eulerAngles.x, 180, golias.transform.eulerAngles.z);
                        }
                    }

                    if (gameObject.name == "Davi" || gameObject.name == "Davi Novo")
                    {
                        GetComponent<Animator>().SetTrigger("pose");
                    }

                    if(gameObject.name == "bau")
                    {
                        gameObject.GetComponent<Interact_Obj>().enabled = false;
                    }
                    
				}
				if (this.gameObject.name == "Tree") {
					if (ave !=null) {
						ave.GetComponent<Animator>().SetTrigger("Change");
                        //ovelha1.GetComponent<Animator>().SetTrigger("Click");
                        //ovelha2.GetComponent<Animator>().SetTrigger("Click");
                        //ovelha3.GetComponent<Animator>().SetTrigger("Click");
                        //ovelha4.GetComponent<Animator>().SetTrigger("Click");
                    }
					Debug.Log ("PEGUNTA");
				}

                if (objeto != null && SceneManager.GetActiveScene().name == "Scene 5")
                {
                    objeto.GetComponent<Interact_Obj>().enabled = true;
                }
			}

		}*/
	}

    void OnMouseDown()
    {
        if (mouse)
        {
            if (!wait || !gameObject.name.Equals("bau"))
            {
                if (gameObject.GetComponent<BoxCollider>() != null && gameObject.name.Contains("bau"))
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(Execute(0));
            }
            else
            {
                if (!aguardou)
                {
                    aguarde.SetActive(true);
                    aguardou = true;
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                StartCoroutine(Execute(audioStory.length));
            }
        }
    }

    IEnumerator Execute(float time)
    {
        yield return new WaitForSeconds(time);

        if(aguarde != null)
        aguarde.SetActive(false);

        Debug.Log("Teste");

        if (!SceneManager.GetActiveScene().name.Equals("Scene 2"))
        {
            anim.SetTrigger("Change");
        }
        else
        {
            if (objeto.name.Equals("Davi"))
            {
                objeto.GetComponent<Davi_Scene2>().TocarHarpa();
            }
            else
                anim.SetTrigger("Change");
        }
            PlayerPrefs.SetInt("Tocou" + this.gameObject.name, PlayerPrefs.GetInt("Tocou" + gameObject.name) + 1);
            if (ativarSeta && SceneManager.GetActiveScene().name != "Scene 5")
            {
                Seta();
            }
            else
            {
                Invoke("Seta", 3);
                Invoke("EnableInteractScript", 3);
            }

            if (gameObject.name == "Golias")
            {

                golias.GetComponent<GoliasIdle>().stop = true;
                golias.GetComponent<GoliasIdle>().time = 10;
                if (golias.transform.eulerAngles.y != 180)
                {
                    golias.transform.eulerAngles = new Vector3(golias.transform.eulerAngles.x, 180, golias.transform.eulerAngles.z);
                }
            }

            if (gameObject.name == "Davi" || gameObject.name == "Davi Novo")
            {
                GetComponent<Animator>().SetTrigger("pose");
            }

            if (gameObject.name == "bau")
            {
                gameObject.GetComponent<Interact_Obj>().enabled = false;
            }

            if (this.gameObject.name == "Tree")
            {
                if (ave != null)
                {
                    ave.GetComponent<Animator>().SetTrigger("Change");
                    //ovelha1.GetComponent<Animator>().SetTrigger("Click");
                    //ovelha2.GetComponent<Animator>().SetTrigger("Click");
                    //ovelha3.GetComponent<Animator>().SetTrigger("Click");
                    //ovelha4.GetComponent<Animator>().SetTrigger("Click");
                }
                Debug.Log("PEGUNTA");
            }

            if (objeto != null && SceneManager.GetActiveScene().name == "Scene 5")
            {
                objeto.GetComponent<Interact_Obj>().enabled = true;
            }
        

    }


    public void PlaySound(string clipName){
		if (tracker != null && !tracker.isTracking)
			return;
        if(SceneManager.GetActiveScene().name.Equals("Scene 2") && objeto.name.Equals("Davi"))
        {
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            string state = currentState.shortNameHash.ToString();
            if (!gameObject.GetComponent<Davi_Scene2>().changeHarpaSound && state.Equals("TocandoHarpa")) { //som de harpa normal
            print("SCENE 2 e OBJETO DAVI TOCANDO HARPA");
            
                objeto.GetComponent<Davi_Scene2>().PlaySound(clipName);
                //objeto.GetComponent<Davi_Scene2>().TocarHarpa();

            }
            else if (gameObject.GetComponent<Davi_Scene2>().changeHarpaSound && state.Equals("TocandoRock")) //som de Rock
            {
                print("ENTROU " + clipName + " OU ROCK");
                //objeto.GetComponent<Davi_Scene2>().changeHarpaSound = false;
                objeto.GetComponent<Davi_Scene2>().PlaySound(clipName);
            }
            else if (sound_Manager != null)
            {
                print("TOCOU " + clipName + " AQUI");
                sound_Manager.PlayOneShot(clipName);
            }//toca demais sons
        }
        else if (sound_Manager != null)
        {
            sound_Manager.PlayOneShot(clipName);
        }

    }

	//void OnTriggerEnter(Collider colisor){
	//	if (colisor.tag == "Leao") {

	//		if (name == "birch_0" || name == "birch_1" || name == "birch_2"||name=="birch_3") {
	//		}else
	//		anim.SetTrigger ("Change");

	//	}
	//}

    public void Seta()
    {
        if (seta != null)
            Destroy(seta);
        if (seta1 != null)
            seta1.SetActive(true);
        ativarSeta = false;
    }

	void EnableInteractScript()
	{
		if(objeto!=null)
			objeto.GetComponent<Interact_Obj>().enabled = true;
		if(objeto != null && objeto.GetComponent<Davi_Controller>() != null)
			objeto.GetComponent<Davi_Controller>().enabled = true;
	}


}
