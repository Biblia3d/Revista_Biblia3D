using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScrollRectBehaviourScript : MonoBehaviour
{
    [Header("Configuracoes")]
    public float count = 0.0001f;
    [Header("Componentes obrigatorios")]
    public ScrollRect scrollRect;

    private bool reverse = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scrollRect != null)
        {
            if (scrollRect.horizontalNormalizedPosition >= 0.99)
            {
                reverse = true;
            }
            else if (scrollRect.horizontalNormalizedPosition <= 0)
            {
                reverse = false;
            }

            if (reverse)
            {
                scrollRect.horizontalNormalizedPosition -= count;
            } else
            {
                scrollRect.horizontalNormalizedPosition += count;
            }
        }
    }
}
