using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foco : MonoBehaviour {

	public static Foco Instance;

	void Awake()
	{
		Instance = this;
	}

	// Update is called once per frame
	void Update () {

		if (PlayerPrefs.HasKey ("Foco"))
			this.gameObject.SetActive (false);

	}
}
