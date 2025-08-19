using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Davi_InGame : MonoBehaviour
{

    public static Davi_InGame Instance;

    //publics
    public float speed;
    public GameObject target, aim, golias, aviso;
    public Image hudLife;
    public GameObject stone;
    public float maxLeft;
    public float maxRight;
    public float cooldown;
    private float fireRate;
    private Animator anim;
    public AudioClip[] grito;
    public AudioClip shot;
    public GameObject telaLoading;
    public GameObject dano;
    public GameObject armadura;
    public bool happy = false, rodou = false, inPosition = false, stop;
    public AudioSource fundaLoopAudioSource;
    public bool dead;

    //privates


    // Use this for initialization
    void Awake()
    {
        Instance = this;
        anim = GetComponent<Animator>();

        if (SceneManager.GetActiveScene().name == "CardDG")
        {
            anim.SetTrigger("Walk");
            //if(!golias1.activeSelf)
            //	targetGolias1.SetActive(false);
            //if(!golias2.activeSelf)
            //	targetGolias2.SetActive(false);

        }

        fireRate = Time.time;

        if (hudLife != null)
            hudLife.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (telaLoading != null)
        {
            if (telaLoading.activeSelf)
            {
                GetComponent<AudioSource>().mute = true;
            }
        }
        if (SceneManager.GetActiveScene().name == "CardDG")
        {
            if (!inPosition)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f * Time.deltaTime);
            }
            else
            {
                if (!stop)
                {
                    anim.SetTrigger("Idle");
                    stop = true;
                }

            }
        }
        if (Input.GetKey("w"))
        {
            //anim.SetTrigger("Atira");
        }
        if (hudLife != null && hudLife.fillAmount <= 0.2f)
        {
            if (fundaLoopAudioSource != null) fundaLoopAudioSource.Stop();
            aviso.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
            anim.SetTrigger("Dead");
            GetComponent<Davi_InGame>().enabled = false;
            dead = true;
            golias.GetComponent<Enemy_Golias_AI>().start = false;
        }

        if (golias != null)
            if (!golias.activeSelf && !happy)
            {
                if (!rodou)
                {
                    transform.Rotate(0, 180, 0);
                    rodou = true;
                }
                GetComponent<AudioSource>().Stop();
                anim.SetTrigger("Happy");
            }
    }

    public void Move(float side)
    {
        if (!dead)
        {
            if (transform.localPosition.x <= maxRight && transform.localPosition.x >= maxLeft)
            {
                transform.localPosition = new Vector3(transform.localPosition.x + (side * Time.deltaTime * speed * Time.deltaTime),
                    transform.localPosition.y,
                    transform.localPosition.z);
            }
            if (transform.localPosition.x > maxRight)
            {
                transform.localPosition = new Vector3(maxRight, transform.localPosition.y, transform.localPosition.z);
            }
            if (transform.localPosition.x < maxLeft)
            {
                transform.localPosition = new Vector3(maxLeft, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }

    public void Atira()
    {
        if (fireRate < Time.time && !dead)
        {
            fireRate = Time.time + cooldown;
            anim.SetLayerWeight(1, 1);
            anim.SetTrigger("Atira");
            print("entrou no atira");
        }
    }
    public void Shoot()
    {

        GameObject aux = (GameObject)Instantiate(stone, target.transform.localPosition, Quaternion.identity);
        aux.transform.SetParent(target.transform.parent);

        GetComponent<AudioSource>().PlayOneShot(shot);
        GetComponent<AudioSource>().volume = 0.2f;
        if (golias != null)
        {
            if (aim.transform.localPosition.x <= golias.transform.localPosition.x + 0.4f && aim.transform.localPosition.x >= golias.transform.localPosition.x - 0.4f && !golias.GetComponent<Enemy_Golias_AI>().dead)
                golias.GetComponent<Enemy_Golias_AI>().Defend();
        }

    }

    void OnTriggerEnter(Collider colisor)
    {
        if (colisor.tag == "Spear")
        {

            GetComponent<AudioSource>().PlayOneShot(grito[UnityEngine.Random.Range(0, 3)]);
            //Handheld.Vibrate();
            
            dano.SetActive(true);
            hudLife.fillAmount -= 1 / 5f;
            if(hudLife.fillAmount>= 0.2f)
            anim.SetTrigger("Hit");
        }

        if (colisor.tag == "Rachadura")
        {
            GetComponent<AudioSource>().PlayOneShot(grito[UnityEngine.Random.Range(0, 3)]);

            
            hudLife.fillAmount -= 1 / 5f;
            if (hudLife.fillAmount >= 0.2f)
                anim.SetTrigger("Hit");
            dano.SetActive(true);
        }

        if (colisor.name == "Stop")
        {
            inPosition = true;
        }


    }

    void Stop()
    {
        GetComponent<BoxCollider>().enabled = false;
        if (fundaLoopAudioSource != null) fundaLoopAudioSource.Stop();
    }

    void StopBool()
    {
        anim.SetBool("L1", false);
        anim.SetBool("R1", false);
    }

    void changeLayer()
    {
        anim.SetLayerWeight(1, 0);
    }

    void PlaySound(string name)
    {
        Sound_Manager.Instance.PlayOneShot(name);
    }

    void PlayFunda()
    {
        if (!GetComponent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().Play();
    }

    void StopFunda()
    {
        GetComponent<AudioSource>().Stop();
    }

    private void OnMouseDrag()
    {
        /*if (gameObject.scene.name == "Scene 5")
        {
            if (armadura != null)
            {
                armadura.SetActive(false);
                anim.SetTrigger("Fight");
            }
        }
		Debug.Log("MANTENDO");*/
    }

    public bool GetDead()
    {
        return dead;
    }




}
