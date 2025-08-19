using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Serve para trabalhar com o Tutorial
 */
namespace Biblia3D.Scene.Tutorial
{
    public class TutorialSceneComponent : MonoBehaviour
    {
        private const string SceneName = "Tutorial";

        private static TutorialSceneRequest loadSceneRegister = null;

        [Header("Informacoes basicas")]
        public TutorialSceneRequest request = null;

        public static void LoadScene(TutorialSceneRequest request, System.Action<TutorialSceneResponse> callback)
        {
            loadSceneRegister = request;
            request.callback = callback;
            SceneManager.LoadScene(SceneName);
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

        public void EndScene(TutorialSceneResponse outcome)
        {
            if (request.callback != null) request.callback(outcome);
            request.callback = null;
        }

        // Start is called before the first frame update
        void Start()
        {
            if (request != null)
            {

            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    [System.Serializable]
    public class TutorialSceneRequest
    {
        public System.Action<TutorialSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
    }

    public class TutorialSceneResponse
    {

    }
}