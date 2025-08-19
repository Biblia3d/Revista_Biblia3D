using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerusalemPosition : MonoBehaviour {

    Vector3 iniPos;
	// Use this for initialization
	void Start () {
        iniPos = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void buttonOne()
    {
        transform.localEulerAngles = new Vector3(-26, 45, 53);
    }
    public void buttonTwo()
    {
        transform.localEulerAngles = new Vector3(-86, -374, 548);
    }
    public void buttonThree()
    {
        transform.localEulerAngles = new Vector3(-44, -64, -23);
    }
    public void buttonFour()
    {
        transform.localEulerAngles = new Vector3(-15,0,0.11f);
    }

    public void buttonDefault()
    {
        transform.localEulerAngles = iniPos;
    }
}
