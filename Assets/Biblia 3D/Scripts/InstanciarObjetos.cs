using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarObjetos : MonoBehaviour
{ //este codigo vai na sua camera

	public GameObject objetoParaInstanciar;
	RaycastHit hit;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			print("MOUSE PRESSED");
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
			{
				Instantiate(objetoParaInstanciar, hit.point, Quaternion.identity);
			}
		}
	}
}