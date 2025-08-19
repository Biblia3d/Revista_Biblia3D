using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngrySling : MonoBehaviour
{
    public Rigidbody objetoParaLancar; // Objeto que será lançado
    public LineRenderer linhaDeTiro;  // Visualizador da trajetória
    public float forcaMaxima = 10f;   // Força máxima do lançamento

    private Vector3 pontoInicial;
    private Vector3 pontoFinal;
    private bool preparandoParaLancar = false;

    void Update()
    {
        // Lida com toque na tela
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                pontoInicial = GetWorldPositionFromTouch(touch.position);
                preparandoParaLancar = true;
                linhaDeTiro.enabled = true;
            }

            if (touch.phase == TouchPhase.Moved && preparandoParaLancar)
            {
                pontoFinal = GetWorldPositionFromTouch(touch.position);
                AtualizarLinhaDeTiro();
            }

            if (touch.phase == TouchPhase.Ended && preparandoParaLancar)
            {
                pontoFinal = GetWorldPositionFromTouch(touch.position);
                LancarObjeto();
                linhaDeTiro.enabled = false;
                preparandoParaLancar = false;
            }
        }
        // Lida com mouse (para cenários que não têm toque)
        else if (Input.GetMouseButtonDown(0))
        {
            pontoInicial = GetWorldPositionFromMouse(Input.mousePosition);
            preparandoParaLancar = true;
            linhaDeTiro.enabled = true;
        }
        else if (Input.GetMouseButton(0) && preparandoParaLancar)
        {
            pontoFinal = GetWorldPositionFromMouse(Input.mousePosition);
            AtualizarLinhaDeTiro();
        }
        else if (Input.GetMouseButtonUp(0) && preparandoParaLancar)
        {
            pontoFinal = GetWorldPositionFromMouse(Input.mousePosition);
            LancarObjeto();
            linhaDeTiro.enabled = false;
            preparandoParaLancar = false;
        }
    }

    private Vector3 GetWorldPositionFromTouch(Vector2 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point; // Retorna o ponto de interseção no mundo real
        }
        return Vector3.zero; // Retorna zero se nada foi detectado
    }

    private Vector3 GetWorldPositionFromMouse(Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point; // Retorna o ponto de interseção no mundo real
        }
        return Vector3.zero; // Retorna zero se nada foi detectado
    }

    private void AtualizarLinhaDeTiro()
    {
        Vector3 direcao = pontoInicial - pontoFinal;
        linhaDeTiro.SetPosition(0, objetoParaLancar.transform.position);
        linhaDeTiro.SetPosition(1, objetoParaLancar.transform.position + direcao);
    }

    private void LancarObjeto()
    {
        Vector3 direcaoLancamento = pontoInicial - pontoFinal;
        float magnitude = Mathf.Min(direcaoLancamento.magnitude, forcaMaxima);
        Vector3 forcaLancamento = direcaoLancamento.normalized * magnitude;

        objetoParaLancar.AddForce(forcaLancamento, ForceMode.Impulse);
    }
}