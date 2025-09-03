using Biblia3D.Scene.Checklist;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrowStone : MonoBehaviour
{
    // Componentes e referências públicas
    public LineRenderer aimLine;            // Linha que exibe a trajetória prevista
    public Rigidbody stoneRb;               // Rigidbody da pedra para simulação de física
    public GameObject effectObject;         // Efeito visual associado à pedra
    public GameObject golias, success;
    public CheckItemScriptableObject checkItemScriptableObject;


    // Configurações de mira e lançamento
    public float aimSpeed = 10f;            // Velocidade de ajuste da mira
    public float maxAngle = 80f;            // Ângulo máximo permitido para a mira
    public float throwForce = 600f;         // Força base do lançamento
    public float gravity = -9.81f;          // Gravidade usada no cálculo da trajetória
    public int trajectoryPoints = 10;       // Número de pontos que compõem a linha de trajetória
    public float moveSpeed = 10f;           // Velocidade com que a pedra se move na trajetória
    public float rollingDrag = 0.5f;        // Drag aplicado ao rolamento
    public float rollingAngularDrag = 0.3f; // Angular drag aplicado ao rolamento

    // Variáveis de controle e estado
    private Vector3 initialPosition;        // Posição inicial da pedra (para reset)
    private Quaternion initialRotation;     // Rotação inicial da pedra
    private bool isTouching = false;         // Indica se há interação (toque/arrasto) atual válida
    private float aimOffsetX = 0f;           // Offset horizontal da mira
    private float aimOffsetY = 0f;           // Offset vertical da mira
    private Vector3[] trajectoryPath;        // Array pré-alocado dos pontos da trajetória
    private int currentPathIndex = 0;        // Índice atual no array de trajetória
    private bool isMoving = false;           // Indica se a pedra está se movendo na trajetória
    private bool hasBeenThrown = false;      // Indica se a pedra já foi lançada
    private bool canThrow = true;            // Permite a detecção de novos toques/lancamento
    private bool ignoreOngoingTouch = false; // Ignora toques que persistem no momento do reset
    private bool touchStartedOverUI = false; // Indica se o toque iniciou sobre um elemento da UI

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        trajectoryPath = new Vector3[trajectoryPoints];  // Pré-aloca memória para melhor performance
        ResetAimLine();
        if (effectObject != null)
            effectObject.SetActive(true);
    }

    void Update()
    {
        // Se ainda há um toque ativo oriundo de uma interação anterior, ignore input até que seja liberado.
        if (ignoreOngoingTouch)
        {
            if (!Input.GetMouseButton(0) && Input.touchCount == 0)
                ignoreOngoingTouch = false;
            else
                return;
        }

        // Processa input somente se permitido e se não estiver sobre um elemento da UI.
        if (canThrow)
        {
            if (Input.touchCount > 0)
            {
                // Processamento para dispositivos móveis (touch)
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        // Se o toque iniciou sobre a UI, marca a flag e ignora o input
                        if (IsPointerOverUI(touch.fingerId))
                        {
                            touchStartedOverUI = true;
                        }
                        else
                        {
                            isTouching = true;
                            aimLine.enabled = true;
                            if (effectObject != null)
                                effectObject.SetActive(false);
                        }
                        break;

                    case TouchPhase.Moved:
                        // Se o toque iniciou sobre a UI, ignora
                        if (touchStartedOverUI)
                        {
                            return;
                        }
                        else
                        {
                            AdjustAim();
                            UpdateAimLine();
                        }
                        break;

                    case TouchPhase.Ended:
                        if (touchStartedOverUI)
                        {
                            // Se o toque começou sobre a UI, limpa a flag (não lança)
                            touchStartedOverUI = false;
                        }
                        else
                        {
                            // Só lança se o toque começou fora da UI e foi liberado
                            isTouching = false;
                            aimLine.enabled = false;
                            Sound_Manager.Instance.PlayOneShot("Shot");
                            StartThrowMovement();
                            canThrow = false; // Impede novos toques até o reset
                        }
                        break;
                }
            }
            else
            {
                // Processamento para input de mouse
                if (Input.GetMouseButtonDown(0))
                {
                    if (IsPointerOverUI())
                        return; // Ignora se o clique iniciou sobre a UI
                    isTouching = true;
                    aimLine.enabled = true;
                    if (effectObject != null)
                        effectObject.SetActive(false);
                }
                else if (Input.GetMouseButton(0))
                {
                    AdjustAim();
                    UpdateAimLine();
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    isTouching = false;
                    aimLine.enabled = false;
                    Sound_Manager.Instance.PlayOneShot("Shot");
                    StartThrowMovement();
                    canThrow = false;
                }
            }
        }

        AdjustThrowForce();

        // Se a pedra está em movimento, atualiza seu deslocamento
        if (isMoving)
            MoveStoneAlongTrajectory();
    }

    // Versão para dispositivos móveis (com fingerId) que verifica se o toque está sobre a UI
    bool IsPointerOverUI(int fingerId)
    {
        if (EventSystem.current == null)
            return false;
        return EventSystem.current.IsPointerOverGameObject(fingerId);
    }

    // Versão padrão para input de mouse (ou quando não há toques ativos)
    bool IsPointerOverUI()
    {
        if (EventSystem.current == null)
            return false;
        return EventSystem.current.IsPointerOverGameObject();
    }

    // Ajusta os offsets de mira com base na entrada do usuário
    void AdjustAim()
    {
        Vector2 inputDelta = (Input.touchCount > 0)
            ? Input.GetTouch(0).deltaPosition * aimSpeed * Time.deltaTime
            : new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * aimSpeed;

        aimOffsetX = Mathf.Clamp(aimOffsetX - inputDelta.x, -maxAngle, maxAngle);
        aimOffsetY = Mathf.Clamp(aimOffsetY - inputDelta.y, -maxAngle, maxAngle);
    }

    // Permite ajustar a força via teclado (UpArrow/DownArrow)
    void AdjustThrowForce()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            throwForce += 10f;
        if (Input.GetKey(KeyCode.DownArrow))
            throwForce -= 10f;
        throwForce = Mathf.Clamp(throwForce, 100f, 1000f);
    }

    // Calcula os pontos da trajetória e atualiza a linha de mira
    void UpdateAimLine()
    {
        Vector3 aimDirection = Quaternion.Euler(aimOffsetY, aimOffsetX, 0) * transform.forward;
        Vector3 initialVelocity = aimDirection * throwForce * 0.01f;

        aimLine.positionCount = trajectoryPoints;
        for (int i = 0; i < trajectoryPoints; i++)
        {
            float time = i * 0.1f;
            trajectoryPath[i] = transform.position +
                                (initialVelocity * time) +
                                (0.5f * new Vector3(0, gravity, 0) * time * time);

            if (trajectoryPath[i].y < initialPosition.y)
                trajectoryPath[i].y = initialPosition.y;

            aimLine.SetPosition(i, trajectoryPath[i]);
        }
    }

    // Inicia o lançamento: configura os colliders e a trajetória
    void StartThrowMovement()
    {
        if (trajectoryPath.Length > 0)
        {
            isMoving = true;
            currentPathIndex = 0;
            hasBeenThrown = true;
            // Ao lançar, desativa o SphereCollider e ativa o MeshCollider para colisão apropriada
            SphereCollider sphereCollider = GetComponent<SphereCollider>();
            MeshCollider meshCollider = GetComponent<MeshCollider>();
            if (sphereCollider != null)
                sphereCollider.enabled = false;
            if (meshCollider != null)
                meshCollider.enabled = true;
        }
    }

    // Move a pedra ao longo dos pontos da trajetória
    void MoveStoneAlongTrajectory()
    {
        if (currentPathIndex < trajectoryPoints)
        {
            Vector3 direction = trajectoryPath[currentPathIndex] - transform.position;
            stoneRb.velocity = direction.normalized * moveSpeed;
            stoneRb.angularVelocity = new Vector3(0, 0, -stoneRb.velocity.magnitude * 2f);
            currentPathIndex++;
            if (currentPathIndex >= trajectoryPoints)
            {
                isMoving = false;
                StartRollingEffect();
            }
        }
    }

    // Inicia o efeito de rolagem e agenda o reset da pedra
    void StartRollingEffect()
    {
        stoneRb.drag = rollingDrag;
        stoneRb.angularDrag = rollingAngularDrag;
        StartCoroutine(ReduceVelocity());
        Invoke(nameof(ResetPosition), 3f);
    }

    // Coroutine para reduzir gradualmente velocidade e rotação
    IEnumerator ReduceVelocity()
    {
        while (stoneRb.velocity.magnitude > 0.1f)
        {
            stoneRb.velocity *= 0.97f;
            stoneRb.angularVelocity *= 0.97f;
            yield return new WaitForSeconds(0.08f);
        }
    }

    // Reseta a pedra para a posição e rotação iniciais, revertendo os colliders
    void ResetPosition()
    {
        stoneRb.velocity = Vector3.zero;
        stoneRb.angularVelocity = Vector3.zero;
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        ResetAimLine();
        if (effectObject != null)
            effectObject.SetActive(true);

        // Reverte os colliders: ativa o SphereCollider e desativa o MeshCollider
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        MeshCollider meshCollider = GetComponent<MeshCollider>();
        if (sphereCollider != null)
            sphereCollider.enabled = true;
        if (meshCollider != null)
            meshCollider.enabled = false;

        // Se houver um toque ativo (mouse pressionado ou toque na tela), marca para ignorar até que seja liberado
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
            ignoreOngoingTouch = true;

        // Aqui, garantimos que um novo lançamento só ocorrerá com um novo toque, ou seja, depois que o usuário levantar o dedo ou soltar o clique.
        canThrow = true;
    }

    // Reseta os offsets da mira e atualiza a linha
    void ResetAimLine()
    {
        aimOffsetX = 0f;
        aimOffsetY = 0f;
        UpdateAimLine();
    }

    // Trata colisões, por exemplo, tocando sons ou disparando animações
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Tree"))
        {
            Sound_Manager.Instance.PlayOneShot("Impacto");
            Animator treeAnimator = collision.gameObject.GetComponent<Animator>();
            if (treeAnimator != null)
                treeAnimator.SetTrigger("Change");
        }
        else if (collision.gameObject.CompareTag("Ground") && hasBeenThrown)
        {
            Sound_Manager.Instance.PlayOneShot("Toc");
        }
        else if(collision.gameObject.name == "GoliasObject")
        {
            Sound_Manager.Instance.PlayOneShot("Impacto");
            Animator goliasAnimator = collision.gameObject.GetComponent<Animator>();
            if (goliasAnimator != null)
                goliasAnimator.SetTrigger("Stumble");
            golias.GetComponent<GoliasIdle>().stop = true;
            golias.GetComponent<GoliasIdle>().wait = 0;
            golias.GetComponent<GoliasIdle>().time = 10;
            //GetComponent<MeshCollider>().enabled = false;
            golias.GetComponent<GoliasIdle>().GetComponentInChildren<Animator>().SetTrigger("Stumble");
            golias.GetComponent<GoliasIdle>().end = true;
            golias.GetComponent<BoxCollider>().enabled = false;


            golias.transform.position = new Vector3(golias.transform.position.x, 0.05f, golias.transform.position.z);

            if (checkItemScriptableObject != null)
            {
                checkItemScriptableObject.Confirm();
            }

            if (success != null)
            {
                success.SetActive(true);
            }

            //GetComponent<MeshRenderer>().enabled = false;
            /*if (pedra != null)
            {
                pedra.SetActive(true);
                GetComponent<MeshRenderer>().enabled = true;
                GetComponent<MeshCollider>().enabled = true;
                gameObject.SetActive(false);
            }*/
            //gameObject.GetComponent<Rigidbody>().isKinematic = true;
            CancelInvoke("ResetPosition");
            //gameObject.GetComponent<PokeBallMove>().enabled = false;
            Invoke("DestroyRock", 3);
        }


    }
}