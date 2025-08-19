using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ArrowsDaviGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private Button me;

	public int side;

	public bool move = false;

	public Davi_InGame davi0;

	public Biblia3dTrackableEventHandler pag;

	public GameObject davi;

	void Start()
	{
		me = GetComponent<Button> ();
	}

	void FixedUpdate () 
	{
		if (move)
        if (pag.isTracking)
			davi.GetComponent<Davi_InGame>().Move (side);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		move = true;
		if (side < 0 && !davi.GetComponent<Davi_InGame>().GetDead()) {
            davi.GetComponent<Animator>().SetBool("Stop", false);
           // davi.GetComponent<Animator> ().SetBool ("R1", true);
            davi.GetComponent<Animator>().SetTrigger("R");
			davi.GetComponent<Animator>().ResetTrigger("L");
            

        } else if(side > 0 && !davi.GetComponent<Davi_InGame>().GetDead())
        {
            davi.GetComponent<Animator>().SetBool("Stop", false);
            //davi.GetComponent<Animator> ().SetBool ("L1", true);
			davi.GetComponent<Animator>().ResetTrigger("R");
            davi.GetComponent<Animator>().SetTrigger("L");
            
        }

	}

	public void OnPointerUp(PointerEventData eventData)
	{
		move = false;
        if(!move)
		davi.GetComponent<Animator> ().SetBool ("Stop", true);
        davi.GetComponent<Animator>().ResetTrigger("L");
        davi.GetComponent<Animator>().ResetTrigger("R");

        // davi.GetComponent<Animator>().SetBool("Stop", false);

    }

}
