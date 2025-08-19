using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Serve para trabalhar com o checklist para que possa exibir em caso de as mesmas estarem satisfeitas
 */
namespace Biblia3D.Scene.Checklist
{
    public class CheckItemConfirmBehaviourScript : MonoBehaviour
    {
        public CheckItemScriptableObject checkItemScriptable;
        public bool executeOnStart = false;

        // Start is called before the first frame update
        void Start()
        {
            if (checkItemScriptable != null && executeOnStart)
                checkItemScriptable.Confirm();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Confirm()
        {
            if (checkItemScriptable != null)
                checkItemScriptable.Confirm();
        }
    }
}