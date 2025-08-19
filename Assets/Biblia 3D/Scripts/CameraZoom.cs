using UnityEngine;
using System.Collections;
/// Esse é um script que controla o zoom da câmera
/// Funcionalidades
/// Script conta com smooth de movimento, trava do zoom e possibilidade de setar um novo zoom, dentro do zoom minimo e zoom máximo
/// 
/// Autor: Daniel Almeida - daniel@immersive.com.br / daniel@compilamasnaoroda.com.br
/// Data: 03/05/2014
/// Versão 1

public class CameraZoom : MonoBehaviour
{

    //Objeto alvo, ele que será o foco do zoom
    public Transform target;
    public bool zoomActive = true;
    //zoom inicial, minimo , maximo , velocidade e desacelaração do zoom
    public float zoom = 10.0f;
    public float zoomMin = 5.0f;
    public float zoomMax = 20.0f;
    public float zoomSpeed = 10.0f;
    public float zoomDampening = 5.0f;
    //----------------------------------------------------------Variáveis PRIVADAS------------------------------------------
    private float currentzoom;
    private float desiredzoom;
    private float zoomDistance;


    void Start()
    {
        desiredzoom = zoom;
        currentzoom = zoom;
        updatePosition();
    }


    void LateUpdate()
    {
        if (zoomActive)
        {
            desiredzoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomSpeed * Mathf.Abs(desiredzoom);
            desiredzoom = Mathf.Clamp(desiredzoom, zoomMin, zoomMax);
            currentzoom = Mathf.Lerp(currentzoom, desiredzoom, Time.deltaTime * zoomDampening);
            zoom = currentzoom;
        }
        updatePosition();
    }

    void updatePosition()
    {
        transform.position = transform.rotation * new Vector3(0.0f, 0.0f, -zoom) + target.transform.position;
    }

    float ClampAngle(float angle, float min, float max)
    {
        //acerta os angulos para nao passarem de -360 ou 360
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        //garante que o angulo esta no intervalor setado
        return Mathf.Clamp(angle, min, max);
    }


    public void setZoom(float _zoom)
    {
        desiredzoom = Mathf.Clamp(_zoom, zoomMin, zoomMax);
    }

    //----------------------------------------------------------METODO doLockZoom------------------------------------------
    public void doLockZoom(bool zoomLock)
    {
        zoomActive = !zoomLock;
    }
}
