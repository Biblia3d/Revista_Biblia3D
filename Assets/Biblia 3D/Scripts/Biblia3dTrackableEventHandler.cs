using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

[Obsolete("Criei um tracking especifico para cada scene e botao, assim este tracking estara sendo sendo removido aos poucos para que utilize a nova versao")]
public class Biblia3dTrackableEventHandler : DefaultTrackableEventHandler
{
    public bool isTracking;
    public bool showTip = false, enable; //Se "enable" for igual a true o GameObject "objetos" nao desativa ao perder o target.
    public AudioSource music;
    public GameObject button, objetos, objetos1, checklist, story, restartBtn;
    public AudioSource fundaSound;
    private GameObject gameManager;
    private Animator anim;
    private Scene scene;
    public string nomeCena;
    public bool wasEnabled; // se o track já foi iniciado uma vez
    public GameObject msg;

    //Minhas adicoes
    private float waitForSeconds = 2;
    private bool found = false;

    protected override void Start()
    {
        base.Start();
        scene = SceneManager.GetActiveScene();
        gameManager = GameObject.FindWithTag("GameManager");
        if (music == null)
            music = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (objetos != null)
        {
            if (!objetos.activeSelf)
            {
                if (msg != null)
                {
                    msg.SetActive(false);
                }
            }
        }
    }

    protected override void OnTrackingFound()
    {
        Story_Manager.Instance.atualTrack = this.gameObject.name;
        //PlayerPrefs.SetInt ("Foco",1);
        Foco.Instance.gameObject.SetActive(false);
        //nomeCena = story.GetComponent<Story_Manager>().atualTrack;
        if (fundaSound != null)
            fundaSound.mute = false;
        switch (scene.name)
        {
            case "Scene 0":
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "Capa":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Capa");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "02":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 2");
                        break;
                    case "03":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 3");
                        break;
                    case "06":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 4");
                        break;
                    case "08":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 5");
                        break;
                    case "10":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 6");
                        break;
                    case "12":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 7");
                        break;
                    case "DaviNovo":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "GoliasNovo":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Card Jesus");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "2":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "3":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "4":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "5":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "14":
                        objetos.SetActive(true);
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 9");
                        break;
                    case "16":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 10");
                        break;
                    case "18":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 11");
                        break;
                    case "20":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 12");
                        break;
                    case "22":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 13");
                        break;
                    case "VersoCarta1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;

                }
                break;
            case "Scene 0 Cards":
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {

                    case "DaviNovo":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "GoliasNovo":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Card Jesus");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                }
                break;
            case "Capa":
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "02":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 2");
                        break;
                    case "03":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 3");
                        break;
                    case "06":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 4");
                        break;
                    case "08":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 5");
                        break;
                    case "10":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 6");
                        break;
                    case "12":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 7");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "VersoCarta":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJogo");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJesus");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "2":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "3":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "4":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "5":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "VersoCarta1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "14":
                        objetos.SetActive(true);
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 9");
                        break;
                    case "16":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 10");
                        break;
                    case "18":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 11");
                        break;
                    case "20":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 12");
                        break;
                    case "22":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 13");
                        break;

                }
                break;

            case "Scene 2":
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "Capa":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Capa");
                        break;
                    case "04":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 3");
                        break;
                    case "06":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 4");
                        break;
                    case "08":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 5");
                        break;
                    case "10":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 6");
                        break;
                    case "12":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 7");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "VersoCarta":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJogo");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJesus");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "2":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "3":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "4":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "5":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "VersoCarta1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "14":
                        objetos.SetActive(true);
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 9");
                        break;
                    case "16":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 10");
                        break;
                    case "18":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 11");
                        break;
                    case "20":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 12");
                        break;
                    case "22":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 13");
                        break;

                }
                break;
            case "Scene 3":
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "Capa":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Capa");
                        break;
                    case "02":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 2");
                        break;
                    case "06":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 4");
                        break;
                    case "08":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 5");
                        break;
                    case "10":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 6");
                        break;
                    case "12":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 7");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "VersoCarta":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJogo");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJesus");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "2":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "3":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "4":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "5":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "VersoCarta1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "14":
                        objetos.SetActive(true);
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 9");
                        break;
                    case "16":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 10");
                        break;
                    case "18":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 11");
                        break;
                    case "20":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 12");
                        break;
                    case "22":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 13");
                        break;

                }
                break;
            case "Scene 4":
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "Capa":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Capa");
                        break;
                    case "02":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 2");
                        break;
                    case "03":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 3");
                        break;
                    case "08":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 5");
                        break;
                    case "10":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 6");
                        break;
                    case "12":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 7");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "VersoCarta":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJogo");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJesus");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "2":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "3":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "4":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "5":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "VersoCarta1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "14":
                        objetos.SetActive(true);
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 9");
                        break;
                    case "16":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 10");
                        break;
                    case "18":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 11");
                        break;
                    case "20":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 12");
                        break;
                    case "22":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 13");
                        break;

                }
                break;
            case "Scene 5":
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "Capa":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Capa");
                        break;
                    case "02":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 2");
                        break;
                    case "03":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 3");
                        break;
                    case "06":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 4");
                        break;
                    case "10":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 6");
                        break;
                    case "12":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 7");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "VersoCarta":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJogo");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJesus");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "2":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "3":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "4":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "5":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "VersoCarta1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "14":
                        objetos.SetActive(true);
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 9");
                        break;
                    case "16":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 10");
                        break;
                    case "18":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 11");
                        break;
                    case "20":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 12");
                        break;
                    case "22":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 13");
                        break;
                }
                break;
            case "Scene 6":
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "Capa":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Capa");
                        break;
                    case "02":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 2");
                        break;
                    case "03":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 3");
                        break;
                    case "06":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 4");
                        break;
                    case "08":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 5");
                        break;
                    case "12":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 7");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "VersoCarta":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJogo");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJesus");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "2":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "3":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "4":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "5":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "VersoCarta1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "14":
                        objetos.SetActive(true);
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 9");
                        break;
                    case "16":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 10");
                        break;
                    case "18":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 11");
                        break;
                    case "20":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 12");
                        break;
                    case "22":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 13");
                        break;
                }
                break;
            case "Scene 7":
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "Capa":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Capa");
                        break;
                    case "02":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 2");
                        break;
                    case "03":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 3");
                        break;
                    case "06":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 4");
                        break;
                    case "08":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 5");
                        break;
                    case "10":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 6");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "VersoCarta":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJogo");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJesus");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "2":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "3":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "4":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "5":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "VersoCarta1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "14":
                        objetos.SetActive(true);
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 9");
                        break;
                    case "16":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 10");
                        break;
                    case "18":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 11");
                        break;
                    case "20":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 12");
                        break;
                    case "22":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 13");
                        break;
                }
                break;

            case "Scene 8":
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "Capa":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Capa");
                        break;
                    case "02":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 2");
                        break;
                    case "03":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 3");
                        break;
                    case "06":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 4");
                        break;
                    case "08":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 5");
                        break;
                    case "10":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 6");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "VersoCarta":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJogo");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJesus");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "2":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "3":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "4":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "5":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "VersoCarta1":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Cards");
                        break;
                    case "14":
                        objetos.SetActive(true);
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 9");
                        break;
                    case "16":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 10");
                        break;
                    case "18":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 11");
                        break;
                    case "20":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 12");
                        break;
                    case "22":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 13");
                        break;
                }
                break;

            case "Card Jesus":
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "Capa":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Capa");
                        break;
                    case "02":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 2");
                        break;
                    case "03":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 3");
                        break;
                    case "06":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 4");
                        break;
                    case "08":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 5");
                        break;
                    case "10":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 6");
                        break;
                    case "12":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 7");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "DaviNovo":
                        gameManager.GetComponent<Game_Manager>().ChangeSceneWithOutLoad("CardDG");
                        break;
                    case "GoliasNovo":
                        gameManager.GetComponent<Game_Manager>().ChangeSceneWithOutLoad("CardDG");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeSceneWithOutLoad("CardDG");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeSceneWithOutLoad("CardDG");
                        break;
                    case "VersoCarta":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJogo");
                        break;
                    case "14":
                        objetos.SetActive(true);
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 9");
                        break;
                    case "16":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 10");
                        break;
                    case "18":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 11");
                        break;
                    case "20":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 12");
                        break;
                    case "22":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 13");
                        break;
                }
                break;
            case "CardDG":
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "Capa":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Capa");
                        break;
                    case "02":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 2");
                        break;
                    case "03":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 3");
                        break;
                    case "06":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 4");
                        break;
                    case "08":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 5");
                        break;
                    case "10":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 6");
                        break;
                    case "12":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 7");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeSceneWithOutLoad("Card Jesus");
                        break;
                    case "VersoCarta":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJogo");
                        break;
                    case "14":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 9");
                        break;
                    case "16":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 10");
                        break;
                    case "18":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 11");
                        break;
                    case "20":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 12");
                        break;
                    case "22":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 13");
                        break;
                }
                break;

            case "Scene 9":
                Sound_Manager.Instance.PlayMusic();
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "Capa":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Capa");
                        break;
                    case "02":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 2");
                        break;
                    case "03":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 3");
                        break;
                    case "06":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 4");
                        break;
                    case "08":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 5");
                        break;
                    case "10":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 6");
                        break;
                    case "12":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 7");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJesus");
                        break;
                    case "16":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 10");
                        break;
                    case "18":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 11");
                        break;
                    case "20":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 12");
                        break;
                    case "22":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 13");
                        break;
                }
                break;
            case "Scene 10":
                Sound_Manager.Instance.PlayMusic();
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "Capa":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Capa");
                        break;
                    case "02":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 2");
                        break;
                    case "03":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 3");
                        break;
                    case "06":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 4");
                        break;
                    case "08":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 5");
                        break;
                    case "10":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 6");
                        break;
                    case "12":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 7");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJesus");
                        break;
                    case "14":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 9");
                        break;
                    case "18":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 11");
                        break;
                    case "20":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 12");
                        break;
                    case "22":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 13");
                        break;
                }
                break;
            case "Scene 11":
                Sound_Manager.Instance.PlayMusic();
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "Capa":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Capa");
                        break;
                    case "02":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 2");
                        break;
                    case "03":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 3");
                        break;
                    case "06":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 4");
                        break;
                    case "08":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 5");
                        break;
                    case "10":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 6");
                        break;
                    case "12":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 7");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJesus");
                        break;
                    case "14":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 9");
                        break;
                    case "16":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 10");
                        break;
                    case "20":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 12");
                        break;
                    case "22":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 13");
                        break;
                }
                break;
            case "Scene 12":
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "Capa":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Capa");
                        break;
                    case "02":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 2");
                        break;
                    case "03":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 3");
                        break;
                    case "06":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 4");
                        break;
                    case "08":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 5");
                        break;
                    case "10":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 6");
                        break;
                    case "12":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 7");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJesus");
                        break;
                    case "14":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 9");
                        break;
                    case "16":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 10");
                        break;
                    case "18":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 11");
                        break;
                    case "22":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 8");
                        break;
                }
                break;
            case "Scene 13":
                switch (story.GetComponent<Story_Manager>().atualTrack)
                {
                    case "Capa":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Capa");
                        break;
                    case "02":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 2");
                        break;
                    case "03":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 3");
                        break;
                    case "06":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 4");
                        break;
                    case "08":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 5");
                        break;
                    case "10":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 6");
                        break;
                    case "12":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 7");
                        break;
                    case "Verso":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Verso");
                        break;
                    case "Davi":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Golias":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardDG");
                        break;
                    case "Jesus":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("CardJesus");
                        break;
                    case "14":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 9");
                        break;
                    case "16":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 10");
                        break;
                    case "18":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 11");
                        break;
                    case "20":
                        gameManager.GetComponent<Game_Manager>().ChangeScene("Scene 12");
                        break;
                }
                break;
        }

        isTracking = true;
        wasEnabled = true;
        if (objetos != null)
        {
            objetos.SetActive(true);
            if (checklist != null && scene.name != "Scene 1" &&/* scene.name != "Scene 3" &&*/ scene.name != "Scene 6" /*&& scene.name != "Scene 7"*/)
            {
                checklist.SetActive(true);
            }
            //Invoke ("DisableChecklist", 5);
        }
        if (objetos1 != null)
        {
            objetos1.SetActive(true);
        }
        if (fundaSound != null)
        {
            fundaSound.enabled = true;
        }
        if (music != null)
        {
            music.UnPause();
        }
        if (button != null)
        {
            button.GetComponent<Button>().interactable = true;
        }
        if (showTip)
        {
            if (Tip_Manager.Instance != null)
            {
                Tip_Manager.Instance.ShowTip(gameObject.name);
                showTip = false;
            }
        }

        found = true;

        base.OnTrackingFound();
    }

    protected override void OnTrackingLost()
    {
        if (Foco.Instance != null)
            Foco.Instance.gameObject.SetActive(true);
        Story_Manager.Instance.atualTrack = "Nenhum";
        Sound_Manager.Instance.StopMusic();
        if (fundaSound != null)
            fundaSound.mute = true;
        isTracking = false;
        if (objetos != null && !enable)
        {
            objetos.SetActive(false);
        }
        if (objetos1 != null)
        {
            objetos1.SetActive(false);
        }
        if (fundaSound != null)
        {
            fundaSound.enabled = false;
        }

        base.OnTrackingLost();

        if (checklist != null)
            checklist.SetActive(false);

        if (restartBtn != null && wasEnabled)
        {
            restartBtn.SetActive(true);
        }

        found = false;

        if (this != null && this.gameManager != null && this.gameManager.activeInHierarchy)
            StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(waitForSeconds);

        if (!found)
        {
            {
                string currentSceneName = SceneManager.GetActiveScene().name;

                // Verifica se a cena atual é uma das cenas especiais
                if (currentSceneName.Contains("Card") || currentSceneName.Contains("Caneca"))
                {
                    // Recarrega a cena atual
                    SceneManager.LoadScene(currentSceneName);
                }
                else
                {
                    // Comportamento padrão para as outras cenas
                    Biblia3D.Scene.Revista.RevistaSceneComponent.LoadScene(new Biblia3D.Scene.Revista.RevistaSceneRequest(), (outcome) => { });
                }
            }
        }
        
    }

    void DisableChecklist()
    {
        if (checklist != null)
            checklist.GetComponent<Animator>().SetTrigger("Change");
    }
}
