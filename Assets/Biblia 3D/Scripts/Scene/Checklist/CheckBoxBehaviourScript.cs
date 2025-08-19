using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameToolkit.Localization;

/**
 * Serve para trabalhar com o checklist para que possa exibir em caso de as mesmas estarem satisfeitas
 */
namespace Biblia3D.Scene.Checklist
{
    public class CheckBoxBehaviourScript : MonoBehaviour
    {
        [Header("Informacoes necessarias")]
        public CheckScriptableObject checkScriptableObject;

        [Header("Informacoes fixas")]
        public GameObject check;
        public LocalizedTextBehaviour localizedTextBehaviour;

        // Start is called before the first frame update
        void Start()
        {
            if (localizedTextBehaviour != null && checkScriptableObject != null)
            {
                localizedTextBehaviour.LocalizedAsset = checkScriptableObject.message;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (check != null && checkScriptableObject)
            {
                check.SetActive(checkScriptableObject.IsCheck);
            }
        }
    }
}