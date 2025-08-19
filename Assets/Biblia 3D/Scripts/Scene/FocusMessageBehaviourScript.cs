using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameToolkit.Localization;
using Biblia3D.Scene.Subtitle;

/**
 * Serve para trabalhar com as scenes
 */
namespace Biblia3D.Scene
{
    public class FocusMessageBehaviourScript : MonoBehaviour
    {
        [Header("Informacoes Basicas")]
        public SubtitleScriptableObject[] subtitleScriptableObjects;
        private SubtitleScriptableObject subtitleScriptableObject;
        public LocalizedText localizedText;
        public float waitForSeconds = 10;

        [Header("Informacoes Fixas")]
        public LocalizedTextBehaviour localizedTextBehaviour;

        private bool isRefresh = false;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        void OnEnable()
        {
            isRefresh = true;

            if (SubtitleSceneComponent.IsLoaded)
                SubtitleSceneComponent.CloseSceneLoaded();

            StartCoroutine(Refresh());
        }

        IEnumerator Refresh()
        {
            yield return new WaitForSeconds(waitForSeconds);

            if (this.localizedTextBehaviour != null && this.localizedText != null)
            {
                this.localizedTextBehaviour.LocalizedAsset = this.localizedText;
            }

            if (!SubtitleSceneComponent.IsLoaded && this.subtitleScriptableObjects != null)
            {
                bool choice = false;
                bool restart = false;
                foreach(SubtitleScriptableObject subtitleScriptableObject in this.subtitleScriptableObjects)
                {
                    restart = false;
                    if (choice)
                    {
                        this.subtitleScriptableObject = subtitleScriptableObject;
                        break;
                    }
                    if (subtitleScriptableObject == this.subtitleScriptableObject)
                    {
                        choice = true;
                        restart = true;
                        continue;
                    }
                }

                if (this.subtitleScriptableObjects.Length > 0 && (!choice || restart))
                {
                    this.subtitleScriptableObject = this.subtitleScriptableObjects[0];
                }

                if (this.subtitleScriptableObject != null)
                {
                    SubtitleSceneRequest subtitleSceneRequest = new SubtitleSceneRequest();
                    subtitleSceneRequest.subtitleScriptableObject = this.subtitleScriptableObject;
                    SubtitleSceneComponent.LoadScene(subtitleSceneRequest, (outcome) => { });
                }
            }

            if (isRefresh)
                StartCoroutine(Refresh());
        }
    }
}