using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
//using Vuforia;

public class Enemy_Golias_AI : MonoBehaviour
{

    public float speed;

    public GameObject msg, spear, target, target1, rachadura;
    public Image bar;
    public bool walkRight = false, attack, defend, dead = false, start;

    public float xLimitsMax = 0.25f;
    public float xLimitsMin = 0.25f;

    public float zLimits = 0.13f;

    public AudioClip madeira, ferro, ouro, aguia;

    private int playAguia;
    public int atualTarget, hit;//Vida de Golias

    public string side;

    private Animator anim;

    public GameObject funda;
    public GameObject escudo;
    public GameObject telaLoading;
    public GameObject dano, targetDano;

    private Scene scene;
    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //if (!SceneManager.GetSceneByName("Scene 6").isLoaded)
        //{

        atualTarget = Random.Range(0, 10);
        if (atualTarget < 5)
        {
            side = "right";
            anim.SetTrigger("R");
            anim.ResetTrigger("L");
        }
        else
        {
            side = "left";
            anim.SetTrigger("L");
            anim.ResetTrigger("R");
        }
        start = true;
        //}
        bar.fillAmount = 1;
        scene = SceneManager.GetActiveScene();

    }


    // Update is called once per frame
    void Update()
    {
        if (!dead && !attack && !defend)
        {
            Move(side);
            Debug.Log(transform.position.z);
        }

        playAguia = Random.Range(1, 1000);
        if (playAguia == 300)
        {
            if (telaLoading != null)
            {
                if (!telaLoading.activeSelf)
                {
                    GetComponent<AudioSource>().Play();
                }
            }

        }

        if (telaLoading != null)
        {
            if (telaLoading.activeSelf)
            {
                GetComponent<Enemy_Golias_AI>().enabled = false;
            }
        }

        if (dead)
        {
            Invoke("Morto", 8f);
            escudo.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void Move(string side)
    {
        if (start)
        {
            int i = Random.Range(0, 20); // Aleatoriedade para iniciar um ataque
            if (i == 5)
            {
                attack = true;
                Attack();
                return;
            }
        }

        // Lógica de movimentação e atualização de animações
        switch (side)
        {
            case "forward":
                if (transform.localPosition.z <= 0.2f)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.2f);
                    ChooseNextTarget();
                }
                else
                {
                    transform.localPosition += new Vector3(0f, 0f, speed * Time.deltaTime * -1);
                    anim.SetTrigger("Fw"); // Atualiza animação para "forward"
                    ResetOtherTriggers("Fw");
                }
                break;

            case "backward":
                if (transform.localPosition.z >= zLimits)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, zLimits);
                    ChooseNextTarget();
                }
                else
                {
                    transform.localPosition += new Vector3(0f, 0f, speed * Time.deltaTime);
                    anim.SetTrigger("Bw"); // Atualiza animação para "backward"
                    ResetOtherTriggers("Bw");
                }
                break;

            case "right":
                if (transform.localPosition.x <= xLimitsMin)
                {
                    transform.localPosition = new Vector3(xLimitsMin, transform.localPosition.y, transform.localPosition.z);
                    ChooseNextTarget();
                }
                else
                {
                    transform.localPosition += new Vector3(-speed * Time.deltaTime, 0f, 0f);
                    anim.SetTrigger("R"); // Atualiza animação para "right"
                    ResetOtherTriggers("R");
                }
                break;

            case "left":
                if (transform.localPosition.x >= xLimitsMax)
                {
                    transform.localPosition = new Vector3(xLimitsMax, transform.localPosition.y, transform.localPosition.z);
                    ChooseNextTarget();
                }
                else
                {
                    transform.localPosition += new Vector3(speed * Time.deltaTime, 0f, 0f);
                    anim.SetTrigger("L"); // Atualiza animação para "left"
                    ResetOtherTriggers("L");
                }
                break;
        }

        print("MOVE side = " + side + " ***************");
    }

    void ResetOtherTriggers(string activeTrigger)
    {
        foreach (string trigger in new string[] { "L", "R", "Fw", "Bw" })
        {
            if (trigger != activeTrigger)
            {
                anim.ResetTrigger(trigger);
            }
        }
    }

    void ChooseNextTarget()
{
    int previousTarget = atualTarget; // Salva o alvo anterior
    atualTarget = ChooseBetweenIntegers(GetAvailableTargets(atualTarget));

    // Garante que não escolhe o mesmo alvo consecutivamente
    while (atualTarget == previousTarget)
    {
        atualTarget = ChooseBetweenIntegers(GetAvailableTargets(previousTarget));
    }

    switch (atualTarget)
    {
        case 0:
            side = "left";
            anim.SetTrigger("L");
            ResetTriggers("L");
            break;

        case 1:
            side = "right";
            anim.SetTrigger("R");
            ResetTriggers("R");
            break;

        case 2:
            side = "forward";
            anim.SetTrigger("Fw");
            ResetTriggers("Fw");
            break;

        case 3:
            side = "backward";
            anim.SetTrigger("Bw");
            ResetTriggers("Bw");
            break;
    }
}

    int ChooseBetweenIntegers(int[] ints)
    {
        return ints[Random.Range(0, ints.Length)];
    }

    string ChooseBetweenStrings(string[] strings)
    {
        return strings[Random.Range(0, strings.Length)];
    }

    void OnTriggerEnter(Collider colisor)
    {
        if (colisor.tag == "DaviStone")
        {
            hit++;
            if (scene.name == "Scene 6")
            {
                if (hit <= 9) //Aqui está  a condição de vida do golias
                {
                    if (hit == 2)
                    {
                        bar.fillAmount -= 0.2f;
                        GetComponent<AudioSource>().PlayOneShot(madeira);
                        PlayerPrefs.SetInt("Escudo", 1);

                    }
                    if (hit == 4)
                    {
                        GetComponent<AudioSource>().PlayOneShot(ferro);
                        bar.fillAmount -= 0.2f;
                    }
                    PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 30);
                    if (hit == 6)
                    {
                        GetComponent<AudioSource>().PlayOneShot(ouro);
                        bar.fillAmount -= 0.2f;
                    }
                    if (hit == 8)
                    {
                        GetComponent<AudioSource>().PlayOneShot(ouro);
                        bar.fillAmount -= 0.2f;
                        escudo.GetComponent<MeshRenderer>().enabled = false;
                    }
                    PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 30);
                    dano.SetActive(true);
                }
                else
                {
                    dano.SetActive(true);
                    dead = true;
                    bar.fillAmount = 0;
                    anim.SetTrigger("Dead");
                    PlayerPrefs.SetInt("DeadGolias", 1);
                    speed = 0;
                    GetComponent<AudioSource>().PlayOneShot(ouro);
                    Invoke("Mensagem", 10);
                    GetComponent<BoxCollider>().enabled = false;
                }
            }
            else
            {
                dead = true;
                bar.fillAmount = 0;
                anim.SetTrigger("Dead");
                PlayerPrefs.SetInt("DeadGolias", 1);
                speed = 0;
                GetComponent<AudioSource>().PlayOneShot(ouro);
                Invoke("Mensagem", 10);
                GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    int[] GetAvailableTargets(int currentTarget)
    {
        // Retorna alvos disponíveis com base no alvo atual
        switch (currentTarget)
        {
            case 0:
                return new int[] { 1, 2 }; // Alvos disponíveis para o alvo 0
            case 1:
                return new int[] { 0, 3 }; // Alvos disponíveis para o alvo 1
            case 2:
                return new int[] { 0, 3 }; // Alvos disponíveis para o alvo 2
            case 3:
                return new int[] { 1, 2 }; // Alvos disponíveis para o alvo 3
            default:
                return new int[] { 0, 1, 2, 3 }; // Alvos padrão, caso o alvo atual seja inválido
        }
    }

    public void Defend()
    {
        //attack = false;

        defend = true;
        AttackEnd();

        anim.SetTrigger("Defend");
    }
    void Mensagem()
    {
        msg.SetActive(true);
    }

    void Attack()
    {
        if (!defend && !dead)
        {
            int change = Random.Range(1, 10); //O problema da qtd de ataque de golias está aqui
            if (change < 8)
            {
                anim.SetTrigger("Attack");
                Invoke("SuspendeAttack", 3);
                //defend = false;
            }
            else
            {
                anim.SetTrigger("Pisao");
                //defend = false;
            }

            //Invoke ("wait", 3.042f);
        }
    }

    void LauchSpear()
    {
        GameObject auxspear = Instantiate(spear, target.transform.position, Quaternion.identity) as GameObject;
        auxspear.transform.SetParent(this.transform.parent);

    }

    void AttackEnd()
    {
        attack = false;
        ChooseNextTarget();
    }
    void DefendEnd()
    {
        defend = false;
        ChooseNextTarget();
    }

    public void StartAttack()
    {
        //if (track.GetComponent<DefaultTrackableEventHandler> ().isTracking) {
        start = true;
        funda.GetComponent<Button>().interactable = true;
        //}
    }
    void Pisao()
    {
        //Instantiate (rachadura,transform.position, transform.rotation);
        GameObject auxRachadura = Instantiate(rachadura, target1.transform.position, Quaternion.identity) as GameObject;
        auxRachadura.transform.SetParent(this.transform.parent);
    }

    void Morto()
    {
        gameObject.SetActive(false);

    }

    void SuspendeAttack()
    {
        anim.ResetTrigger("Attack");
        attack = false;
        Move(side);
        
    }

    void ResetTriggers(string trigger)
    {
        anim.ResetTrigger(trigger);
    }

}
