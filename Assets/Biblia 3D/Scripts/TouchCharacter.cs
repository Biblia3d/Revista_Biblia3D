using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCharacter : MonoBehaviour {
    private Animator anim;
    [Tooltip("Luz de Jesus")]
    public GameObject light;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Touch();
	}

    void Touch()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == this.gameObject.name)
                    anim.SetTrigger("Change");
                if (hit.collider.name == "Jesus")
                    EnableLight();
            }
        }
    }
    public void PlaySound(string clipName)
    {
        Sound_Manager.Instance.PlayOneShot(clipName);
    }
    public void StopSound()
    {
        Sound_Manager.Instance.GetComponent<AudioSource>().Stop();
    }

    void EnableLight()
    {
        light.SetActive(true);
    }
}
