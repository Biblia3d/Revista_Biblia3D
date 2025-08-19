using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Biblia3D.Scene.Checklist;

public class RockGame : MonoBehaviour {

    public GameObject golias, pedra, seta, success;
    public CheckItemScriptableObject checkItemScriptableObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "GoliasObject")
        {
            golias.GetComponent<GoliasIdle>().stop = true;
            golias.GetComponent<GoliasIdle>().wait = 0;
            golias.GetComponent<GoliasIdle>().time = 10;
            GetComponent<MeshCollider>().enabled = false;
            //golias.GetComponent<PlayerMoveController>().enabled = false;
            //golias.GetComponent<GoliasIdle>().GetComponent<Animator>().SetTrigger("Stop");
            golias.GetComponent<GoliasIdle>().GetComponentInChildren<Animator>().SetTrigger("Stumble");
            golias.GetComponent<GoliasIdle>().end = true;
            golias.GetComponent<BoxCollider>().enabled = false;
            //golias.GetComponent<MovePersonagem>().golias.GetComponent<BoxCollider>().enabled = false;
            if (seta != null)
                seta.SetActive(false);

            //this.gameObject.transform.position = new Vector3(0.5f, -0.0279f, -0.7284798f);

            if (checkItemScriptableObject != null)
            {
                checkItemScriptableObject.Confirm();
            }

            if (success != null)
            {
                success.SetActive(true);
            }

            //GetComponent<MeshRenderer>().enabled = false;
            /*if (pedra != null)
            {
                pedra.SetActive(true);
                GetComponent<MeshRenderer>().enabled = true;
                GetComponent<MeshCollider>().enabled = true;
                gameObject.SetActive(false);
            }*/
            //Invoke("Enable", 4);
        }
    }

    void Enable()
    {
       // golias.GetComponent<BoxCollider>().enabled = true;
        GetComponent<MeshCollider>().enabled = true;
        //golias.GetComponent<PlayerMoveController>().enabled = true;
        //golias.GetComponent<PlayerMoveController>().change = true;
        golias.GetComponent<MovePersonagem>().golias.GetComponent<Animator>().ResetTrigger("Stop");
        //golias.GetComponent<MovePersonagem>().golias.GetComponent<BoxCollider>().enabled = true;
        
    }
}
