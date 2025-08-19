using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vuforia;

public class TouchBarraca : MonoBehaviour {

	// Use this for initialization
	private Biblia3dTrackableEventHandler tracker;

	public GameObject pergunta;
    public GameObject barraca2, barraca3;
    public GameObject bigTent;
    public Material brown;
    public GameObject number, number1, seta, seta1;
	public GameObject checklist;
	//private Animator anim;

	// Use this for initialization
	void Start () {
		tracker = GetComponentInParent<Biblia3dTrackableEventHandler> ();
	//	anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) { // if left button pressed...
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.name == this.gameObject.name&&PlayerPrefs.GetInt("Acertou")<3) {
					pergunta.SetActive (true);
					//pergunta.GetComponent<Quiz> ().Read ();
					//pergunta.GetComponent<Quiz> ().Generate ();
					GetComponent<BoxCollider> ().enabled = false;
					PlayerPrefs.SetInt("TocouBarraca", PlayerPrefs.GetInt("TocouBarraca")+1);
					//pergunta.SetActive (false);
					//pergunta.SetActive (true);
					GameObject.FindGameObjectWithTag("SoundManager").GetComponent<Sound_Manager>().PlayOneShot("Tent");                    number.GetComponent<Animator>().SetTrigger("Reset");
                    Invoke("DisableAnimator", 1);
				}
			}

		}
	}

	public void PlaySound(string clipName){
		if (!tracker.isTracking)
			return;
		Sound_Manager.Instance.PlayOneShot (clipName);
	}

	void OnTriggerEnter(Collider colisor){
	}

//	public void proximaPagina(){
//		if(PlayerPrefs.GetInt("TocouBarraca")==3)
//		tick.SetActive (true);
//	}

	public void respostaCerta(){
		PlayerPrefs.SetInt ("CertaResposta",PlayerPrefs.GetInt("CertaResposta")+1);
		if (gameObject.name == "Barraca 3")
		{
			if (PlayerPrefs.GetInt("Scene 4") == 1)
				Invoke("Parabens", 2);
		}
	}
    public void Barraca2()
    {
        barraca2.GetComponent<TouchBarraca>().enabled = true;
        if(seta !=null)
        seta.SetActive(false);
        if(seta1!=null)
        seta1.SetActive(true);
    }
    public void Barraca3()
    {
        barraca3.GetComponent<TouchBarraca>().enabled = true;
        if (seta != null)
            seta.SetActive(false);
        if (seta1 != null)
            seta1.SetActive(true);
    }
    public void ChangeTexture()
    {
        bigTent.GetComponent<SkinnedMeshRenderer>().material = brown;
        if (seta != null)
            seta.SetActive(false);
    }

    public void EnableNumber()
    {
        number1.GetComponent<Animator>().enabled = true;
    }

    public void DiasableAnimator()
    {
        number.GetComponent<Animator>().enabled = false;
        
    }

	void Parabens()
	{
		checklist.GetComponent<Checklist>().Parabens();
	}

}
