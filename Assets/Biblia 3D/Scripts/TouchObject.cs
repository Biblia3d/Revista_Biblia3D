using UnityEngine;
using Vuforia;

public class TouchObject : MonoBehaviour
{

	private GameObject bird;

	void Start(){
		bird = GameObject.FindWithTag ("Bird");
	}
	void Update () {
		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				if(hit.collider.tag == "ARObject")
				{
					Debug.Log ("Clicked on Object");
				}

                				if (hit.collider.name == "Davi 2018-SM-3") {
					gameObject.GetComponent<Animator>().SetTrigger("Attack");
                				}

            }
        }
	}

	void PlaySound(string clipName){
		gameObject.GetComponent<AudioSource>().Play();
    }



}