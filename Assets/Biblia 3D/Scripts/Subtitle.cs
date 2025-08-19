using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Subtitle : MonoBehaviour {

    public VideoPlayer video;
    public double videoClipDuration;
    public double[] timeIni, timeEnd;
    public double current;
    [TextArea]
    public string[] legenda;
    public GameObject msg;
    public Text txt;


    public bool ok;
	// Use this for initialization
	void Start () {
        if(video != null)
        videoClipDuration = video.clip.length;
        
	}
	
	// Update is called once per frame
	void Update () {


        float t;
        if (!msg.activeSelf) {
            for (int i = 0; i < timeIni.Length; i++)
            {
                current = (double)video.time;
                if ((int)current >= timeIni[i] && current < timeEnd[i])
                {
                    msg.SetActive(true);
                    txt.text = legenda[i];
                    Invoke("Disable", t = (float)(timeIni[i] - timeEnd[i]));
                }


            }
        }

        
    }

    public void Legenda()
    {
        ok = true;
    }

    public void Disable()
    {
        msg.SetActive(false);
    }
}
