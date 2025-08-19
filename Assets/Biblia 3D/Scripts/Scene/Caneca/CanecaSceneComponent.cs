using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Biblia3D.Scene.Caneca
{
    public class CanecaSceneComponent : MonoBehaviour
    {
        private const string SceneName = "Caneca";

        private static CanecaSceneRequest loadSceneRegister = null;

        [Header("Informacoes basicas")]
        public CanecaSceneRequest request = null;

        public Menu.MenuSceneRequest menuSceneRequest;

        public static void LoadScene(CanecaSceneRequest request, System.Action<CanecaSceneResponse> callback)
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

        public void EndScene(CanecaSceneResponse outcome)
        {
            if (request.callback != null) request.callback(outcome);
            request.callback = null;
        }

        // Start is called before the first frame update
        void Start()
        {
            if (menuSceneRequest != null)
            {
                Menu.MenuSceneComponent.LoadScene(menuSceneRequest, (outcome) =>
                {

                });
            }
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
    public class CanecaSceneRequest
    {
        public System.Action<CanecaSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
    }

    public class CanecaSceneResponse
    {

    }
}