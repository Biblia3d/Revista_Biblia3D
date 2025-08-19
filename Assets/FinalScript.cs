using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScript : MonoBehaviour
{
    public GameObject info; // Parte de informações onde mostra os pontos
    public Text scoreTXT; // Mostra o Score
    public AudioSource audio; // Para tocar os sons
    public AudioClip contSound, inicioSound; // Som do contador
    public int score, cont, moedas; // Guarda a pontuação e auxilia no contador
    public Button voltar;
    public bool pronto;

    // Privates
    private bool cutSound;

    void Start()
    {
        cutSound = true;
        cont = 0;

        // Carrega o score atual
        score = PlayerPrefs.GetInt("Score");

        // Atualiza a pontuação inicial com base nas cenas ativas
        Pontuar();
    }

    void FixedUpdate()
    {
        // Incrementa o contador até atingir a pontuação
        if (score != 0 && cont < score)
        {
            if (cutSound)
            {
                audio.PlayOneShot(contSound);
                cutSound = false;
            }
            else
            {
                cutSound = true;
            }

            cont += Mathf.Max(1, score / 50); // Incrementa no mínimo em 1
            cont = Mathf.Min(cont, score); // Garante que o contador não ultrapasse o score
            scoreTXT.text = "Score $" + cont;

            if (cont == score)
                pronto = true;
        }
    }

    public void Open()
    {
        // Ativa a tela de contagem de Pontos
        audio.PlayOneShot(inicioSound);
        info.SetActive(true);
        scoreTXT.gameObject.SetActive(true);

        // Certifica que o score é carregado corretamente
        score = PlayerPrefs.GetInt("Score", 0);
        Debug.Log("Pontuação atual: " + score);
    }

    public void Jump()
    {
        cont = Mathf.Max(score - 2, 0); // Evita que cont seja negativo
    }

    public void Zerar()
    {
        score = 0;
        cont = 0;
        pronto = false;

        // Reseta os valores salvos
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Moedas", 0);
    }

    public void Pontuar()
    {
        // Obtém todas as cenas ativas
        int activeSceneCount = SceneManager.sceneCount;
        int pontosParaAdicionar = 0;

        for (int i = 0; i < activeSceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            if (scene.isLoaded)
            {
                // Identifica qual cena está ativa e aplica as regras de pontuação
                switch (scene.name)
                {
                    case "Capa":
                        pontosParaAdicionar += PlayerPrefs.GetInt("DragTheStonesToGoliathToStumble", 0) == 0 ? 50 : 30;
                        break;
                    case "Scene 2":
                        pontosParaAdicionar += PlayerPrefs.GetInt("CompleteScene2", 0) == 0 ? 80 : 30;
                        break;
                    case "Scene 3":
                        pontosParaAdicionar += PlayerPrefs.GetInt("CompleteScene3", 0) == 0 ? 110 : 30;
                        break;
                    case "Scene 4":
                        pontosParaAdicionar += PlayerPrefs.GetInt("CompleteScene4", 0) == 0 ? 140 : 30;
                        break;
                    case "Scene 5":
                        pontosParaAdicionar += PlayerPrefs.GetInt("CompleteScene5", 0) == 0 ? 170 : 30;
                        break;
                    case "Scene 6":
                        pontosParaAdicionar += PlayerPrefs.GetInt("CompleteScene6", 0) == 0 ? 200 : 30;
                        break;
                    case "Scene 7":
                        pontosParaAdicionar += 30;
                        break;
                    case "Scene 9":
                        pontosParaAdicionar += 30;
                        break;
                    case "Scene 10":
                        pontosParaAdicionar += 30;
                        break;
                    case "Scene 11":
                        pontosParaAdicionar += 30;
                        break;
                }
            }
        }

        // Atualiza a pontuação total e as moedas
        score = PlayerPrefs.GetInt("Score", 0) + pontosParaAdicionar;
        PlayerPrefs.SetInt("Score", score);

        moedas = PlayerPrefs.GetInt("Moedas", 0) + pontosParaAdicionar;
        PlayerPrefs.SetInt("Moedas", moedas);

        Debug.Log($"Pontos adicionados: {pontosParaAdicionar}, Pontuação total: {score}, Moedas total: {moedas}");
    }
}