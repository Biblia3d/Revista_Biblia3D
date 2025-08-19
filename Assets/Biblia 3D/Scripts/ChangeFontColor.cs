using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFontColor : MonoBehaviour {
	Vector4 color;
	public void ChangeColor()
	{
		color = GetComponent<Text>().color;
		GetComponent<Text>().color = new Color(1, 0.92f, 0.016f, 1);
		Invoke("RestoreColor", 0.7f);
	}

	void RestoreColor()
	{
		GetComponent<Text>().color = color;
	}
}
