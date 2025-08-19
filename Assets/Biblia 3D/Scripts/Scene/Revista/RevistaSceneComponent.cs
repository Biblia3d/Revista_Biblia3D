using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Trabalhar com os recursos da Revista
 */
namespace Biblia3D.Scene.Revista
{
    public class RevistaSceneComponent : MonoBehaviour
    {
        private const string SceneName = "Revista";

        private static RevistaSceneRequest loadSceneRegister = null;

        [Header("Informacoes basicas")]
        public RevistaSceneRequest request = null;

        public static void LoadScene(RevistaSceneRequest request, System.Action<RevistaSceneResponse> callback)
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

        public void EndScene(RevistaSceneResponse outcome)
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

        void OnDestroy()
        {
            SceneRegisterManager.Clear();
        }
    }

    [System.Serializable]
    public class RevistaSceneRequest
    {
        public System.Action<RevistaSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
    }

    public class RevistaSceneResponse
    {

    }
}
