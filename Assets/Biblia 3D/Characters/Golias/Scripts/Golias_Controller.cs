using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class Golias_Controller : MonoBehaviour {

	private Biblia3dTrackableEventHandler tracker;
	public GameObject canvas;
	private Animator anim;
    public GameObject davi, licoes, msg;
    public GameObject balao, balao1, balao2;
    public GameObject effect, lanca, rachadura, target;
    public bool dead;
    public int count = 0;


	public bool inPosition = false, stop = false;

	// Use this for initialization
	void Start () {
		tracker = GetComponentInParent<Biblia3dTrackableEventHandler> ();
		anim = GetComponent<Animator> ();

		if(SceneManager.GetActiveScene().name == "CardDG")
		{
			anim.SetTrigger("Walk");

		}
        ResetBalao();
	}

	// Update is called once per frame
	void Update () {
		//Quando Ativo Faz Algo
		if (SceneManager.GetActiveScene().name == "CardDG")
		{
			if (!inPosition)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f * Time.deltaTime);
            }
			else
			{
				inPosition = true;
				if (!stop)
				{
					anim.SetTrigger("Idle");
					stop = true;
				}
			}
		}

        if(tracker!=null)
		if (tracker.isTracking) {
			if (canvas != null) {
				canvas.SetActive (true);
			}
			Touch ();
		} else if (canvas != null) {
			canvas.SetActive (false);
		}

	}

	void Touch()
	{
		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				if(hit.collider.name == this.gameObject.name)
					anim.SetTrigger ("Change");
			}
		}
	}

	public void PlaySound(string clipName){
        if (tracker != null)
            if (!tracker.isTracking)
			return;
		Sound_Manager.Instance.PlayOneShot (clipName);
	}
	public void change(){
		anim.SetTrigger ("Change");
	}

    public void Davi()
    {
        davi.GetComponent<Davi_Controller>().LookAtFront();
        davi.GetComponent<Animator>().SetTrigger("Relax");
        davi.GetComponent<Davi_Controller>().LookAtFront();
    }
    public void Licoes()
    {
        licoes.SetActive(true);
    }

    public void MsgRevista()
    {
        if(msg!=null)
        msg.SetActive(true);
    }

    public void CallBalao()
    {
        Invoke("Balao", 10);
    }

    void Balao()
    {
       if (PlayerPrefs.GetInt("Balao") == 0 && !dead)
        {
            if (count == 0)
            {
                balao.SetActive(true);
                count++;
                Invoke("Balao", 30);
            }
            else if (count == 1)
            {
                balao1.SetActive(true);
                count++;
                Invoke("Balao", 30);
            }
            else
            {

                balao2.SetActive(true);
                count = 0;
                Invoke("Balao", 180);
            }
        }
           // PlayerPrefs.SetInt("Balao",1);
    }

    void Balao1()
    {
        if (PlayerPrefs.GetInt("Balao") == 0)
        {
            balao1.SetActive(true);
            // PlayerPrefs.SetInt("Balao",1);
        }
    }


    void Balao2()
    {
        if (PlayerPrefs.GetInt("Balao") == 0)
        {
            balao2.SetActive(true);
            // PlayerPrefs.SetInt("Balao",1);
        }
    }

    void ResetBalao()
    {
        PlayerPrefs.SetInt("Balao", 0);
    }

    void Dead()
    {
        dead = true;
    }

    public void LookAtDavi()
    {
        transform.LookAt(davi.transform);
        anim.SetTrigger("Provocar");

    }

    void DaviAttack()
    {
        davi.GetComponent<Animator>().SetTrigger("Attack");
        Invoke("Death", 0.5f);
    }

    void Death()
    {
        anim.SetTrigger("Change");
        lanca.SetActive(true);
        Instantiate(effect, transform.position, Quaternion.identity);
        transform.position = new Vector3(transform.position.x-0.6f, transform.position.y,transform.position.z);
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.name == "Stop")
		{
			inPosition = true;
		}
	}

	void Pisao()
	{
        if (target != null)
		    Instantiate(rachadura, target.transform.position, Quaternion.identity);
	}

}
