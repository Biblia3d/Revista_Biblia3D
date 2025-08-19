using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoliasCaneca : MonoBehaviour
{

	public float speed;
	public float limitRight, limitLeft, limitFront, limitBack;
	public float wait = 0;
	public float distance;
	public int nextGo;
	public bool ok,ok1, right, taunt, back, start, attack, stop, run, dead;
	public Vector3 pos;
	public Animator anim;
	public Transform daviPosition;
	public GameObject davi;
	public GameObject gameObjectDavi;
	public GameObject escudoCostas;
	public GameObject escudo, target;
	public GameObject verticalBars, btnRestart, cut, cut1, targetCut, effectImpact, targetImpact;
	public GameObject goliasMesh, sombra;
	public Material mat1;
	// Use this for initialization
	void Start()
	{

		anim = GetComponent<Animator>();
		//anim.SetTrigger("Walk");

	}

	private void Update()
	{
		
	}

	void Atacar()
	{
		attack = true;
	}


	void JumpDavi()
	{
		Sound_Manager.Instance.PlayOneShot("Argh");
		davi.GetComponent<Animator>().SetTrigger("Jump");
		davi.transform.localPosition = new Vector3(davi.transform.localPosition.x - 0.2f, 0.23f, davi.transform.localPosition.z);
	}

	public void Dashback()
	{
		anim.SetTrigger("Dash");
	}

	public void DaviDash()
	{
		davi.GetComponent<DaviCaneca>().anim.SetTrigger("Dash");
	}

	void Slow()
	{
		Sound_Manager.Instance.PlayOneShot("Matrix");
		if (verticalBars != null)
			verticalBars.SetActive(true);
		Time.timeScale = 0.1f;
	}

	void LaunchEscudo()
	{
		davi.GetComponent<DaviCaneca>().anim.StopPlayback();
		Destroy(escudoCostas);
		Instantiate(escudo, target.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
		StartCoroutine(Wait());
	}

	IEnumerator Wait()
	{
		yield return new WaitForSecondsRealtime(10);
		Time.timeScale = 1;
		Sound_Manager.Instance.PlayOneShot("Suspense2");
		print("ESTA RODANDO AINDA");
	}

	void LookDavi()
	{
		transform.LookAt(davi.transform.position);
	}

	void DaviMatrix()
	{
		davi.transform.LookAt(gameObject.transform.position);
		davi.GetComponent<Animator>().SetTrigger("Matrix");
	}

	void Run()
	{
		anim.SetTrigger("Run");
		Caneca.instance.final = true;
	}

	void Restart()
	{
		if (btnRestart != null)
			btnRestart.SetActive(true);
	}

	void PlaySound(string nome)
	{
		Sound_Manager.Instance.PlayOneShot(nome);
	}

	void CutEffect()
	{
		Instantiate(cut, targetCut.transform.position, Quaternion.Euler(new Vector3 (45,0,90)));
	}

	void CutEffect1()
	{
		Instantiate(cut1, targetCut.transform.position, Quaternion.Euler(new Vector3(-90, 0, 180)));
	}

	void EffectImpact()
	{
		Instantiate(effectImpact, targetImpact.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
		transform.localPosition = new Vector3(transform.localPosition.x - 1, transform.localPosition.y, transform.localPosition.z);

	}

	void ChangeMat()
	{
		goliasMesh.GetComponent<SkinnedMeshRenderer>().material = mat1;
	}

	void Davi()
	{
		dead = true;
		davi.GetComponent<Animator>().SetTrigger("Run");
	}

	void Impact()
	{
		transform.localPosition = new Vector3(transform.localPosition.x-0.1f, transform.localPosition.y, transform.localPosition.z);
	}

	void SombraPosition()
	{
		sombra.GetComponent<Sombra>().GrudarEmGolias();
	}

}
