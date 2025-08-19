using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balao : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActiveBalao(int i)
	{
		StartCoroutine(Historia(i,3));
	}

	IEnumerator Historia(int i, float time)
	{
		yield return new WaitForSecondsRealtime(time);
		HistoriaJerusalem.instance.ChangeBalao(i);
	}

	void Change(float t)
	{
		Invoke("Anim", t);
	}

	public void Anim()
	{
		GetComponent<Animator>().SetTrigger("Out");
	}
}
