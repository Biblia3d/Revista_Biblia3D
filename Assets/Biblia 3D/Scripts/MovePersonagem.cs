using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePersonagem : MonoBehaviour {
    public static MovePersonagem instance;
    public GameObject golias;
    public Animator anim;
    public bool l, r, b, f;

	// Use this for initialization
	void Start () {
        instance = this;
        anim = golias.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void WalkF()
    {
        if (!f)
        {
            anim.SetTrigger("F");
           golias.transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
        }
        f = true;
        l = false;
        b = false;
        r = false;
    }
   public void WalkB()
    {
        if (!b)
        {
            anim.SetTrigger("F");
           golias.transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        }
        f = false;
        l = false;
        b = true;
        r = false;
    }
   public void WalkL()
    {
        if (!l)
        {
            if (golias.transform.eulerAngles.y == 180)
                anim.SetTrigger("L");
            else
                anim.SetTrigger("R");

        }
        f = false;
        l = true;
        b = false;
        r = false;
    }
    public void WalkR()
    {
        if (!r)
        {
            if (golias.transform.eulerAngles.y == 0)
                anim.SetTrigger("L");
            else
                anim.SetTrigger("R");
        } 
        r = true;
        f = false;
        l = false;
        b = false;
        
    }

    void Enable()
    {
        GetComponent<PlayerMoveController>().enabled = true;
    }
}
