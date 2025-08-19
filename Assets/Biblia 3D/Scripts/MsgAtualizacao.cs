using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgAtualizacao : MonoBehaviour {
    bool ok;
    // Use this for initialization
    private void OnEnable()
    {
        if (PlayerPrefs.GetString("Language") == "Portuguese" && !ok)
        {
            Sound_Manager.Instance.PlayOneShot("Atualizacao");
            ok = true;
        }
        else if(PlayerPrefs.GetString("Language") == "English" && !ok)
        {
            Sound_Manager.Instance.PlayOneShot("Update");
            ok = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
