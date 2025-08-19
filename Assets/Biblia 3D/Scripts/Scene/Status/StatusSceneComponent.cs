using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Serve para trabalhar com o checklist para que possa exibir em caso de as mesmas estarem satisfeitas
 */
namespace Biblia3D.Scene.Status
{
    public class StatusSceneComponent : MonoBehaviour
    {
        private const string SceneName = "Status";

        private static StatusSceneRequest loadSceneRegister = null;

        [Header("Informacoes basicas")]
        public StatusSceneRequest request = null;

        public static void LoadScene(StatusSceneRequest request, System.Action<StatusSceneResponse> callback)
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

        public void EndScene(StatusSceneResponse outcome)
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

        public void ClearAll()
        {
            PlayerPrefs.DeleteAll();
        }

        public void Exit()
        {
            if (request != null && request.sceneNameReturn != null)
            {
                SceneManager.LoadScene(request.sceneNameReturn);
            }
        }
    }

    [System.Serializable]
    public class StatusSceneRequest
    {
        public System.Action<StatusSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
        public string sceneNameReturn;
    }

    public class StatusSceneResponse
    {

    }
}