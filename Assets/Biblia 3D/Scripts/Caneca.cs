using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Caneca : MonoBehaviour
{

	public static Caneca instance;
	public GameObject davi; // objeto Davi
	public GameObject golias; // objeto Golias
	public float distance, espera; // distancia entre Davi e Golias
	public float speedDavi, speedGolias; // velocidade de deslocamento dos Personagens
	public float posDavi1, posDavi2, posDavi3, posDavi4; // posicoes predefinidas para Davi executar alguma ação
	public float posGolias1, posGolias2; // posicoes predefinidas para Golias executar alguma ação
	public Animator animD, animG; // animaçoes de Davi e Golias
	public bool start, stop, desce, ok, escudo, run, running, atk, rollback, walk, dash, gwalk, gatk, walkStart, walkback, walking, enter,
		ameaca, final, dead, encerrar; // condiçoes de inicio/parada das ações executadas
	public bool gActive, sheep, fall, fall1;
	public GameObject ovelha, sombraGolias;
	public GameObject flash; 

	private void Start()
	{
		instance = this;
		animD = davi.GetComponent<Animator>();
		animG = golias.GetComponent<Animator>();
		golias.transform.eulerAngles = new Vector3(golias.transform.eulerAngles.x, 270, golias.transform.eulerAngles.z);

	}

	private void Update()
	{
		distance = Vector3.Distance(davi.transform.position, golias.transform.position);
		if (!stop)
		{
			if (davi.transform.localPosition.x > posDavi1)
			{
				davi.transform.eulerAngles = new Vector3(davi.transform.eulerAngles.x, 270, davi.transform.eulerAngles.z);

				if (!walk)
				{
					animD.SetTrigger("Walk");
					walk = true;
				}
				davi.transform.localPosition = new Vector3(davi.transform.localPosition.x - speedDavi * Time.deltaTime, davi.transform.localPosition.y, davi.transform.localPosition.z);
			}
			else
			{
				davi.transform.localPosition = new Vector3(posDavi1, davi.transform.localPosition.y, davi.transform.localPosition.z);

				if (!gActive)
				{
					Invoke("ActiveGolias", 5);

					gActive = true;
					animD.SetTrigger("Wait");
				}
			}
		}
		else
		{
			if (espera <= 0)
			{

				animG.SetLayerWeight(1, 0);
				if (!walkStart)
				{
					Sound_Manager.Instance.PlayOneShot("Suspense1");
					animG.SetTrigger("Walk");
					walkStart = true;
				}
				if (golias.transform.localPosition.x > posGolias1)
				{

					golias.transform.localPosition = new Vector3(golias.transform.localPosition.x - speedGolias * Time.deltaTime, golias.transform.localPosition.y, golias.transform.localPosition.z);
				}
				else
				{
					if (!run && !running)
					{
						golias.transform.localPosition = new Vector3(golias.transform.localPosition.x, davi.transform.localPosition.y, golias.transform.localPosition.z);

						if (!start)
						{

							AnimGolias("Atk");
							Invoke("Ok", 3);
							start = true;
						}
					}
					if (!sheep)
					{
						Sound_Manager.Instance.PlayOneShot("BerroAlto");
						sheep = true;
						Invoke("DestroyOvelha", 3);
					}
					if (ovelha != null)
						ovelha.transform.localPosition = new Vector3(ovelha.transform.localPosition.x, ovelha.transform.localPosition.y + speedDavi / 2, ovelha.transform.localPosition.z);
				}

				if (golias.transform.localPosition.x <= posGolias1 + 0.5f && !enter)
				{
					animD.SetTrigger("Crounch");
					Invoke("LookAtGolias", 1f);
					enter = true;
				}
			}
			else
			{
				espera -= 1 * Time.deltaTime;
			}
		}

		if (ok)
		{
			if (!rollback)
			{
				animD.SetTrigger("RollBack");
				rollback = true;
			}
			DaviSaltaBack();
			davi.transform.eulerAngles = new Vector3(davi.transform.eulerAngles.x, 90, davi.transform.eulerAngles.z);
		}

		if (!escudo && davi.transform.localPosition.x <= posDavi2)
		{

			AnimGolias("Escudo");
			escudo = true;
		}

		if (run)
		{
			if (golias.transform.localPosition.x > posGolias2)
			{
				if (!gwalk)
					animG.SetTrigger("Walk");
				gwalk = true;
				golias.transform.localPosition = new Vector3(golias.transform.localPosition.x - speedGolias * Time.deltaTime, golias.transform.localPosition.y, golias.transform.localPosition.z);
				if (!walking)
				{
					animD.SetTrigger("Run");
					walking = true;
				}
				davi.transform.localPosition = new Vector3(davi.transform.localPosition.x + (speedDavi * 2) * Time.deltaTime, davi.transform.localPosition.y, davi.transform.localPosition.z);

			}

			if (golias.transform.localPosition.x <= posGolias2 + 0.3f)
			{
				if (!gatk)
				{
					animG.SetTrigger("Atk1");
					Invoke("LookDavi", 2);
					gatk = true;
					davi.GetComponent<DaviCaneca>().AnimacaoLayerChange1();
				}
				DaviSaltaFront();
			}
		}

		if (running && !dead)
		{
			if (!final)
			{
				if (golias.transform.localPosition.x < -1)
				{
					Time.timeScale = 1;
					golias.transform.localPosition = new Vector3(golias.transform.localPosition.x + speedGolias * Time.deltaTime, golias.transform.localPosition.y, golias.transform.localPosition.z);
					if (!walkback)
					{
						animD.SetTrigger("WalkB");
						walkback = true;
					}


				}
				else
				{
					if (!ameaca)
					{
						animG.SetTrigger("Ameaca");
						ameaca = true;
					}

				}
			}

			if (davi.transform.localPosition.x < 2)
			{
				davi.transform.localPosition = new Vector3(davi.transform.localPosition.x + speedDavi * Time.deltaTime, davi.transform.localPosition.y, davi.transform.localPosition.z);
			}
			else
			{
				if (!atk)
				{
					animD.SetTrigger("End");
					davi.transform.LookAt(golias.transform.position);
					//Invoke("Final", 2);
				}
				atk = true;
			}

			if (final)
			{
				if (distance > 3 && !dead)
				{
					Final();
					final = false;
					stop = true;
					//golias.transform.localPosition = new Vector3(golias.transform.localPosition.x + (speedGolias), golias.transform.localPosition.y, golias.transform.localPosition.z);
				}
			}
		}

		if (!final && golias.GetComponent<GoliasCaneca>().dead)
		{
			if (davi.transform.localPosition.x > 0 && golias.GetComponent<GoliasCaneca>().dead)
				davi.transform.localPosition = new Vector3(davi.transform.localPosition.x - (speedDavi * 3) * Time.deltaTime, davi.transform.localPosition.y, davi.transform.localPosition.z);
			else
			{
				if (!encerrar)
				{
					Encerrar();
					encerrar = true;
				}
			}
		}



	}

	void ActiveGolias()
	{
		golias.SetActive(true);
		sombraGolias.SetActive(true);
		stop = true;
	}

	public void AnimGolias(string name)
	{
		animG.SetTrigger(name);
	}

	public void DaviSaltaBack()
	{
		davi.transform.eulerAngles = new Vector3(davi.transform.eulerAngles.x, 90, davi.transform.eulerAngles.z);

		if (davi.transform.localPosition.x > posDavi2)
		{
			davi.transform.localPosition = new Vector3(davi.transform.localPosition.x - speedDavi / 3, davi.transform.localPosition.y, davi.transform.localPosition.z);
		}
		else
		{
			ok = false;
		}

		if (davi.transform.localPosition.z < posDavi3 / 2 && !desce)
		{
			davi.transform.localPosition = new Vector3(davi.transform.localPosition.x, davi.transform.localPosition.y, davi.transform.localPosition.z + speedDavi);
		}
		else
		{
			desce = true;
		}

		if (davi.transform.localPosition.z > 0 && desce)
		{
			davi.transform.localPosition = new Vector3(davi.transform.localPosition.x, davi.transform.localPosition.y, davi.transform.localPosition.z - speedDavi * 2f);


		}
		else
		{
			if (!fall1)
				Sound_Manager.Instance.PlayOneShot("Fall");
			fall1 = true;
		}


	}
	public void DaviSaltaFront()
	{
		davi.GetComponent<DaviCaneca>().AnimacaoLayerChange1();
		davi.transform.eulerAngles = new Vector3(davi.transform.eulerAngles.x, 270, davi.transform.eulerAngles.z);
		if (golias.transform.eulerAngles.y > 90)
			golias.transform.eulerAngles = new Vector3(golias.transform.eulerAngles.x, golias.transform.eulerAngles.y - 10, golias.transform.eulerAngles.z);

		if (davi.transform.localPosition.x < posDavi4)
		{
			davi.transform.localPosition = new Vector3(davi.transform.localPosition.x + speedDavi / 3, davi.transform.localPosition.y, davi.transform.localPosition.z);
		}
		else
		{
			run = false;
			running = true;
			animG.SetTrigger("Walk");
		}

		if (davi.transform.localPosition.z < posDavi3 + 0.5f && davi.transform.localPosition.x < posDavi4 / 3 && desce)
		{
			if (!dash)
			{

				davi.GetComponent<DaviCaneca>().AnimacaoLayerChange1();
			}
			davi.transform.localPosition = new Vector3(davi.transform.localPosition.x, davi.transform.localPosition.y, davi.transform.localPosition.z + speedDavi);
			davi.transform.LookAt(golias.transform.position);
		}
		else
		{
			desce = false;

		}

		if (davi.transform.localPosition.z > 0 && !desce)
		{
			davi.transform.localPosition = new Vector3(davi.transform.localPosition.x, davi.transform.localPosition.y, davi.transform.localPosition.z - speedDavi);
			//golias.transform.eulerAngles = new Vector3(golias.transform.eulerAngles.x, 90, golias.transform.eulerAngles.z);
			davi.transform.Rotate(0, 0, 180);
			davi.transform.LookAt(golias.transform.position);
			davi.GetComponent<DaviCaneca>().AnimacaoLayerChange1();

		}
		else
		{
			davi.GetComponent<DaviCaneca>().AnimacaoLayerChange2();

			if (!fall)
				Sound_Manager.Instance.PlayOneShot("Fall");
			fall = true;
		}



	}

	void Ok()
	{
		ok = true;
		animD.SetTrigger("Idle");
		davi.transform.eulerAngles = new Vector3(davi.transform.eulerAngles.x, 90, davi.transform.eulerAngles.z);
		davi.transform.LookAt(golias.transform.position);


	}

	void LookDavi()
	{
		golias.transform.LookAt(davi.transform.position);
		animG.SetTrigger("Walk");
		running = true;
	}

	void LookAtGolias()
	{
		animG.SetTrigger("Ready");
		davi.transform.LookAt(golias.transform.position);

	}

	void GoliasDead()
	{
		animG.SetTrigger("Dead");
		dead = true;
	}

	void Final()
	{
		animD.SetTrigger("Atk");
		Invoke("GoliasDead", 0.5f);
	}

	void DestroyOvelha()
	{
		Destroy(ovelha);
	}

	void Encerrar()
	{
		animD.SetTrigger("Ready");
		Invoke("Yes", 2);
	}

	void Yes()
	{
		animD.SetTrigger("Yes");
		//Sound_Manager.Instance.PlayOneShot("Feliz");
		Flash();

	}
	void ChangeScene8()
	{
		//SceneManager.LoadScene("Scene 8");
	}

	void Flash()
	{
		if (flash != null)
			flash.SetActive(true);
		Invoke("ChangeScene8", 2);
	}

}
