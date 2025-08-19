using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesusAnim : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	public void ChangeAnimation()
    {
        anim.SetTrigger("Change");
    }
}
