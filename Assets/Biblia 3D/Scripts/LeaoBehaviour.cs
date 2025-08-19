using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

using Vuforia;
using System.Collections;

public class LeaoBehaviour : MonoBehaviour
{

	//variaveis publicas
	public float speed, aux, wait, espera;
	public int reward;
	public bool left = true, right = false, start = false, stop = false, ok = false, dead, um;
	public GameObject sheep, tela;
	public AudioClip rugido, morrendo;
	private AudioSource audioSrc;
	public GameObject urso;
	public GameObject aviso, funda, dica;
	public GameObject life1, life2, life3;

	//Variaves privadas
	private GameObject[] recuo, ovelha;
	public float hit = 0;
	int acertou = 0;
	private Animator anim;

	private Vector3 posIni;
	public GameObject telaLoading, dano;

	void Awake()
	{
		anim = GetComponent<Animator>();
		aux = speed;
		// recuo = GameObject.FindGameObjectsWithTag("Recuo");
		ovelha = GameObject.FindGameObjectsWithTag("Ovelha");
		audioSrc = GetComponent<AudioSource>();
		posIni = transform.position;
		anim.SetTrigger("Rugido");
		audioSrc.PlayOneShot(rugido);
	}

	public void PlaySound() { }

    public void Run()
    {
        anim.SetTrigger("Run");
        EnableCollider();
    }

    public void Rugido()
    {
        anim.SetTrigger("Rugido");
        audioSrc.PlayOneShot(rugido);
    }


    private void FixedUpdate()
	{
		if (telaLoading != null)
		{
			if (telaLoading.activeSelf)
			{
				audioSrc.mute = true;
			}
		}
		switch (acertou)
		{
			case 1:
				life1.SetActive(false);
				break;
			case 2:
				life2.SetActive(false);
				break;
			case 3:
				life3.SetActive(false);
				break;
		}

		Esperar();
		if (start)
		{
			if (!um)
			{

				if (transform.position.z > 0.4f && !ok)
					transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
				else
				{
					ok = true;
					if (!stop && wait < 4)
					{
                        Rugido();
						print("RUGIDO 1");
						stop = true;
					}
					if (wait < 4)
					{
						wait = wait + 1 * Time.deltaTime;
					}
					else
					{
						if (stop && wait < 4.02f)
						{
                            Run();
							stop = false;
						}
						transform.eulerAngles = new Vector3(transform.eulerAngles.x, 270, transform.eulerAngles.z);
						transform.position = new Vector3(transform.position.x, transform.position.y, 0.2f);
						if (transform.localPosition.x > -0.05f)
							transform.localPosition = new Vector3(transform.localPosition.x - (speed * 1.3f) * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
						else
						{
							transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
							transform.position = new Vector3(transform.position.x, transform.position.y, 0.4f);
							if (!stop && wait < 8)
							{
                                Rugido();
								print("RUGIDO 2");
								stop = true;
							}
							if (wait < 8)
							{
								wait = wait + 1 * Time.deltaTime;
							}
							else
							{
								if (stop && wait < 8.02f)
								{
                                    Run();
									stop = false;
								}

								transform.eulerAngles = new Vector3(transform.eulerAngles.x, 270, transform.eulerAngles.z);
								transform.position = new Vector3(transform.position.x, transform.position.y, 0.2f);
                                
                                if (transform.localPosition.x > -0.27f && wait < 12)
									transform.localPosition = new Vector3(transform.localPosition.x - speed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
								else
								{
                                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
									transform.position = new Vector3(transform.position.x, transform.position.y, 0.3f);

									if (!stop && wait < 12)
									{
                                        Rugido();
										print("RUGIDO 3");
										stop = true;
									}

									if (wait < 12)
									{
										wait = wait + 1 * Time.deltaTime;
									}
									else
									{
										//transform.position = posIni;
										ok = false;
										wait = 0;
										//anim.SetTrigger("Run");
										//EnableCollider();
										stop = false;
										um = true;
									}
								}

								//

							}
						}
					}
				}
			}
			else
			{
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
				transform.position = new Vector3(transform.position.x, transform.position.y, 0.6f);
				if (transform.localPosition.x < 0.06f)
					transform.localPosition = new Vector3(transform.localPosition.x + (speed * 1.3f) * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
				else
				{
					transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
					transform.position = new Vector3(transform.position.x, transform.position.y, 0.65f);
				}
				if (!stop && wait < 4)
				{
                    Rugido();
					stop = true;
				}
				if (wait < 4)
				{
					wait = wait + 1 * Time.deltaTime;
				}
				else
				{

					if (transform.position.x < posIni.x)
					{
						transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
						if (stop)
						{
							anim.SetTrigger("Run");
							stop = false;
						}
						transform.localPosition = new Vector3(transform.localPosition.x + (speed * 1.3f) * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
					}
					else
					{
						transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
						transform.position = new Vector3(transform.position.x, transform.position.y, 0.65f);
						um = false;
						anim.SetTrigger("Run");
						//audioSrc.PlayOneShot(rugido);
						ok = false;
						wait = 0;
					}
					
				}
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Esquerdo")//se colidir com a margem esquerda
		{
			print("ESQUERDO");
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
			if (transform.position.z > -1.7f)
			{
				// transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 17.25f);
			}
			left = false;
			right = true;
			if (hit > 0 && hit < 3)
				speed = aux * hit;
			else
				speed = aux;
			if (hit < 2)
				anim.SetTrigger("Walk");
			else
				anim.SetTrigger("Run");
		}
		if (other.tag == "Direito")//se colidir com a margem direita
		{
			print("Direito");
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, transform.eulerAngles.z);
			if (transform.position.z > -1.7f && hit > 3)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.05f);
			}
			left = true;
			right = false;
			if (hit > 0 && hit < 3)
				speed = aux * hit;
			else
				speed = aux;
			if (hit < 2)
				anim.SetTrigger("Walk");
			else
				anim.SetTrigger("Run");
		}

		if (other.tag == "Preparar")//prepara o ataque
		{
			speed = 0;
			transform.LookAt(new Vector3(ovelha[0].transform.position.x, ovelha[0].transform.position.y, ovelha[0].transform.position.z - 2));
			anim.SetTrigger("Bote");
		}

		if (other.tag == "DaviStone")
		{
			hit++;
			acertou = (int)hit;
			// Damage();
			speed = 0;
			if (hit < 3)
			{
				audioSrc.Stop();
				audioSrc.PlayOneShot(morrendo);
				anim.SetTrigger("Tonto");
				start = false;
				GetComponent<BoxCollider>().enabled = false;
				Invoke("EnableCollider", 10);

			}
			else if (hit == 3)
			{
				anim.SetTrigger("Change");
				PlayerPrefs.SetInt("DeadLeao", 1);
				dead = true;
				start = false;
				GetComponent<BoxCollider>().enabled = false;
				audioSrc.Stop();
				audioSrc.PlayOneShot(morrendo);
				Invoke("ActiveBear", 4f);
				//ui.SetActive(false);
			}
			dano.SetActive(true);
			PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 10);

		}

		if (other.tag == "Recuo")//se o leao estiver fugindo da pedrada e colidir com o recuo que faz ele continuar na mesma posicao de z
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 17.25f);
			for (int i = 0; i < recuo.Length; i++)
			{
				recuo[i].GetComponent<BoxCollider>().enabled = false;
			}
		}

		if (other.tag == "Ovelha")//Se colidir com a ovelha
		{
			audioSrc.PlayOneShot(rugido);
			Destroy(other.gameObject);
			// GetComponent<BoxCollider>().enabled = false;
			Invoke("Aviso", 2f);

		}
	}

	//inicia o movimento do leao
	public void StartLion()
	{
		start = true;
		audioSrc.PlayOneShot(rugido);
		//PlaySound("Rugido");
	}

	//rotaciona o leao
	void RotateLion()
	{
		speed = aux * 2;
		if (left)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
			left = false;
			right = true;
		}
		else
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, transform.eulerAngles.z);
			left = true;
			right = false;
		}
		// Recuo();

	}

	//ativa a ovelha filha do leao
	void ComerOvelha()
	{
		sheep.SetActive(true);
	}

	//o leao salta para a posicao da ovelha
	void Jump()
	{
		transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z - 1f);
		speed = aux;
		audioSrc.PlayOneShot(rugido);
		//PlaySound("Rugido");
	}



	void FinalFase()
	{
		tela.SetActive(true);
	}

	void EnableCollider()
	{
		GetComponent<BoxCollider>().enabled = true;
	}

	void ActiveBear()
	{
		funda.GetComponent<Button>().interactable = false;
		dica.SetActive(true);
		urso.SetActive(true);
		gameObject.SetActive(false);
	}
	void Aviso()
	{
		start = false;
		aviso.SetActive(true);
	}

	void Esperar()
	{
		if (!start && !dead)
		{
			if (espera < 2)
				espera = espera + 1 * Time.deltaTime;
			else
			{
				start = true;
				espera = 0;
				speed = 0.2f;
				anim.SetTrigger("Run");
			}
		}
	}

}
