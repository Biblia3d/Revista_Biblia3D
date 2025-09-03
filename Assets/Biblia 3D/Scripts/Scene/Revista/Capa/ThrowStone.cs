using Biblia3D.Scene.Checklist;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrowStone : MonoBehaviour
{
    // Componentes e refer�ncias p�blicas
    public LineRenderer aimLine;            // Linha que exibe a trajet�ria prevista
    public Rigidbody stoneRb;               // Rigidbody da pedra para simula��o de f�sica
    public GameObject effectObject;         // Efeito visual associado � pedra
    public GameObject golias, success;
    public CheckItemScriptableObject checkItemScriptableObject;


    // Configura��es de mira e lan�amento
    public float aimSpeed = 10f;            // Velocidade de ajuste da mira
    public float maxAngle = 80f;            // �ngulo m�ximo permitido para a mira
    public float throwForce = 600f;         // For�a base do lan�amento
    public float gravity = -9.81f;          // Gravidade usada no c�lculo da trajet�ria
    public int trajectoryPoints = 10;       // N�mero de pontos que comp�em a linha de trajet�ria
    public float moveSpeed = 10f;           // Velocidade com que a pedra se move na trajet�ria
    public float rollingDrag = 0.5f;        // Drag aplicado ao rolamento
    public float rollingAngularDrag = 0.3f; // Angular drag aplicado ao rolamento

    // Vari�veis de controle e estado
    private Vector3 initialPosition;        // Posi��o inicial da pedra (para reset)
    private Quaternion initialRotation;     // Rota��o inicial da pedra
    private bool isTouching = false;         // Indica se h� intera��o (toque/arrasto) atual v�lida
    private float aimOffsetX = 0f;           // Offset horizontal da mira
    private float aimOffsetY = 0f;           // Offset vertical da mira
    private Vector3[] trajectoryPath;        // Array pr�-alocado dos pontos da trajet�ria
    private int currentPathIndex = 0;        // �ndice atual no array de trajet�ria
    private bool isMoving = false;           // Indica se a pedra est� se movendo na trajet�ria
    private bool hasBeenThrown = false;      // Indica se a pedra j� foi lan�ada
    private bool canThrow = true;            // Permite a detec��o de novos toques/lancamento
    private bool ignoreOngoingTouch = false; // Ignora toques que persistem no momento do reset
    private bool touchStartedOverUI = false; // Indica se o toque iniciou sobre um elemento da UI

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        trajectoryPath = new Vector3[trajectoryPoints];  // Pr�-aloca mem�ria para melhor performance
        ResetAimLine();
        if (effectObject != null)
            effectObject.SetActive(true);
    }

    void Update()
    {
        // Se ainda h� um toque ativo oriundo de uma intera��o anterior, ignore input at� que seja liberado.
        if (ignoreOngoingTouch)
        {
            if (!Input.GetMouseButton(0) && Input.touchCount == 0)
                ignoreOngoingTouch = false;
            else
                return;
        }

        // Processa input somente se permitido e se n�o estiver sobre um elemento da UI.
        if (canThrow)
        {
            if (Input.touchCount > 0)
            {
                // Processamento para dispositivos m�veis (touch)
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
                            // Se o toque come�ou sobre a UI, limpa a flag (n�o lan�a)
                            touchStartedOverUI = false;
                        }
                        else
                        {
                            // S� lan�a se o toque come�ou fora da UI e foi liberado
                            isTouching = false;
                            aimLine.enabled = false;
                            Sound_Manager.Instance.PlayOneShot("Shot");
                            StartThrowMovement();
                            canThrow = false; // Impede novos toques at� o reset
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

        // Se a pedra est� em movimento, atualiza seu deslocamento
        if (isMoving)
            MoveStoneAlongTrajectory();
    }

    // Vers�o para dispositivos m�veis (com fingerId) que verifica se o toque est� sobre a UI
    bool IsPointerOverUI(int fingerId)
    {
        if (EventSystem.current == null)
            return false;
        return EventSystem.current.IsPointerOverGameObject(fingerId);
    }

    // Vers�o padr�o para input de mouse (ou quando n�o h� toques ativos)
    bool IsPointerOverUI()
    {
        if (EventSystem.current == null)
            return false;
        return EventSystem.current.IsPointerOverGameObject();
    }

    // Ajusta os offsets de mira com base na entrada do usu�rio
    void AdjustAim()
    {
        Vector2 inputDelta = (Input.touchCount > 0)
            ? Input.GetTouch(0).deltaPosition * aimSpeed * Time.deltaTime
            : new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * aimSpeed;

        aimOffsetX = Mathf.Clamp(aimOffsetX - inputDelta.x, -maxAngle, maxAngle);
        aimOffsetY = Mathf.Clamp(aimOffsetY - inputDelta.y, -maxAngle, maxAngle);
    }

    // Permite ajustar a for�a via teclado (UpArrow/DownArrow)
    void AdjustThrowForce()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            throwForce += 10f;
        if (Input.GetKey(KeyCode.DownArrow))
            throwForce -= 10f;
        throwForce = Mathf.Clamp(throwForce, 100f, 1000f);
    }

    // Calcula os pontos da trajet�ria e atualiza a linha de mira
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

    // Inicia o lan�amento: configura os colliders e a trajet�ria
    void StartThrowMovement()
    {
        if (trajectoryPath.Length > 0)
        {
            isMoving = true;
            currentPathIndex = 0;
            hasBeenThrown = true;
            // Ao lan�ar, desativa o SphereCollider e ativa o MeshCollider para colis�o apropriada
            SphereCollider sphereCollider = GetComponent<SphereCollider>();
            MeshCollider meshCollider = GetComponent<MeshCollider>();
            if (sphereCollider != null)
                sphereCollider.enabled = false;
            if (meshCollider != null)
                meshCollider.enabled = true;
        }
    }

    // Move a pedra ao longo dos pontos da trajet�ria
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

    // Coroutine para reduzir gradualmente velocidade e rota��o
    IEnumerator ReduceVelocity()
    {
        while (stoneRb.velocity.magnitude > 0.1f)
        {
            stoneRb.velocity *= 0.97f;
            stoneRb.angularVelocity *= 0.97f;
            yield return new WaitForSeconds(0.08f);
        }
    }

    // Reseta a pedra para a posi��o e rota��o iniciais, revertendo os colliders
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

        // Se houver um toque ativo (mouse pressionado ou toque na tela), marca para ignorar at� que seja liberado
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
            ignoreOngoingTouch = true;

        // Aqui, garantimos que um novo lan�amento s� ocorrer� com um novo toque, ou seja, depois que o usu�rio levantar o dedo ou soltar o clique.
        canThrow = true;
    }

    // Reseta os offsets da mira e atualiza a linha
    void ResetAimLine()
    {
        aimOffsetX = 0f;
        aimOffsetY = 0f;
        UpdateAimLine();
    }

    // Trata colis�es, por exemplo, tocando sons ou disparando anima��es
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