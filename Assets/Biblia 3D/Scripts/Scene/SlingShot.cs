using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public GameObject stone; // Objeto da pedra
    public Transform slingOrigin; // Ponto de origem do estilingue
    public float launchForce = 10f; // Força de lançamento

    private Vector3 initialPosition;
    private bool isDragging = false;
    private bool touchActive = false; // Flag para desativar o mouse durante o toque

    void Start()
    {
        initialPosition = stone.transform.position;
    }

    void Update()
    {
        // Gerenciar toque (touch)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchActive = true;

            if (touch.phase == TouchPhase.Began)
            {
                if (IsTouchingStone(touch))
                {
                    isDragging = true;
                }
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                DragStone(touch.position);
            }
            else if (touch.phase == TouchPhase.Ended && isDragging)
            {
                LaunchStone();
                isDragging = false;
                touchActive = false;
            }
        }

        // Gerenciar mouse (se nenhum touch estiver ativo)
        if (!touchActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (IsTouchingStoneMouse())
                {
                    isDragging = true;
                }
            }
            else if (Input.GetMouseButton(0) && isDragging)
            {
                DragStone(Input.mousePosition);
            }
            else if (Input.GetMouseButtonUp(0) && isDragging)
            {
                LaunchStone();
                isDragging = false;
            }
        }
    }

    bool IsTouchingStone(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        return Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == stone;
    }

    bool IsTouchingStoneMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == stone;
    }

    void DragStone(Vector3 inputPosition)
    {
        inputPosition.z = Camera.main.WorldToScreenPoint(slingOrigin.position).z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(inputPosition);

        stone.transform.position = Vector3.Lerp(stone.transform.position, worldPosition, 0.1f);
    }

    void LaunchStone()
    {
        Vector3 direction = slingOrigin.position - stone.transform.position;
        direction.y = 0; // Garante que a direção seja sempre horizontal
        direction.Normalize(); // Normaliza o vetor de direção para garantir consistência

        Rigidbody rb = stone.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(direction * launchForce, ForceMode.Impulse);
        }

        Invoke("ResetStone", 2);
    }

    void ResetStone()
    {
        stone.transform.position = initialPosition;
        Rigidbody rb = stone.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}
