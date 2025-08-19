using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Enemy_Lion_AI : MonoBehaviour 
{

	//publics
	public float speed;

	public List<GameObject> path;

	public int atualPath, hitToDie;

	private Rigidbody rb;

	public bool stop = true;

	public AudioClip rugido, morrendo;
	private AudioSource audioSrc;

	public GameObject urso;

	private Biblia3dTrackableEventHandler tracker;

	public GameObject story, cheep, aviso;

	private Animator anim;

    // Use this for initialization
    void Start()
    {
        tracker = GetComponentInParent<Biblia3dTrackableEventHandler>();
        rb = GetComponent<Rigidbody>();
        this.transform.position = path[0].transform.position;
        anim = GetComponent<Animator>();
        audioSrc = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //		if (story.GetComponent<Story_Manager> ().aux=="03") {
        //			stop = false;
        //		}
        if (tracker.isTracking && !stop)
        {

            Move();
            if (Vector3.Distance(transform.position, path[atualPath].transform.position) <= 0.1f)
            {
                transform.position = path[atualPath].transform.position;
                GoToNextTarget(atualPath + 1);
            }
        }
    }

    void GoToNextTarget(int nextPath)
    {
        if (nextPath < path.Count)
        {
            transform.LookAt(path[nextPath].transform.position);
            atualPath++;
        }
        else
        {
            stop = true;
            Invoke("Aviso", 1f);

        }
    }

    void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void ActiveBear()
    {
        urso.SetActive(true);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider colisor)
    {
        if (colisor.tag == "Ovelha")
        {
            cheep.SetActive(true);
            audioSrc.PlayOneShot(rugido);
        }
        if (colisor.tag == "DaviStone")
        {
            hitToDie--;
            if (hitToDie <= 0)
            {
                stop = true;
                anim.SetTrigger("Change");
                gameObject.GetComponent<BoxCollider>().enabled = false;
                audioSrc.PlayOneShot(morrendo);
                PlayerPrefs.SetInt("DeadLeao", 1);
                Invoke("ActiveBear", 4f);
            }
            else
            {
                audioSrc.PlayOneShot(rugido);
                transform.Rotate(0, 180, 0);
                atualPath--;

            }
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 10);
        }

    }

    public void StartLion()
    {
        stop = false;
    }

    void Aviso()
    {
        aviso.SetActive(true);
    }



}
