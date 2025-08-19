 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Davi_Scene2 : MonoBehaviour
{

    Animator anim;
    public float speed;
    public float limiteR, limiteL, limiteF, limiteB;
    public bool right, left, forward, backward, stop;
    public float wait = 0;
    public float time;
    public bool ok, changeHarpaSound;
    public bool encerrou;
    

    public GameObject ovelha, ovelha1, filhoOvelha1, box, finger;
    public Vector3 positionIni, updatePosition;

    public GameObject buttonRock;
    public AudioClip harpa, rock;
    public AudioSource audioPlayer;
    public GameObject[] ovelhas;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        positionIni = GetComponent<Transform>().position;
        if (PlayerPrefs.GetString("RockMusicEnabled").Equals("true"))
        {
            buttonRock.SetActive(true);
        }

    }

    private void OnEnable()
    {
        // left = true;
        
    }


    // Update is called once per frame
    void Update()
    {
        updatePosition = GetComponent<Transform>().position;
        if (stop)
        {
            if (wait < time)
            {
                wait += 0.1f;
            }
            else
            {
                stop = false;
            }

            left = false;
            right = false;
            forward = false;
            backward = false;
        }
        else
        {
            if (!encerrou)
            {
                if (transform.position.x > limiteL && !right)
                {
                    if (!left)
                    {
                        if (!filhoOvelha1.activeSelf)
                            Run();
                        else
                            Walk();
                        left = true;
                    }

                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, -79, transform.eulerAngles.z);
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                }
                else if (transform.position.x <= limiteL)
                {
                    left = false;
                    if (wait == 0)
                    {
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, -169, transform.eulerAngles.z);
                        anim.SetTrigger("Idle");
                        Time.timeScale = 0;
                    }
                    wait += 0.1f;
                }


                if (transform.position.x < limiteR && !left)
                {
                    if (!right)
                    {
                        Walk();
                        right = true;
                    }
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, -259, transform.eulerAngles.z);
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                }
                else if (transform.position.x >= limiteR)
                {
                    right = false;
                    if (wait == 0)
                    {
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, -169, transform.eulerAngles.z);
                        anim.SetTrigger("Idle");
                    }
                    wait += 0.1f;
                }

            }
            else
            {
                if (!ok)
                {
                    anim.SetTrigger("Idle");
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, -230, transform.eulerAngles.z);
                    ok = true;
                }
            }

        }
    }

    void Walk()
    {
        if(box.activeSelf)
        anim.SetTrigger("W");
        else
        {
            anim.SetTrigger("Idle");
        }
    }

    void Run()
    {
        anim.SetTrigger("Run");
    }

    void SumirOvelha()
    {
        ovelha.SetActive(false);
    }

    void Aparecerovelha()
    {

        filhoOvelha1.SetActive(true);
        finger.SetActive(true);
        encerrou = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.name == "Ovelha (3)" && !stop)
        {
            wait = 0;
            anim.SetTrigger("Carinho");
            time = 10;
            left = false;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -169, transform.eulerAngles.z);
            stop = true;
            ovelha.GetComponent<MeshCollider>().enabled = false;
            ovelha1.SetActive(true);
            speed = 0.1f;
        }

        if(other.name == "Ovelha (4)")
        {
            wait = 0;
            anim.SetTrigger("Put");
            time = 5;
            stop = true;
            ovelha1.GetComponent<SphereCollider>().enabled = false;
        }
    }

    public void HarpaRock()
    {
        changeHarpaSound = true;
    }

    public void Harpa()
    {
        changeHarpaSound = false;
    }

    public void TocarHarpa()
    {
        Sound_Manager.Instance.StopMusic();
        Sound_Manager.Instance.GetComponent<AudioSource>().enabled = false;
        Sound_Manager.Instance.GetComponent<AudioSource>().enabled = true;
        if (changeHarpaSound)
        {

            print("ENTROU NO CHANGEHARPASOUND ");
            anim.SetTrigger("Rock");
            foreach (GameObject item in ovelhas)
            {
                item.GetComponent<Animator>().SetTrigger("Rock");
            }
            GastaItem("RockMusic");
        }
        else
        {
            print("ENTROU NO CHANGEHARPASOUND ");
            anim.SetTrigger("Change");
        }


    }

    public void GastaItem(string nome)
    {
        if (PlayerPrefs.GetInt(nome) > 0)
        {
            PlayerPrefs.SetInt(nome, PlayerPrefs.GetInt(nome) - 1);
            PlayerPrefs.SetInt(nome + "Qtd", PlayerPrefs.GetInt(nome));
        }
    }

    public void PararDancaDasOvelhas()
    {
        foreach (GameObject item in ovelhas)
        {
            item.GetComponent<Animator>().SetTrigger("Berro");
            Invoke("PararBerro", 0.05f);
        }
    }

    public void PararBerro()
    {
        foreach (GameObject item in ovelhas)
        {
            item.GetComponent<Animator>().ResetTrigger("Berro");

        }
    }

    public void HarpaRockEnableButton()
    {
        //buttonRock.GetComponent<Button>().interactable = true;
        PlayerPrefs.SetString("RockMusicEnabled", "true");
        if (PlayerPrefs.GetString("RockMusicEnabled").Equals("true"))
        {
            buttonRock.SetActive(true);
        }
    }

    public void PlaySound(string clipName)
    {
        AudioSource []soundPlayer = Sound_Manager.Instance.GetComponents<AudioSource>();

        if (clipName.Equals("HarpaRock") && changeHarpaSound)
        {
            if(PlayerPrefs.GetInt("RockMusic")<=0)
            changeHarpaSound = false;
            soundPlayer[0].Stop();
            //Sound_Manager.Instance.GetComponent<AudioSource>().Stop();
            //Sound_Manager.Instance.GetComponent<AudioSource>().clip = rock;

            soundPlayer[1].Play();
            
        }
        else if (clipName.Equals("Harpa") && !changeHarpaSound)
        {
            soundPlayer[1].Stop();
            soundPlayer[0].Play();
            //Sound_Manager.Instance.GetComponent<AudioSource>().Stop();
            //Sound_Manager.Instance.GetComponent<AudioSource>().clip = harpa;

            //Sound_Manager.Instance.GetComponent<AudioSource>().Play();
        }
    }
}
