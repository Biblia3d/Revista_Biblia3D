using UnityEngine;

public class SimpleTouchController : MonoBehaviour
{
    public static SimpleTouchController instance;
    public delegate void TouchDelegate(Vector2 value);
    public event TouchDelegate TouchEvent;

    public delegate void TouchStateDelegate(bool touchPresent);
    public event TouchStateDelegate TouchStateEvent;

    public bool som;
    public GameObject davi; // Referência ao personagem Davi
    public float moveSpeed = 5f; // Velocidade de movimento
    public float minX = -5f; // Limite à esquerda
    public float maxX = 5f; // Limite à direita

    private Rigidbody daviRb;
    private bool touchPresent = false;
    private Vector2 movementVector;

    [SerializeField]
    private RectTransform joystick;
    private Vector2 joystickInitialPosition;

    private void Start()
    {
        instance = this;
        if (davi != null)
        {
            daviRb = davi.GetComponent<Rigidbody>();
        }

        if (joystick != null)
        {
            joystickInitialPosition = joystick.anchoredPosition;
        }
    }

    public Vector2 GetTouchPosition => movementVector;

    public void BeginDrag()
    {
        touchPresent = true;
        TouchStateEvent?.Invoke(touchPresent);
    }

    public void EndDrag()
    {
        touchPresent = false;
        movementVector = Vector2.zero;
        TouchStateEvent?.Invoke(touchPresent);

        if (joystick != null)
        {
            joystick.anchoredPosition = joystickInitialPosition;
        }
    }

    public void OnValueChanged(Vector2 value)
    {
        if (touchPresent)
        {
            movementVector.x = ((1 - value.x) - 0.5f) * 2f;
            TouchEvent?.Invoke(movementVector);
        }
    }

    private void FixedUpdate()
    {
        if (daviRb != null && touchPresent)
        {
            Vector3 moveDirection = new Vector3(movementVector.x, 0, 0);
            daviRb.velocity = moveDirection * moveSpeed;

            // Limitar posição no eixo X
            Vector3 clampedPosition = daviRb.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
            daviRb.position = clampedPosition;
        }
    }
}