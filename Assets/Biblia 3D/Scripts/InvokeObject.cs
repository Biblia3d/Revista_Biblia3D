using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeObject : MonoBehaviour {
    public GameObject[] obj;
    public GameObject bau;
	
    void Ativar()
    {
        for(int i=0;i<obj.Length;i++)
        obj[i].SetActive(true);
        bau.GetComponent<Interact_Obj>().enabled = true;
    }

    public void GameObjectInvoke(float time)
    {
        Invoke("Ativar", time);
    }
}
