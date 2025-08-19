using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeBallMoveMouse : MonoBehaviour
{
    public GameObject pokeball; // Atribua o objeto Pokébola existente no Inspector
    public float throwForce = 10f; // Ajuste essa força conforme necessário
    public Camera arCamera;
    public bool isDragging = false;
    public Vector3 initialMousePosition;
    public Vector3 pokeballStartPosition;
    public float time;
    public Rigidbody rb;

    void Start()
    {
        arCamera = Camera.main;
        rb = pokeball.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Entrou na Fisica");
                if (hit.transform == pokeball.transform)
                {
                    isDragging = true;
                    initialMousePosition = Input.mousePosition;
                    pokeballStartPosition = pokeball.transform.position;
                    
                }
            }
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 dragDistance = (currentMousePosition - initialMousePosition) * 0.005f; // Ajuste a sensibilidade do arrasto
            pokeball.transform.position = pokeballStartPosition + new Vector3(dragDistance.x, dragDistance.y, 0);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            rb.constraints = RigidbodyConstraints.None;
            Vector3 releaseMousePosition = Input.mousePosition;
            Vector3 releaseDistance = (releaseMousePosition - initialMousePosition) * 0.01f; // Ajuste a sensibilidade da força
            
            rb.velocity = Vector3.zero; // Resetar velocidade antes de aplicar nova força
            rb.AddForce(new Vector3(releaseDistance.x, releaseDistance.y, throwForce), ForceMode.Impulse);

            //Invoke("DestroyGameObject", time);
            
        }
    }

    public void DestroyGameObject()
    {
        if(!isDragging)
        Destroy(this.gameObject);
    }



}
