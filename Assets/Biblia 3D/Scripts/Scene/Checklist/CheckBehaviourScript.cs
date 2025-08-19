using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Serve para trabalhar com o checklist para que possa exibir em caso de as mesmas estarem satisfeitas
 */
namespace Biblia3D.Scene.Checklist
{
    /**
     * Confirma o check na execucao
     */
    public class CheckBehaviourScript : MonoBehaviour
    {
        public CheckItemScriptableObject checkItemScriptableObject;
        public bool confirmOnStart = true;

        // Start is called before the first frame update
        void Start()
        {
            if (confirmOnStart) Confirm();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Confirm()
        {
            if (checkItemScriptableObject != null)
            {
                checkItemScriptableObject.Confirm();
            }
        }
    }
}