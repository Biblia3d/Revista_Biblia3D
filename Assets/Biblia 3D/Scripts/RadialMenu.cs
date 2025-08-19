using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour {

	public static RadialMenu instance;
	//valores iniciais de rotação
	public float rotationZ= 0.0f;
	//velocidade que terá a rotação
	public float rotationSpeedX = 250.0f;
	//Se movimento é com suavização
	public bool smooth = true;
	//limita a rotação no eixo X
	public float rotationMinX = -360.0f;
	public float rotationMaxX = 360.0f;
	//limita a rotação no eixo Y
	public float rotationMinY = -20f;
	//tempo para dar o smooth
	public float smoothTime = 0.3f;
	//variaveis referencia para velocidade
	private float xVelocity = 0.0f;
	//guarda o valor de x e y enquanto está interpolando
	private float zSmooth = 0.0f;

	void Start()
	{
		instance = this;
		//inicia já na posição setada
		zSmooth = rotationZ;
		//inicializa nas posicões passadas
		updateRotation();
	}

	void LateUpdate()
	{
		if (Input.GetMouseButton(0))
		{
			rotationZ -= Input.GetAxis("Mouse X") * rotationSpeedX * Time.deltaTime;
		}

		if (smooth)
		{
			//trava a rotação smooth nos limites
			if (rotationMinX != -360 && rotationMaxX != 360)
			{
				rotationZ = Mathf.Clamp(rotationZ, rotationMinX, rotationMaxX);
			}
			

			zSmooth = Mathf.SmoothDamp(zSmooth, rotationZ, ref xVelocity, smoothTime);
		}
		updateRotation();
	}

	void updateRotation()
	{
		Quaternion rotation;

		if (smooth)
		{
			rotation = Quaternion.Euler(0, 0, zSmooth);
		}
		else
		{
			//acerta os angulos para nao passarem de -360 ou 360
			rotation = Quaternion.Euler(0, 0,rotationZ );
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
