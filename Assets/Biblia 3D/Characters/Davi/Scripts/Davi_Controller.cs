using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using Vuforia;

public class Davi_Controller : MonoBehaviour {

	private Biblia3dTrackableEventHandler tracker;

	private Animator anim;

	public float speed;
	public bool stop = false;
    private bool f=false;

	private Scene scene;
	public GameObject DaviCanvas, canvas, final, seta, setaArvore, effect, daviFinal;
    public GameObject front; //Posicao para onde davi olha
    public GameObject objeto;
    public GameObject flash;
    public GameObject balao;

	// Use this for initialization
	void Start () {
		tracker = GetComponentInParent<Biblia3dTrackableEventHandler> ();
		anim = GetComponent<Animator> ();
		scene = SceneManager.GetActiveScene ();
		PlayerPrefs.SetInt("Fala", 1);
		PlayerPrefs.SetInt("FalaRei",0);
	}
	
	// Update is called once per frame
	void Update () {
		//Quando Ativo Faz Algo
		if (scene.name != "Scene 8") {
			if (tracker.isTracking) {
               
                    Touch();
                
				if (!stop) {
					transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + speed * Time.deltaTime);
				}
			}
			if (this.gameObject.transform.parent.name == "Verso")
				DaviCanvas.SetActive (tracker.isTracking);
		}
	}

	void Touch()
	{
		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
                if (hit.collider.name == this.gameObject.name)
                {
                    if (balao != null)
                    {
                        BalaoAcamp();
                    }
                    anim.SetTrigger("Change");
                    PlayerPrefs.SetInt("TocouDavi", 1);
                    if(Rei.instance != null)
                    Rei.instance.GetComponent<Animator>().SetTrigger("Riso");
                    //if (seta != null)
                     //   Destroy(seta);
                    //if(setaArvore != null)
                    //setaArvore.SetActive(true);
                }

                if (objeto != null)
                {
                    objeto.GetComponent<Interact_Obj>().enabled = true;
                }
			}
		}
	}

    void TouchFinal()
    {
        
          final.SetActive(true);
          Time.timeScale = 0;
           
       
    }

    public void PlaySound(string clipName){
        if(tracker!=null)
		if (!tracker.isTracking)
			return;
		Sound_Manager.Instance.PlayOneShot (clipName);
	}

	void OnTriggerEnter(Collider colisor){
		if (colisor.tag == "Stop") {

			anim.SetTrigger ("Stop");
			stop = true;
			GetComponent<BoxCollider> ().enabled = true;
		}
	}

	public void LaunchApp()
	{
		string package = "com.Fuctura.Biblia3D.DaviXGolias";
		if(IsAppInstalled(package)){
			AndroidJavaClass activityClass;
			AndroidJavaObject activity, packageManager;
			AndroidJavaObject launch;
			activityClass = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
			activity = activityClass.GetStatic<AndroidJavaObject> ("currentActivity");
			packageManager = activity.Call<AndroidJavaObject> ("getPackageManager");
			launch = packageManager.Call<AndroidJavaObject> ("getLaunchIntentForPackage", package);
			activity.Call ("startActivity", launch);
		}else{
			Application.OpenURL("https://play.google.com/store/apps/details?id="+package);
		}
	}
	public  bool IsAppInstalled(string bundleID){
		AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");
		//Debug.Log(" ********LaunchOtherApp ");
		AndroidJavaObject launchIntent = null;
		//if the app is installed, no errors. Else, doesn't get past next line
		try{
			launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage",bundleID);
			//        
			//        ca.Call("startActivity",launchIntent);
		}catch{
			Debug.Log("Horrible things happened!");
		}
		if(launchIntent == null){
			return false;
		}else{
			return true;
		}
	}

	public void ChangeScene(string scene){
		SceneManager.LoadScene (scene);
	}

	public void fala(){
        if (canvas != null)
		    canvas.SetActive (true);
		Invoke ("fim", 3);
	}

	void fim(){
        if (canvas != null)
		    canvas.SetActive (false);
	}

    public void DisPause()
    {
        Time.timeScale = 1;
    }

    public void Seta()
    {
        seta.SetActive(false);
        setaArvore.SetActive(true);
    }

    public void LookAtFront()
    {
        if (front != null)
            transform.LookAt(front.transform);
    }

    void ActiveEffect()
    {
        if (effect != null)
            effect.SetActive(true);
        anim.SetLayerWeight(1, 1);
        anim.SetTrigger("Sumir");
    }

    void Desactive()
    {
        daviFinal.SetActive(true);
        gameObject.SetActive(false);
        
    }

    void ChangeScene8()
    {
        SceneManager.LoadScene("Scene 8");
    }

    void Flash()
    {
        if (!f && flash != null)
            flash.SetActive(true);
        f = true;
        //if (SceneManager.GetActiveScene().name=="Scene 7")
        //Invoke("ChangeScene8", 2);

    }

    void BalaoAcamp()
    {
        balao.SetActive(true);
        balao.GetComponent<Animator>().SetTrigger("Change");
    }

	public void NoventaGraus()
	{
		transform.Rotate(0, 90, 0);
	}

	public void SumirSprites() //apaga os sprites da funda e do efeito embaixo de Davi na Scene 7 quando Davi some
	{
		GameObject.FindWithTag("Sombra").SetActive(false);
		GameObject.FindWithTag("Funda").GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Find("Magic_circle_2_by_doomed_aftermath_2-d4qsc7s").GetComponent<SpriteRenderer>().enabled = false;

    }
}
