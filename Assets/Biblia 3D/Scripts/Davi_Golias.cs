using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class Davi_Golias : MonoBehaviour
{
    public static Davi_Golias instance;
    public GameObject goliasTrack, daviTrack, golias, davi, lookFDavi, lookFGolias, funda, musicDavi, reiniciar;
    public GameObject aproxDavi, aproxGolias, distanceDavi, distanceGolias, msg, btnAnimation, btnAnimationGolias;
    public Text txt;
    public float distance, distancia;
    public int d1;
    public RuntimeAnimatorController controller, controller1, controllerDavi, controllerDavi1;
    public bool ok, disable, playing, ready;
    public Vector3 posIniDavi, posIniGolias;
    public GameObject disableTrack1, disableTrack2, disableTrack3;
    public GameObject effect, msgAddGolias, msgAddDavi, msgFinal;
    public GameObject track1, track2; //Usados para desativar os tracks quando davi vence Golias
    public GameObject track3; //usado para evitar 2 personagens iguais na mesma cena
    // Use this for initialization
    void Start()
    {
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        msg.SetActive(false);

        if (msgAddDavi.activeSelf || msgAddGolias.activeSelf || msgFinal.activeSelf)
        {
            msg.SetActive(false);
        }
        if (goliasTrack.GetComponent<Biblia3dTrackableEventHandler>().isTracking && daviTrack.GetComponent<Biblia3dTrackableEventHandler>().isTracking)//Dois personagens ativos
        {

            btnAnimation.SetActive(false);
            btnAnimationGolias.SetActive(false);

            disableTrack1.SetActive(false);
            disableTrack2.SetActive(false);
            disableTrack3.SetActive(false);
            musicDavi.GetComponent<AudioSource>().enabled = false;
            if (!ok)
            {

                if (davi.GetComponent<Davi_InGame>().inPosition && golias.GetComponent<Golias_Controller>().inPosition)
                {
                    Invoke("Confrontar", 2);
                    ok = true;
                }


            }

            d1 = (int)(distance = Vector3.Distance(goliasTrack.transform.position, daviTrack.transform.position));

            if (distancia == d1)
            {

                if (distance > 1 /*&& distance < 3f*/)
                {
                    aproxDavi.SetActive(false);
                    aproxGolias.SetActive(false);
                    distanceDavi.SetActive(false);
                    distanceGolias.SetActive(false);
                    msg.SetActive(false);
                    playing = false;
                    if (!disable && ready)
                        funda.SetActive(true);
                }
                if (distance < 1)
                {
                    //distanceDavi.SetActive(true);
                    //distanceGolias.SetActive(true);
                    aproxDavi.SetActive(false);
                    aproxGolias.SetActive(false);
                    funda.SetActive(false);
                    if (!msgFinal.activeSelf && !msgAddDavi.activeSelf && !msgAddGolias.activeSelf)
                    {
                        msg.SetActive(true);
                    }
                    else
                    {
                        msg.SetActive(false);
                    }
                    if (PlayerPrefs.GetString("Language") == "Portuguese")
                    {
                        if (!playing)
                        {
                            Sound_Manager.Instance.GetComponent<AudioSource>().Stop();
                            Sound_Manager.Instance.PlayOneShot("Afaste");
                            playing = true;
                        }
                        txt.text = "Afaste os personagens...";
                    }
                    else if (PlayerPrefs.GetString("Language") == "English")
                    {
                        if (!playing)
                        {
                            Sound_Manager.Instance.GetComponent<AudioSource>().Stop();
                            Sound_Manager.Instance.PlayOneShot("Distance");
                            playing = true;
                        }
                        txt.text = "Distance the characters...";
                    }
                }
                if (distance > 2.5)
                {
                    aproxDavi.SetActive(true);
                    aproxGolias.SetActive(true);
                    distanceDavi.SetActive(false);
                    distanceGolias.SetActive(false);
                    funda.SetActive(false);
                    if (PlayerPrefs.GetString("Language") == "Portuguese")
                    {
                        if (!playing)
                        {
                            Sound_Manager.Instance.GetComponent<AudioSource>().Stop();
                            Sound_Manager.Instance.PlayOneShot("Aproxime");
                            playing = true;
                        }
                        txt.text = "Aproxime os personagens...";
                    }
                    else if (PlayerPrefs.GetString("Language") == "English")
                    {
                        if (!playing)
                        {
                            Sound_Manager.Instance.GetComponent<AudioSource>().Stop();
                            Sound_Manager.Instance.PlayOneShot("Approach");
                            playing = true;
                        }
                        txt.text = "Approach the characters ...";
                    }
                }

            }
            else
            {
                if (distance < 2)//Aqui é onde está acontecendo o afastar Personagens
                {
                    distanceDavi.SetActive(true);
                    distanceGolias.SetActive(true);
                    aproxDavi.SetActive(false);
                    aproxGolias.SetActive(false);
                    funda.SetActive(false);
                    if (!msgFinal.activeSelf && !msgAddDavi.activeSelf && !msgAddGolias.activeSelf)
                    {
                        msg.SetActive(true);
                    }
                    else
                    {
                        msg.SetActive(false);
                    }
                    if (PlayerPrefs.GetString("Language") == "Portuguese")
                    {
                        if (!playing)
                        {
                            Sound_Manager.Instance.GetComponent<AudioSource>().Stop();
                            Sound_Manager.Instance.PlayOneShot("Afaste");
                            playing = true;
                        }
                        txt.text = "Afaste os personagens...";
                    }
                    else if (PlayerPrefs.GetString("Language") == "English")
                    {
                        if (!playing)
                        {
                            Sound_Manager.Instance.GetComponent<AudioSource>().Stop();
                            Sound_Manager.Instance.PlayOneShot("Distance");
                            playing = true;
                        }
                        txt.text = "Distance the characters...";
                    }
                }
                if (distance > 2)//Aqui é onde está acontecendo o aproximar personagem
                {
                    aproxDavi.SetActive(true);
                    aproxGolias.SetActive(true);
                    distanceDavi.SetActive(false);
                    distanceGolias.SetActive(false);
                    funda.SetActive(false);
                    if (!msgFinal.activeSelf && !msgAddDavi.activeSelf && !msgAddGolias.activeSelf)
                    {
                        msg.SetActive(true);
                    }
                    else
                    {
                        msg.SetActive(false);
                    }
                    if (PlayerPrefs.GetString("Language") == "Portuguese")
                    {
                        if (!playing)
                        {
                            Sound_Manager.Instance.GetComponent<AudioSource>().Stop();
                            Sound_Manager.Instance.PlayOneShot("Aproxime");
                            playing = true;
                        }
                        txt.text = "Aproxime os personagens...";
                    }
                    else if (PlayerPrefs.GetString("Language") == "English")
                    {
                        if (!playing)
                        {
                            Sound_Manager.Instance.GetComponent<AudioSource>().Stop();
                            Sound_Manager.Instance.PlayOneShot("Approach");
                            playing = true;
                        }
                        txt.text = "Approach the characters ...";
                    }
                }

            }


        }/*
            else if (distance != d1)
            {

            }
            else
            {
                funda.SetActive(false);
                
                aproxDavi.SetActive(false);
                aproxGolias.SetActive(false);
                
                msg.SetActive(true);
                

                if (distance < 2.5f)
                {
                    distanceDavi.SetActive(true);
                    distanceGolias.SetActive(true);
                    txt.text = "Afaste os personagens...";
                }
            }*/

        else //Apenas um personagem ativo
        {
            msg.SetActive(false);
            aproxDavi.SetActive(false);
            aproxGolias.SetActive(false);
            distanceDavi.SetActive(false);
            distanceGolias.SetActive(false);

            //msg.SetActive(false);
            //reiniciar.SetActive(false);


            // davi.SetActive(true);
            davi.GetComponent<Animator>().runtimeAnimatorController = controllerDavi;
            davi.transform.LookAt(lookFDavi.transform);

            golias.GetComponent<Animator>().runtimeAnimatorController = controller;
            golias.transform.LookAt(lookFGolias.transform);
            funda.SetActive(false);
            if (daviTrack.GetComponent<Biblia3dTrackableEventHandler>().isTracking)
            {
                musicDavi.GetComponent<AudioSource>().enabled = true;
                if (PlayerPrefs.GetInt("AddCard") == 0)
                {
                    if (!msgAddDavi.activeSelf)
                        msgAddGolias.SetActive(true);
                    PlayerPrefs.SetInt("AddCard", 1);
                }
                msg.SetActive(false);

                if (davi.GetComponent<Davi_InGame>().inPosition)
                    btnAnimation.SetActive(true);
            }
            if (!musicDavi.GetComponent<AudioSource>().isPlaying && daviTrack.GetComponent<Biblia3dTrackableEventHandler>().isTracking)
            {
                musicDavi.GetComponent<AudioSource>().Play();
            }

            if (goliasTrack.GetComponent<Biblia3dTrackableEventHandler>().isTracking)
            {
                if (golias.GetComponent<Golias_Controller>().inPosition)
                    btnAnimationGolias.SetActive(true);

                if (PlayerPrefs.GetInt("AddCard") == 0)
                {
                    if (!msgAddGolias.activeSelf)
                        msgAddDavi.SetActive(true);
                    PlayerPrefs.SetInt("AddCard", 1);
                }
            }
            ok = false;
            disable = false;
            disableTrack1.SetActive(true);
            disableTrack2.SetActive(true);
        }

        if (daviTrack.GetComponent<Biblia3dTrackableEventHandler>().isTracking)
        {
            track3.SetActive(false);
            track3.GetComponent<ImageTargetBehaviour>().enabled = false;
        }
        else
        {
            track3.SetActive(true);
            track3.GetComponent<ImageTargetBehaviour>().enabled = true;
        }

        if (goliasTrack.GetComponent<Biblia3dTrackableEventHandler>().isTracking)
        {
            track2.SetActive(false);
            track2.GetComponent<ImageTargetBehaviour>().enabled = false;
        }
        else
        {
            track2.SetActive(true);
            track2.GetComponent<ImageTargetBehaviour>().enabled = true;
        }



    }

    public void DieGolias()
    {
        disable = true;
        funda.SetActive(false);
        reiniciar.SetActive(true);
        golias.GetComponent<Animator>().runtimeAnimatorController = controller;
        Effect();
        golias.GetComponent<Animator>().SetTrigger("Die");
        Invoke("DaviHappy", 2);
    }
    public void DaviAttack()
    {
        davi.transform.LookAt(golias.transform.position);
        golias.GetComponent<Animator>().SetTrigger("Reset");
        davi.GetComponent<Animator>().SetTrigger("Attack");
        Invoke("DieGolias", 0.5f);
    }

    void DaviHappy()
    {
        davi.transform.LookAt(lookFDavi.transform);
        davi.GetComponent<Animator>().SetTrigger("Change");
        Invoke("DisableGolias", 3);
    }

    public void LookAt()
    {
        golias.SetActive(false);
        golias.SetActive(true);
        golias.transform.LookAt(davi.transform.position);
        davi.transform.LookAt(golias.transform.position);
    }

    void Effect()
    {
        Instantiate(effect, golias.transform.position, Quaternion.identity);
    }

    void Confrontar()
    {
        davi.transform.LookAt(golias.transform);
        davi.GetComponent<Animator>().runtimeAnimatorController = controllerDavi1;
        golias.GetComponent<Animator>().runtimeAnimatorController = controller1;
        golias.transform.LookAt(davi.transform);
        ready = true;
        // funda.SetActive(true);
    }

    void DisableGolias()
    {
        //golias.SetActive(false);
        //Time.timeScale = 0;
        //goliasTrack.SetActive(false);
        track1.GetComponent<ImageTargetBehaviour>().enabled = false;
        track2.GetComponent<ImageTargetBehaviour>().enabled = false;
        //GetComponent<Davi_Golias>().enabled = false;
    }

}
