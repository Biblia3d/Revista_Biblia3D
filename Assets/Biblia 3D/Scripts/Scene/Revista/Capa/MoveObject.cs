using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject :MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;

    public GameObject objeto; // Atribua o objeto Rock existente no Inspector
    public float throwForce = 10f; // Ajuste essa força conforme necessário
    public Camera arCamera;
    public bool isDragging = false;
    public Vector2 initialTouchPosition;
    public Vector3 pokeballStartPosition;

    void Start()
    {
        arCamera = Camera.main;
    }

    void OnMouseDown()
	{ 
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag() 
	{  
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

		Vector3 curPosition   = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = new Vector3 (curPosition.x, transform.position.y, curPosition.z);

	}

    /*void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform == objeto.transform)
                    {
                        isDragging = true;
                        initialTouchPosition = touch.position;
                        pokeballStartPosition = objeto.transform.position;
                    }
                }
            }

            if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector2 currentTouchPosition = touch.position;
                Vector3 dragDistance = (currentTouchPosition - initialTouchPosition) * 0.01f; // Ajuste a sensibilidade do arrasto
                objeto.transform.position = pokeballStartPosition + new Vector3(dragDistance.x, dragDistance.y, 0);
            }

            if (touch.phase == TouchPhase.Ended && isDragging)
            {
                isDragging = false;
                Vector2 releaseTouchPosition = touch.position;
                Vector3 releaseDistance = (releaseTouchPosition - initialTouchPosition) * 0.01f; // Ajuste a sensibilidade da força
                Rigidbody rb = objeto.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero; // Resetar velocidade antes de aplicar nova força
                rb.AddForce(new Vector3(releaseDistance.x, releaseDistance.y, releaseDistance.z), ForceMode.Force);
            }
        }
    }*/
}
