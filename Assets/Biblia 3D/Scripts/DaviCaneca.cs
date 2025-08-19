using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaviCaneca : MonoBehaviour
{

	public float speed;
	public float limitRight, limitLeft, limitFront, limitBack;
	public float wait = 0;
	public float distance;
	public int nextGo, cont = 0;
	public bool ok, run, front, back, start;
	public Vector3 pos;
	public Animator anim;
	public Transform goliasPosition;
	public GameObject golias;
	public GameObject caneca;
	public GameObject ovelha, sombra;
	// Use this for initialization
	void Start()
	{

		anim = GetComponent<Animator>();

	}

	void GoliasDead()
	{
		//golias.GetComponent<GoliasCaneca>().anim.SetTrigger("Dead");
	}

	void EnableBoxCollider()
	{
		GetComponent<BoxCollider>().enabled = true;
	}

	void Run()
	{
		transform.localPosition = new Vector3(transform.localPosition.x + (speed * 3) * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
		
	}

	void Shoot(string name)
	{
		Sound_Manager.Instance.PlayOneShot(name);
	}

	void AtvarRun()
	{
		run = true;
	}

	public void Jump()
	{
		wait = 5;
		//anim.SetTrigger("Jump");
	}

	void Position()
	{
		transform.localPosition = new Vector3(transform.localPosition.x-0.2f, transform.localPosition.y, transform.localPosition.z);
	}

	void GliasRecua()
	{
		golias.GetComponent<GoliasCaneca>().Dashback();
	}

	void SumirOvelha()
	{

		ovelha.SetActive(false);
	}

	void Aparecerovelha()
	{

		ovelha.SetActive(true);
	}

	public void AnimacaoLayerChange1()
	{
		anim.SetLayerWeight(0,0);
		anim.SetLayerWeight(2, 1);
		print("MUDOU LAYER");
	}
	public void AnimacaoLayerChange2()
	{
		anim.SetLayerWeight(0, 1);
		anim.SetLayerWeight(2, 0);
		print("MUDOU LAYER DE NOVO");
	}

	void PlaySound(string name)
	{
		Sound_Manager.Instance.PlayOneShot(name);

	}
}
