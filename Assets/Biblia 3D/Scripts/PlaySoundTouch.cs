using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundTouch : MonoBehaviour
{
    public AudioSource DaviSoundTouch;    
    void OnMouseDown()
    {
        if (DaviSoundTouch != null)
        {
            if (!DaviSoundTouch.isPlaying)
            {
                DaviSoundTouch.Play();
                Debug.Log("Ai! fui clicado");
            }
        }
    }
 
   
}
