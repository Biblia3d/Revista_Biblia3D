using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Vuforia;

public class CharacterMovement : MonoBehaviour
{
    public Transform character; // Referência ao Transform do personagem
    public float speed = 2.0f; // Velocidade de movimento do personagem
    public float rotationSpeed = 10.0f; // Velocidade de rotação do personagem
    public float moveDistance = 2.0f; // Distância que o jogador se moverá
    private bool isAvoiding = false; // Verificar se o jogador está desviando
    private Vector3 avoidanceTarget; // Posição de destino do desvio
    public float avoidanceDistance = 2.0f; // Distância para desvio

    private Vector3 targetPosition;
    private bool isMoving = false;
    Animator anim;
    public LayerMask layerChao, layerDefault;
    public GameObject ovelha;

    void Start()
    {
        targetPosition = character.position;
        

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        targetPosition.y = -0.118689f;
        // Detecta toques em dispositivos móveis
        if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject())
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                ProcessTouch(touch.position);
            }
        }

        // Detecta cliques em dispositivos desktop
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            ProcessTouch(Input.mousePosition);
        }

        // Movimenta o personagem até o ponto tocado/clicado
        if (isAvoiding)
        {
            // Mover o jogador em direção à posição de desvio
            transform.position = Vector3.MoveTowards(transform.position, avoidanceTarget, speed * Time.deltaTime);

            // Verifica se o jogador chegou à posição de desvio
            if (Vector3.Distance(transform.position, avoidanceTarget) < 0.1f)
            {
                isAvoiding = false;
            }
        }
        else
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            character.position = Vector3.MoveTowards(character.position, targetPosition, step);

            // Rotaciona o personagem em direção ao ponto de destino
            Vector3 direction = (targetPosition - character.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            character.rotation = Quaternion.Slerp(character.rotation, lookRotation, Time.deltaTime * rotationSpeed);

            if (Vector3.Distance(character.position, targetPosition) < 0.1f)
            {
                isMoving = false; // Parar o movimento quando alcançar o ponto
                anim.SetTrigger("Idle");
            }
            else
            {
                transform.position += transform.forward * step * Time.deltaTime;
            }
        }
    }

    void ProcessTouch(Vector3 screenPosition)
    {
        // Verifica se a câmera está sendo usada por Vuforia
        if (VuforiaBehaviour.Instance.enabled)
        {
            // Converte a posição da tela para um ponto no mundo 3D
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerDefault))
            {

            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerChao))
            {
                // Define a nova posição de destino
                targetPosition = hit.point;
                isMoving = true;
                anim.speed = 1;
                if (SceneManager.GetSceneByName("CardDG").isLoaded)
                {
                    anim.SetLayerWeight(1, 1);
                }
                anim.SetTrigger("Run");
                AudioSource[] soundPlayer = Sound_Manager.Instance.GetComponents<AudioSource>();
                soundPlayer[0].Stop();
                soundPlayer[1].Stop();
                soundPlayer[0].enabled = false;
                soundPlayer[0].enabled = true;
                soundPlayer[1].enabled = false;
                soundPlayer[1].enabled = true;

                gameObject.GetComponent<Davi_Scene2>().PararDancaDasOvelhas();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "arvore")
        {
            ovelha.SetActive(true);
            PlayerPrefs.SetInt("AchouOvelha", 1);
        } 
        else if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ovelha"))
        {
            // Calcular a nova direção para desviar do obstáculo
            Vector3 newDirection = Quaternion.Euler(0, -45, 0) * transform.forward;
            // Define a posição de destino para onde o jogador se moverá
            // Define a posição de destino para onde o jogador se moverá durante o desvio
            avoidanceTarget = transform.position + newDirection * avoidanceDistance;
            isAvoiding = true;
        }
        if (collision.gameObject.name != "Chao" && isMoving == true)
        {
           // gameObject.GetComponent<BoxCollider>().isTrigger = true;
            //gameObject.GetComponent<CapsuleCollider>().isTrigger = true;

            //Invoke("DisableTrigger", 1f);
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
       gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }*/

    void DisableTrigger()
    {
        gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
        gameObject.GetComponent<BoxCollider>().isTrigger = false;

    }

    public void EnableScript()
    {
        GetComponent<CharacterMovement>().enabled = true;
    }

}
