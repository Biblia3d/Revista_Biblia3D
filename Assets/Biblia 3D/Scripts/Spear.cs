using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour {

	public float speed;						//Velocidade da lança
	//Privates
	private GameObject davi;				//Achar o alvo
	private bool stop;						//Verificar se e para parar
	public  float force;					//força da lança

	// Use this for initialization
	void Start () {
		//GameObjects
		davi = GameObject.FindWithTag ("Hand");
		//Vectors and Quaternions
		//Faz a lança ir ate davi
		Vector3 relativePos = davi.transform.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos);
		transform.rotation = rotation;
		//Booleans
		stop = false;
		Destroy (gameObject,5);
	}

	// Update is called once per frame
	void Update () {
		//Faz a lança ir para frente
		if (stop == false) {
			force = speed * Time.deltaTime;
			transform.Translate (0, 0, force);
		}
	}

	//Faz a lança parar quando encontrar algo
	void OnCollisionEnter(Collision collision) {
		if (PlayerPrefs.GetInt ("Dificuldade") != 1) {
			StartCoroutine (waitTheDeath ());
			stop = true;
		}
	}

	//Destroi a lança
	IEnumerator waitTheDeath(){
		yield return new WaitForSeconds(3);
		Destroy (gameObject);

	}


}
