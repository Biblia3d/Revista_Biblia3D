using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaduraCollider : MonoBehaviour {

	public GameObject davi;
	public GameObject parabens, msg;
	public GameObject parent;
	public GameObject balaoFinal;
	public GameObject sombra, effect;
	public GameObject funda;
	bool ok;
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "ArmaduraCorpo")
		{
			other.GetComponent<SkinnedMeshRenderer>().enabled = true;
			GetComponent<SkinnedMeshRenderer>().enabled = false;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "ArmaduraCorpo")
		{
			Destroy(other.gameObject);
			GetComponent<SkinnedMeshRenderer>().enabled = true;
			GetComponent<BoxCollider>().enabled = false;
			Invoke("Final", 4);
			davi.GetComponent<Animator>().SetTrigger("Fight");
			effect.SetActive(true);
			balaoFinal.SetActive(true);
			funda.SetActive(true);
			msg.SetActive(false);
			davi.GetComponent<Interact_Obj>().enabled = false;
			davi.GetComponent<Davi_Controller>().enabled = false;
			davi.GetComponent<BoxCollider>().enabled = false;
		}
	}

	private void OnMouseUp()
	{
		 
		parent.transform.localPosition = new Vector3(parent.transform.localPosition.x, -1.7f, parent.transform.localPosition.z);
		parent.transform.eulerAngles = new Vector3(90, transform.eulerAngles.y, transform.eulerAngles.z);
		Destroy(GetComponent<MoveArmadura>());
		if (!ok)
		{
			GetComponent<AudioSource>().Play();
			ok = true;
		}
		sombra.SetActive(true);
	}

	void Final()
	{
		parabens.SetActive(true);
		
	}
}
