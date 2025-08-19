using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameToolkit.Localization;

/**
 * Serve para exibir as mensagens da licao
 */
namespace Biblia3D.Scene.Lesson
{
    public class LessonSceneComponent : MonoBehaviour
    {
        private const string SceneName = "Lesson";

        private static LessonSceneRequest loadSceneRegister = null;

        [Header("Informacoes basicas")]
        public LessonSceneRequest request = null;

        [Header("Informacoes fixas")]
        public Animator animator;
        public LocalizedTextBehaviour title;
        public LocalizedTextBehaviour description;
        public GameObject descriptionGameObject;

        public static void LoadScene(LessonSceneRequest request, System.Action<LessonSceneResponse> callback)
        {
            try
            {
                SceneManager.UnloadSceneAsync(SceneName);

            }
            catch (Exception e)
            {

            }
            loadSceneRegister = request;
            request.callback = callback;
            SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        }

        public static void UnloadScene()
        {
            try
            {
                SceneManager.UnloadSceneAsync(SceneName);

            }
            catch (Exception e)
            {

            }
        }

        public void CloseScene()
        {
            StartCoroutine(CloseSceneCourotine());
        }

        private IEnumerator CloseSceneCourotine()
        {
            yield return new WaitForSeconds(request.waitForSeconds);

            SceneManager.UnloadSceneAsync(SceneName);
        }

        public void Awake()
        {
            if (loadSceneRegister != null) request = loadSceneRegister;
            loadSceneRegister = null;
        }

        public void EndScene(LessonSceneResponse outcome)
        {
            if (request.callback != null) request.callback(outcome);
            request.callback = null;
        }

        // Start is called before the first frame update
        void Start()
        {
            if (request != null)
            {
                if (title != null) title.LocalizedAsset = request.titleLocalizedText;
                if (description != null) description.LocalizedAsset = request.descriptionLocalizedText;
                if (descriptionGameObject != null) descriptionGameObject.SetActive(false);
                if (animator != null)
                {
                    animator.SetTrigger("Open");
                    if (descriptionGameObject != null) descriptionGameObject.SetActive(request.showDescriptionLocalizedText);
                    Invoke("CloseTip", request.timeToCloseAnimator);
                }
            }
        }

        public void CloseTip()
        {
            animator.SetTrigger("Close");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    [System.Serializable]
    public class LessonSceneRequest
    {
        public System.Action<LessonSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
        public LocalizedText titleLocalizedText;
        public LocalizedText descriptionLocalizedText;
        public bool showDescriptionLocalizedText;
        public float timeToCloseAnimator = 5;
    }

    public class LessonSceneResponse
    {
    }
}