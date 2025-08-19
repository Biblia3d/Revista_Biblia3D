using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {
	//Publics
	public float speed;
	
	//Privates
	public GameObject davi03, davi10;			//Posiçao de Davi
	//private GameObject golias;	//Posiçao do Golias
	private GameObject golias;
	public GameObject urso, leao;
	private GameObject pag;
	public float z, y;
	//private Golias_Move goliasScript;	//Script Golias
	private SpriteRenderer mira;		//Cor da mira
	private int change;					//Trocas de direçao
	public bool shootOnSoldier, wait = false;
	//public GameObject [] soldado;
	public GameObject aim;
	private GameObject alvo;
	// Use this for initialization
	void Start () {
		//soldado = new GameObject [3];
		//GameObjects
		//golias = GameObject.FindWithTag ("Golias");
		golias = GameObject.FindWithTag ("Golias");
		//urso = GameObject.FindWithTag ("urso");
		if(leao == null)
		leao = GameObject.FindWithTag ("Leao");
		alvo = leao;
		//Scripts
		//goliasScript=golias.GetComponent<Golias_Move>();
		//SpriteRenderers
		mira=GetComponent<SpriteRenderer>();
		//Integers
		change = 1;
		shootOnSoldier = false;
		pag = GameObject.FindWithTag("Story_Manager");
	}
	
	// Update is called once per frame
	void Update () {

        //soldado = GameObject.FindGameObjectsWithTag ("Soldado");
        //if (PlayerPrefs.GetInt ("Checkpoint") == 0) {
        if (urso != null && !leao.activeSelf)
            alvo = urso;
        else
        {
            if (leao != null)
                alvo = leao;
        }

        if (pag.GetComponent<Story_Manager> ().atualTrack == "04") {
			transform.localPosition = new Vector3 (davi03.transform.localPosition.x * 0.875f, davi03.transform.localPosition.y + y, alvo.transform.localPosition.z - 0.08f);
		} else if (pag.GetComponent<Story_Manager> ().atualTrack == "10"||pag.GetComponent<Story_Manager> ().atualTrack == "VersoCarta") {
			transform.localPosition = new Vector3 (davi10.transform.localPosition.x * 0.875f, davi10.transform.localPosition.y + y, z);//golias.transform.localPosition.z-0.08f);

			if ((aim != null && aim.transform.localPosition.x <= golias.transform.localPosition.x + 0.1f && aim.transform.localPosition.x >= golias.transform.localPosition.x - 0.1f)) {//&&golias.GetComponent<Golias_Move>().waitYourTime)) {
				aim.GetComponent<SpriteRenderer> ().color = new Color (1f, 0f, 0f, 1f);

				//if (!golias.GetComponent<Enemy_Golias_AI> ().dead && !wait) {
                //    golias.GetComponent<Enemy_Golias_AI>().Defend();
				//	wait = true;
				//	Invoke ("NaoWait", 2);
				//}
			} else {
				aim.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
				if (mira != null)
					mira.gameObject.transform.position = new Vector3 (transform.position.x, 2f, 22f);
				//			shootOnSoldier=false;
			}
		}//else if (pag.GetComponent<Story_Manager> ().atualTrack == "VersoCarta") {
//			transform.localPosition = new Vector3 (davi10.transform.localPosition.x * 0.875f, davi10.transform.localPosition.y + y, z);
//			//}
////		if (PlayerPrefs.GetInt ("Checkpoint") == 1) {
////			transform.position = new Vector3 (davi03.transform.position.x * 1.875f, 2.59f, urso.transform.position.z - 2);
////		}
////		//Posicionar mira na distancia do Golias.
////		if(PlayerPrefs.GetInt("Checkpoint")>1){
////		transform.position = new Vector3 (davi03.transform.position.x*1.875f,2.59f,golias.transform.position.z-2);
////		}
//			//Muda a cor da mira quando estiver sobre Golias
//			if ((aim != null && aim.transform.localPosition.x <= golias.transform.localPosition.x + 0.1f && aim.transform.localPosition.x >= golias.transform.localPosition.x - 0.1f)) {//&&golias.GetComponent<Golias_Move>().waitYourTime)) {
//				aim.GetComponent<SpriteRenderer> ().color = new Color (1f, 0f, 0f, 1f);
//
////				if (!golias.GetComponent<Enemy_Golias_AI> ().dead && !wait) {
////					Defend ();
////					wait = true;
////					Invoke ("NaoWait", 2);
////				}
//			} else {
//				aim.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
//				if (mira != null)
//					mira.gameObject.transform.position = new Vector3 (transform.position.x, 2f, 22f);
////			shootOnSoldier=false;
//			}
//		}
//		for(int i=0;i<soldado.Length;i++){
//			if((aim.transform.position.x <= soldado[i].transform.position.x + 1f && aim.transform.position.x >= soldado[i].transform.position.x - 1f)){
//				aim.GetComponent<SpriteRenderer>().color=new Color(0f, 1f, 0f, 1f);
//				mira.gameObject.transform.position=new Vector3(transform.position.x,2f,27f);
//				shootOnSoldier=true;
//			}
//		}
		
	}
	//public void Defend(){
	//Faz Golias defender
	//	if (aim.GetComponent<SpriteRenderer> ().color == new Color (1f, 0f, 0f, 1f)) {
	//		golias.GetComponent<Enemy_Golias_AI> ().Defend ();
	//	}
	//}

	void NaoWait(){
		wait = false;
	}
}
