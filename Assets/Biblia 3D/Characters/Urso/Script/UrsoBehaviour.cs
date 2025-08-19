using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UrsoBehaviour : MonoBehaviour {
	public GameObject alvo, voz, msg;
	public GameObject pedraPref;
	private Animator anim;
	public GameObject story;
	public int hit;
    public bool start = false, right, left;
    public AudioSource funda;
	public float esq, dir, speed, wait;
	public Transform davi;
	public GameObject life1, life2, life3, life4, life5;
	public GameObject telaLoading, dano;

	void Start(){
		//transform.position = new Vector3 (target.transform.position.x, transform.position.y, transform.position.z);
		anim = gameObject.GetComponent<Animator> ();
		voz.SetActive (true);
	}

	void Update(){

		switch (hit)
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
			case 4:
				life4.SetActive(false);
				break;
			case 5:
				life5.SetActive(false);
				break;

		}
		if (hit < 5)
		{
			transform.LookAt(davi);
			start = !davi.gameObject.GetComponent<Davi_InGame>().GetDead();
		}
		else
		{
			start = false;
		}
		
		
        if (start)
        {
			if (wait > 0)
			{
				wait = wait - 0.1f;
			}
			else {
				GetComponent<BoxCollider>().enabled = true;
				gameObject.GetComponent<Animator>().enabled = true;

				if (transform.localPosition.x < dir && right)
				{
					transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
				}
				else
				{
					right = false;
					left = true;
				}
				if (transform.localPosition.x > esq && left) {

					transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
				}
				else
				{
					right = true;
					left = false;
				}

				anim.SetLayerWeight(1, 1);
			}

		}
		else
		{
            anim.SetTrigger("idle");
			speed = 0;
        }
	}

	void Pedrada(){
		//stop = true;
		//pedraUrso.SetActive (true);
		//Destroy (pedraUrso, 2.0f);
		//Invoke ("ActiveStone", 2.54f);
		anim.SetTrigger ("Pedrada");
	}

	void ActiveStone(){
		Instantiate (pedraPref, alvo.transform.position, alvo.transform.rotation);
		//stop = false;
		//anim.SetTrigger ("Change");

	}

	void Rugido(){
		anim.SetTrigger ("Change");
	}

	void OnTriggerEnter(Collider colisor){
		if(colisor.tag=="DaviStone"){
			hit++;
			if (hit < 5)
			{
				GetComponent<BoxCollider>().enabled = false;
				anim.SetTrigger("Defend");
				wait = 1f;
				anim.SetLayerWeight(1, 0);
			}
			else
			{
				anim.SetTrigger("Dead");
				PlayerPrefs.SetInt("DeadUrso", 1);
				GetComponent<BoxCollider>().enabled = false;
				start = false;
				anim.SetLayerWeight(1, 0);
				Invoke("Mensagem", 7);
			}
			
			print ("Jorge");
			dano.SetActive(true);

		}
	}
	public void PlaySound(string clipName){
		if (telaLoading != null)
			{
				if (!telaLoading.activeSelf)
				{
					Sound_Manager.Instance.PlayOneShot(clipName);
				}
		}
		;
	}
	void Mensagem(){
		msg.SetActive (true);
        funda.Stop();
	}
    
    public void StartUrso()
    {
        start= true;
		Pedrada();
    }
}
