using System.Collections;
using UnityEngine;
using Vuforia;

public class Ovelha_Controller : MonoBehaviour
{
    private Biblia3dTrackableEventHandler tracker;
    private Animator anim;
    public GameObject imageTarget; // Referência ao Image Target do Vuforia
    public float maxDistance = 3.0f; // Distância máxima antes de iniciar o retorno
    public float returnDelay = 2.0f; // Tempo antes de iniciar o retorno
    public float returnSpeed = 1.0f; // Velocidade de retorno

    private Vector3 targetReturnPosition;
    private Quaternion targetReturnRotation;
    private bool isReturning = false;

    public GameObject seta;
    public GameObject setaDavi;
    public bool tocou = false, ok;
    public GameObject davi;
    public Sound_Manager sound_Manager;
    public float speed = 2f;
    public bool movimentoColisao = true;

    public float moveDistance = 0.5f;
    public float moveSpeed = 0.5f;
    private bool isMoving = false;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    private Vector3 posicaoInicial;
    private Quaternion rotacaoInicial;

    void Start()
    {
        tracker = GetComponentInParent<Biblia3dTrackableEventHandler>();
        anim = GetComponent<Animator>();

        if (sound_Manager == null)
        {
            sound_Manager = Sound_Manager.Instance;
        }

        posicaoInicial = transform.position;
        rotacaoInicial = transform.rotation;

        if (imageTarget != null)
        {
            targetReturnPosition = imageTarget.transform.position;
            targetReturnRotation = Quaternion.Euler(0, Quaternion.LookRotation(targetReturnPosition - transform.position).eulerAngles.y, 0);
        }
    }

    void Update()
    {
        if (!isReturning && imageTarget != null)
        {
            float distance = Vector3.Distance(transform.position, imageTarget.transform.position);
            if (distance > maxDistance)
            {
                StartCoroutine(IniciarRetorno());
            }
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Teste");
        anim.SetTrigger("Click");
        PlayerPrefs.SetInt("TocouOvelha", PlayerPrefs.GetInt("TocouOvelha") + 1);
        if (seta != null)
            seta.SetActive(false);
        if (!ok)
        {
            if (setaDavi != null)
            {
                setaDavi.SetActive(true);
                ok = true;
            }
        }
        if (gameObject.scene.name == "Scene 2")
        {
            davi.GetComponent<Interact_Obj>().enabled = true;
        }
    }

    public void PlaySound(string clipName)
    {
        if (tracker != null && !tracker.isTracking)
            return;
        sound_Manager.PlayOneShot(clipName);
    }

    void OnTriggerEnter(Collider colisor)
    {
        if (colisor.tag == "Leao")
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Davi")
        {
            if (movimentoColisao)
            {
                anim.SetTrigger("walk");
                Vector3 playerDirection = collision.transform.forward;
                Vector3 newDirection = Quaternion.Euler(0, 45, 0) * playerDirection;
                targetPosition = transform.position + newDirection * moveDistance;
                targetRotation = Quaternion.LookRotation(playerDirection);
                StartCoroutine(MoveAndRotateAnimal());
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        anim.SetTrigger("comendo");
    }

    void OnTriggerExit(Collider outro)
    {
        if (outro.CompareTag("AreaRevista") && !isReturning)
        {
            StartCoroutine(RetornarParaPosicaoInicial());
        }
    }

    IEnumerator RetornarParaPosicaoInicial()
    {
        isReturning = true;

        while (Vector3.Distance(transform.position, posicaoInicial) > 0.01f || Quaternion.Angle(transform.rotation, rotacaoInicial) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicaoInicial, returnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoInicial, returnSpeed * Time.deltaTime);
            yield return null;
        }

        isReturning = false;
    }

    IEnumerator MoveAndRotateAnimal()
    {
        isMoving = true;
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f || Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, moveSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }

    IEnumerator IniciarRetorno()
    {
        isReturning = true;
        yield return new WaitForSeconds(returnDelay);

        // Etapa 1: Gira para a direção inicial do movimento (mantendo apenas rotação no eixo Y)
        Vector3 directionToTarget = targetReturnPosition - transform.position;
        directionToTarget.y = 0; // Mantém a rotação apenas no eixo Y
        Quaternion initialRotation = transform.rotation; // Salva a rotação original
        Quaternion newRotation = Quaternion.LookRotation(directionToTarget);

        while (Quaternion.Angle(transform.rotation, newRotation) > 0.01f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, returnSpeed * Time.deltaTime);
            yield return null;
        }

        // Etapa 2: Caminha até o destino
        anim.SetTrigger("walk"); // Ativa a animação de caminhada
        float originalY = transform.position.y; // Mantém a posição Y fixa

        while (Vector3.Distance(new Vector3(transform.position.x, targetReturnPosition.y, transform.position.z), targetReturnPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetReturnPosition.x, originalY, targetReturnPosition.z), returnSpeed * Time.deltaTime);
            yield return null;
        }

        // Etapa 3: Retorna à rotação original
        while (Quaternion.Angle(transform.rotation, initialRotation) > 0.01f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, returnSpeed * Time.deltaTime);
            yield return null;
        }

        isReturning = false;
    }
}