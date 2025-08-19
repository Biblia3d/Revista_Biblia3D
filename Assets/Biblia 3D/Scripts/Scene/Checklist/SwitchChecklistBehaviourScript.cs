using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameToolkit.Localization;

/**
 * Serve para trabalhar com o checklist para que possa exibir em caso de as mesmas estarem satisfeitas
 */
namespace Biblia3D.Scene.Checklist
{
    public class SwitchChecklistBehaviourScript : MonoBehaviour
    {
        [Header("Informacoes de internacionalizacao")]
        public LocalizedText onLocalizedText;
        public LocalizedText offLocalizedText;

        public GameObject checklist;
        public LocalizedTextBehaviour localizedTextBehaviour;

        // Start is called before the first frame update
        void Start()
        {
            if (checklist != null && checklist.activeSelf && localizedTextBehaviour != null)
            {
                localizedTextBehaviour.LocalizedAsset = offLocalizedText;
            } else if (checklist != null && !checklist.activeSelf && localizedTextBehaviour != null)
            {
                localizedTextBehaviour.LocalizedAsset = onLocalizedText;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SwitchOnClick()
        {
            if (checklist != null && checklist.activeSelf)
            {
                checklist.SetActive(false);

                if (localizedTextBehaviour != null) localizedTextBehaviour.LocalizedAsset = onLocalizedText;
            } else if (checklist != null && !checklist.activeSelf)
            {
                checklist.SetActive(true);

                if (localizedTextBehaviour != null) localizedTextBehaviour.LocalizedAsset = offLocalizedText;
            }
        }
    }
}