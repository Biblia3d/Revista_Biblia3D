using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesabilitarCoisasAoTocar : MonoBehaviour
{
    private bool visibilidade = true;
    public GameObject ObjetoADesativar;
    public GameObject funda;
    public GameObject PreencherNome;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PreencherNome.active)
        {
            if (Input.GetMouseButtonDown(0))
            {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == ObjetoADesativar && visibilidade)
                    {
                        Debug.Log("Fui tocado");
                        ObjetoADesativar.SetActive(false);
                        funda.SetActive(false);
                        visibilidade = false;
                    }
                }
            }
        }
        
    }
}
