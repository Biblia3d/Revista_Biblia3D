using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using GameToolkit.Localization;


public class Quiz : MonoBehaviour
{

    private List<string> eachLine;  //Ler o TXT
    public TextAsset txt, txtEn;    //Arquivo das perguntas
    public  Question[] quiz;        //Lista com Todas as Perguntas do Jogo
    public GameObject info, pergunta; //pergunta (text que exibe o enunciado da questão)
    public GameObject[] answer; //exibe as alternativas da pergunta
    [HideInInspector]
    public int atualQuestionNumber;
    public GameObject gameOver, acertou, acertouDesafio, errouDesafio;
    public GameObject PlayerHeath;
    public GameObject[] baus; //lista de baús que serão exibidos na cena
    public int bauAtual = 0; //indice do baú em uso
    public GameObject proximaPagina;
    public List<int> listaPerguntasFeitas = new List<int>(); //lista que recebe as perguntas em ordem aleatória
    public List<string> indices; //utilizado para salvar e recuperar as perguntas ainda não respondidas no playerprefs
    public List<int> possibilidades = new List<int>(); //lista utilizada para sortear as perguntas que serão guardadas na ListaDePerguntasFeitas

    public LocalizedAudioClipBehaviour LocalizedAudioClipBehaviour; //utilizado para colocar a narração nos enunciados das perguntas
    public LocalizedAudioClip[] audiosPerguntas; //lista de audios com as vozes narrando as perguntas

    void OnEnable()
    {
        Debug.Log("Entrou OnEnable()");
        bauAtual++;
        indices = new List<string>(); //inicializando o objeto indices
        listaPerguntasFeitas = new List<int>(); //inicializando o objeto listaPerguntasFeitas


        Debug.Log("Chamando NewQuestion()");
        NewQuestion(); //usado para iniciar a utilização das perguntas

        if (LocalizedAudioClipBehaviour != null) //verifica se existe arquivo de audiolocalizado
        {
            LocalizedAudioClipBehaviour.LocalizedAsset = audiosPerguntas[atualQuestionNumber]; //recebe o audioClip de acordo com o índice da pergunta atual
            if (LocalizedAudioClipBehaviour.GetComponent<AudioSource>() != null) 
                LocalizedAudioClipBehaviour.gameObject.SetActive(true); //ativa o audioSource
            
            if (LocalizedAudioClipBehaviour.GetComponent<AudioSource>() != null )
                LocalizedAudioClipBehaviour.GetComponent<AudioSource>().Play();  //toca o audioClip com a narração da pergunta
        }

    }
    void Update()
    {

    }

    //Le o arquivo TXT e coloca numa string
    public void Read()
    {
        string allTxt = "";
        if (PlayerPrefs.GetString("Language") == "Portuguese") //se o idioma do jogo for Português lê o txt em português
        {
            string allText = txt.text;
            allTxt = allText;
        }
        else if (PlayerPrefs.GetString("Language") == "English") //se o idioma do jogo for Inglês lê o txt em Inglês
        {
            string allText = txtEn.text;
            allTxt = allText;
        }



        eachLine = new List<string>(); //lista que armazena o texto de cada linha da string "allTxt"
        eachLine.AddRange(allTxt.Split("\n"[0])); //Coloca cada linha do allTxt em um elemento da lista
        quiz = new Question[eachLine.Count / 6]; /*lista que recebe cada pergunta com suas respostas e alternativa correta
                                                  * (divide a lista em 6 que é a soma das linhas que contém a pergunta + 4 alternativas + alternativa correta*/
    }

    //Gera todas as perguntas
    public void Generate()
    {
        int atualPos = 0;
        for (int i = 0; i < quiz.Length; i++)
        {
            string questionGen;
            string[] answerGen = new string[4];
            questionGen = eachLine[atualPos]; //armazena a pergunta
            atualPos += 1;
            answerGen[0] = eachLine[atualPos]; //armazena a alternativa a
            atualPos += 1;
            answerGen[1] = eachLine[atualPos]; //armazena a alternativa b
            atualPos += 1;
            answerGen[2] = eachLine[atualPos]; //armazena a alternativa c
            atualPos += 1;
            answerGen[3] = eachLine[atualPos]; //armazena a alternativa d
            atualPos += 1;
            int correctAnswerGen = int.Parse(eachLine[atualPos]); //indica a alternativa correta
            atualPos += 1;
            Debug.Log("Criou");
            quiz[i] = new Question(questionGen, answerGen, correctAnswerGen); //armazena perguntas e respostas do quiz numa lista
        }

    }

    public void GetAnswer() //exibe a pergunta atual e suas alternativas
    {
        //se nao existem perguntas feitas salvas
        if (!PlayerPrefs.HasKey("Perguntas"))
        {
            OrdenarPerguntasAleatorias();
            PreencherIndice();
            SalvarLista();
        }
        //se existem
        else
        {
            PreencherIndice();
        }

        
        int perguntaIndex = UnityEngine.Random.Range(0, listaPerguntasFeitas.Count);//Sorteia as perguntas que ainda não foram respondidas em ordem aleatória

        atualQuestionNumber = listaPerguntasFeitas[perguntaIndex]; // Pega o índice da pergunta atual

        //recebe a questão atual e exibe na tela
        pergunta.GetComponent<Text>().text = quiz[atualQuestionNumber].question;

        //gera as alternativas
        for (int i = 0; i < answer.Length; i++)
        {
            answer[i].GetComponentInChildren<Text>().text = quiz[atualQuestionNumber].answer[i];
        }

    }

    //Checa se a resposta esta correta
    public void CheckAnswer(int answer)
    {
        if (quiz[atualQuestionNumber].correctAnswer == answer)
        {
            //Acerto
            Debug.Log("Acertou");

            if (PlayerPrefs.GetInt("PlayingBonus") == 1)
            {

                PlayerPrefs.SetInt("Life", 7);
                PlayerPrefs.SetInt("Acertou", 1);
               // PlayerHeath.GetComponent<PlayerHealth>().vida = 7;

               // PlayerHeath.GetComponent<PlayerHealth>().bar.fillAmount = 1;
                gameObject.SetActive(false);
                acertouDesafio.SetActive(true);

            }
            else
            {

                if (PlayerPrefs.GetInt("Normal") == 1)
                {
                    PlayerPrefs.SetInt("Life", 7);
                }
                if (PlayerPrefs.GetInt("Facil") == 1)
                {
                    PlayerPrefs.SetInt("Life", 12);
                }

                PlayerPrefs.SetInt("Acertou", 1);
                acertou.SetActive(true);

            }

            if (listaPerguntasFeitas.Count > 1)
            {
                //remove a pergunta respondida da lista
                Debug.Log("Remover pergunta");
                print("*****" + listaPerguntasFeitas[0] + "********");
                listaPerguntasFeitas.Remove(atualQuestionNumber);
                Debug.Log(listaPerguntasFeitas[0].ToString());
                SalvarLista();

            }
            else
            {
                OrdenarPerguntasAleatorias();
                SalvarLista();
            }

        }
        else
        {
            //Erro
            Debug.Log("Errou");
            //PlayerPrefs.SetInt ("Life", 10);
            PlayerPrefs.SetInt("Acertou", 0);
            //PlayerPrefs.SetInt("Checkpoint",0);
            if (PlayerPrefs.GetInt("PlayingBonus") == 0)
            {
                gameOver.SetActive(true);
            }
            else
            {
                //gameObject.SetActive (false);
                errouDesafio.SetActive(true);
            }

        }

        
    }

    public void SalvarLista() //Salva as perguntas no playerprefs
    {
        PlayerPrefs.SetString("Perguntas", ConverterIndiceParaString());
        listaPerguntasFeitas.Clear();
        NewQuestion();
    }

    public void CloseInfo()
    {
        info.SetActive(false);
    }

    public void Acerto()
    {
        PlayerPrefs.SetInt("Questao", PlayerPrefs.GetInt("Questao") + 1);
        if (PlayerPrefs.GetInt("Questao") >= 4)
        {
            PlayerPrefs.SetInt("Questao", 1);
        }
        

        
    }

    public string ConverterIndiceParaString() //converte os índices das perguntas em string para salvar no playerprefs
    {
        string perguntasNaoRespondidas = "";

        if (listaPerguntasFeitas.Count > 0)
        {
            foreach(int item in listaPerguntasFeitas)
            {
                perguntasNaoRespondidas +=  item.ToString() + "/";
            }

        }
    return perguntasNaoRespondidas;
    }

    public void PreencherIndice() //preenche a lista de índices com os índices salvos no playerprefs
    {
        indices = new List<string>();

        indices.AddRange(PlayerPrefs.GetString("Perguntas").Split("/"));

        indices.Remove("");

        foreach (string i in indices)
        {
            int result;

            int.TryParse(i, out result);//converte string em int

            if(result != 0)
            listaPerguntasFeitas.Add(result);
            else if (!listaPerguntasFeitas.Contains(result))
            {
                listaPerguntasFeitas.Add(result);
            }
            

        }
        
    }

    public void NewQuestion()
    {
        //Le o TXT
        Read();
        Debug.Log("Leu Read()");
        //Gera todas as perguntas
        Generate();
        Debug.Log("Chamou Generate()");
        //
        GetAnswer();
        Debug.Log("Chamou GetAnswer()");

    }

    public void FecharBau()
    {
        
        baus[bauAtual-1].GetComponent<Animator>().SetTrigger("Change");
        
        if(bauAtual<baus.Length)
            baus[bauAtual].SetActive(true);
        else
        {
            proximaPagina.SetActive(true);
            Sound_Manager.Instance.PlayOneShot("Victory");
        }
    }
        
    public void OrdenarPerguntasAleatorias() //gera a lista de possibilidades de perguntas de 0 a n 
    {                                       //e salva em ordem aleatória na lista de perguntas

        List<int> numeroAleatorio = new List<int>();
        System.Random random = new System.Random();
        possibilidades = Enumerable.Range(0, quiz.Length).ToList();
        foreach (var item in possibilidades)
        {
            print("POSSIBILIDADESSSSSSS" + item);
        }
        
        listaPerguntasFeitas = possibilidades.OrderBy(number => random.Next()).Take(quiz.Length).ToList();
    }





}

