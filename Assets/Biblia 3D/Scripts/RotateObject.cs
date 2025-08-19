using UnityEngine;
using System.Collections;
/// Esse é um script que rotaciona um objeto no seu eixo.
/// Funcionalidades
/// Rotaciona o objeto no próprio eixo com possibilidade de smooth
/// 
/// Autor: Daniel Almeida - daniel@immersive.com.br / daniel@compilamasnaoroda.com.br
/// Data: 03/05/2014
/// Versão 1

public class RotateObject : MonoBehaviour
{
    public static RotateObject instance;
    //valores iniciais de rotação
    public float rotationX = 0.0f;
    public float rotationY = 0.0f;
    //velocidade que terá a rotação
    public float rotationSpeedX = 250.0f;
    public float rotationSpeedY = 120.0f;
    //Se movimento é com suavização
    public bool smooth = true;
    //limita a rotação no eixo X
    public float rotationMinX = -360.0f;
    public float rotationMaxX = 360.0f;
    //limita a rotação no eixo Y
    public float rotationMinY = -20f;
    public float rotationMaxY = 80f;
    //tempo para dar o smooth
    public float smoothTime = 0.3f;
    //variaveis referencia para velocidade
    private float xVelocity = 0.0f;
    private float yVelocity = 0.0f;
    //guarda o valor de x e y enquanto está interpolando
    private float xSmooth = 0.0f;
    private float ySmooth = 0.0f;  

    void Start()
    {
        instance = this;
        //inicia já na posição setada
        xSmooth = rotationX;
        ySmooth = rotationY;
        //inicializa nas posicões passadas
        updateRotation();
    }

    void LateUpdate()
    {
         if (Input.GetMouseButton(0))        {
            rotationX -= Input.GetAxis("Mouse X") * rotationSpeedX * Time.deltaTime;
            rotationY -= Input.GetAxis("Mouse Y") * rotationSpeedY * Time.deltaTime;
        }       
        
        if (smooth)
        {
            //trava a rotação smooth nos limites
            if (rotationMinX != -360 && rotationMaxX != 360)
            {
                rotationX = Mathf.Clamp(rotationX, rotationMinX, rotationMaxX);
            }
            if (rotationMinY != -360 && rotationMaxY != 360)
            {
                rotationY = Mathf.Clamp(rotationY, rotationMinY, rotationMaxY);
            }

            xSmooth = Mathf.SmoothDamp(xSmooth, rotationX, ref xVelocity, smoothTime);
            ySmooth = Mathf.SmoothDamp(ySmooth, rotationY, ref yVelocity, smoothTime);
        }
        updateRotation();
    }

    void updateRotation()
    {
        Quaternion rotation;
        
        if (smooth)
        {           
            rotation = Quaternion.Euler(ySmooth, xSmooth, 0);
        }
        else
        {
            //acerta os angulos para nao passarem de -360 ou 360
            rotationX = ClampAngle(rotationX, rotationMinX, rotationMaxX);
            rotationY = ClampAngle(rotationY, rotationMinY, rotationMaxY);
            rotation = Quaternion.Euler(rotationY, rotationX, 0);
        }
        transform.rotation = rotation;
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
}
