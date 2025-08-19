using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHide : MonoBehaviour
{

    public bool hide;
    public GameObject scrowView;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        if (hide)
        {
            //scrowView.GetComponent<Animator>().SetTrigger("Show");
            scrowView.SetActive(false);
            hide = false;
        }
        else
        {
            scrowView.SetActive(true);
            //scrowView.GetComponent<Animator>().SetTrigger("Hide");
            hide = true;
        }
    }
}
