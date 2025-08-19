using Biblia3D.Scene.Checklist;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokeBallMove : MonoBehaviour
{
    public GameObject objeto;
    public GameObject pedra;
    public float throwForce = 10f;
    public Camera arCamera;
    public bool isDragging = false;
    public Vector2 initialTouchPosition;
    public Vector3 pokeballStartPosition;
    public Vector3 pokeballStartLaunchPosition;
    public Vector3 initialMousePosition;

    public bool mouse = true;
    public bool enable = true;

    Rigidbody rb;
    public float time;
    public GameObject golias, success, effect, effectCast;
    public CheckItemScriptableObject checkItemScriptableObject;
    public float maxYVelocity;
    public float upwardForceFactor = 0.3f;
    public float dragForceMultiplier = 0.01f; // Multiplicador da força
    public bool canPlaySound = false;



    public Text txt1, txt2, txt3;

    void Start()
    {
        objeto = gameObject;
        arCamera = Camera.main;
        rb = objeto.GetComponent<Rigidbody>();
        pokeballStartPosition = objeto.transform.position;

        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
        else
        {
            Debug.LogError("O objeto não possui um Rigidbody!");
            enabled = false;
        }

    }

    void Update()
    {
        DetectInput();
        if (objeto != null && rb != null && objeto.transform.position.y < pokeballStartPosition.y)
        {
            objeto.transform.position = new Vector3(objeto.transform.position.x, pokeballStartPosition.y, objeto.transform.position.z);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        txt1.text = throwForce.ToString();
        txt2.text = maxYVelocity.ToString();
        txt3.text = upwardForceFactor.ToString();
    }

    void DetectInput()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0) && !isDragging)
        {
            Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == objeto)
                {
                    StartDrag(Input.mousePosition);
                }
            }
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            UpdateDrag(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            EndDrag();
        }
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !isDragging)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject == objeto)
                    {
                        StartDrag(touch.position);
                    }
                }
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                UpdateDrag(touch.position);
            }
            else if (touch.phase == TouchPhase.Ended && isDragging)
            {
                EndDrag();
            }
        }
#endif
    }

    void StartDrag(Vector2 screenPosition)
    {
        isDragging = true;
        effect.SetActive(false);
        initialTouchPosition = screenPosition;
        pokeballStartLaunchPosition = objeto.transform.position;
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }

    void UpdateDrag(Vector2 screenPosition)
    {
        // Opcional: feedback visual durante o arrasto pode ser adicionado aqui
    }

    void EndDrag()
    {
        isDragging = false;
        canPlaySound = true;
        if (rb != null)
        {
            Sound_Manager.Instance.PlayOneShot("Shot");
            rb.isKinematic = false;
            rb.useGravity = true;

            if (GetComponent<SphereCollider>().isTrigger)
                GetComponent<SphereCollider>().enabled = false; // Desativa área de toque

            Vector2 releasePosition = GetCurrentInputPosition();
            Vector2 dragVector = releasePosition - initialTouchPosition;

            float dragMagnitude = dragVector.magnitude;
            Vector2 normalizedDrag = dragVector.normalized;

            Vector3 throwDirection = arCamera.transform.forward + arCamera.transform.up * upwardForceFactor + arCamera.transform.right * normalizedDrag.x;

            Vector3 throwForce1 = throwDirection.normalized * dragMagnitude * throwForce * dragForceMultiplier;

            rb.velocity = Vector3.zero;
            rb.AddForce(throwForce1, ForceMode.Impulse);

            if (maxYVelocity != 0 && rb.velocity.y > maxYVelocity)
            {
                rb.velocity = new Vector3(rb.velocity.x, maxYVelocity, rb.velocity.z);
            }

            enabled = false;
            Invoke("EnableScript", time);
            Invoke("ResetPosition", time);

            if(PlayerPrefs.GetInt("Pokeball")>0)
            PlayerPrefs.SetInt("Pokeball", PlayerPrefs.GetInt("Pokeball") - 1);
        }
    }

    void ResetPosition()
    {
        if (objeto != null && rb != null)
        {
            objeto.transform.position = pokeballStartPosition;
            objeto.transform.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            rb.useGravity = false;
            canPlaySound = false;

            if (effect != null)
                effect.SetActive(true); // Reativa efeito

            if (GetComponent<SphereCollider>().isTrigger)
                GetComponent<SphereCollider>().enabled = true; // Reativa área de toque

            Invoke("EnablePhysics", 1f);
        }
    }

    void EnableScript()
    {
        enabled = true;
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            if (effect != null)
            {
                effect.SetActive(true); // Certifica que o efeito está ativado
            }

            objeto.transform.position = pokeballStartPosition;
        }
    }

    void EnablePhysics()
    {
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }

    Vector2 GetCurrentInputPosition()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        return Input.mousePosition;
#else
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).position;
        }
        return Vector2.zero;
#endif
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == golias)
        {
            Sound_Manager.Instance.PlayOneShot("Impacto");
            golias.GetComponent<BoxCollider>().enabled = false;


            golias.transform.position = new Vector3(golias.transform.position.x, 0f, golias.transform.position.z);
            Invoke("DisableKinematic", 2);

            if (checkItemScriptableObject != null)
            {
                checkItemScriptableObject.Confirm();
            }


            if (effect != null)
            {
                Instantiate(effect, collision.contacts[0].point, Quaternion.identity);
            }

            if (effectCast != null)
            {
                Instantiate(effectCast, transform.position, Quaternion.identity);
            }

            gameObject.GetComponent<PokeBallMove>().enabled = false;
        }

        if (collision.gameObject.name.Contains("Tree"))
        {
            Sound_Manager.Instance.PlayOneShot("Toc");
            Animator treeAnimator = collision.gameObject.GetComponent<Animator>();
            if (treeAnimator != null)
                treeAnimator.SetTrigger("Change");
        }
        else if (collision.gameObject.CompareTag("Ground") && canPlaySound)
        {
            Sound_Manager.Instance.PlayOneShot("Toc");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GoliasObject" && gameObject.name.Equals("Pedra"))
        {
            Sound_Manager.Instance.PlayOneShot("Impacto");
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
            gameObject.GetComponent<PokeBallMove>().enabled = false;
            Invoke("DestroyRock", 3);
        }
        else if (other.name == "GoliasObject" && gameObject.name.Equals("Pokeball"))
        {
            Sound_Manager.Instance.PlayOneShot("Impacto");
            objeto.transform.localEulerAngles = new Vector3(0.536f, -623.359f, -2.352f);
            objeto.transform.position = new Vector3(objeto.transform.position.x, 0.5f, objeto.transform.position.z);

            rb.isKinematic = true;
            golias.GetComponent<GoliasIdle>().stop = true;
            golias.GetComponent<GoliasIdle>().wait = 0;
            golias.GetComponent<GoliasIdle>().time = 10;
            //GetComponent<MeshCollider>().enabled = false;
            golias.GetComponent<GoliasIdle>().GetComponentInChildren<Animator>().SetTrigger("Stumble");
            effectCast.SetActive(true);
            golias.GetComponent<GoliasIdle>().end = true;
            golias.GetComponent<BoxCollider>().enabled = false;


            golias.transform.position = new Vector3(golias.transform.position.x, 0f, golias.transform.position.z);
            Invoke("DisableKinematic", 2);

            if (checkItemScriptableObject != null)
            {
                checkItemScriptableObject.Confirm();
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
            gameObject.GetComponent<PokeBallMove>().enabled = false;
            //Invoke("DestroyRock", 3);
        }

        void DisableKinematic()
        {
            rb.isKinematic = false;
            gameObject.GetComponent<PokeBallMove>().enabled = false;

        }
    }
}