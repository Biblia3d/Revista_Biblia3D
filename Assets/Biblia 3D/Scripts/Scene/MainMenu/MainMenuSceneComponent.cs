using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Para o menu principal do jogo que tras consigo as funcoes para poder
 * relacionar alguns outros recursos
 */
namespace Biblia3D.Scene.MainMenu
{
    /**
     * Serve para gerenciamento das informacoes da scene
     */
    public class MainMenuSceneComponent : MonoBehaviour
    {
        private const string SceneName = "Scene";

        private static bool loaded = false;

        public static bool IsLoaded
        {
            get
            {
                return loaded;
            }
        }

        private static MainMenuSceneRequest loadSceneRegister = null;

        public MainMenuSceneRequest request = null;

        public static void LoadScene(MainMenuSceneRequest request, System.Action<MainMenuSceneResponse> callback)
        {
            loadSceneRegister = request;
            request.callback = callback;
            SceneManager.LoadSceneAsync(SceneName);
            loaded = true;
        }

        public static void CloseSceneLoaded()
        {
            SceneManager.UnloadSceneAsync(SceneName);
            loaded = false;
        }

        public static UnityEngine.SceneManagement.Scene GetScene()
        {
            return SceneManager.GetSceneByName(SceneName);
        }

        public void CloseScene()
        {
            StartCoroutine(CloseSceneCourotine());
        }

        private IEnumerator CloseSceneCourotine()
        {
            yield return new WaitForSeconds(request.waitForSeconds);

            SceneManager.UnloadSceneAsync(SceneName);

            loaded = false;
        }

        public void Awake()
        {
            if (loadSceneRegister != null) request = loadSceneRegister;
            loadSceneRegister = null;
        }

        public void EndScene(MainMenuSceneResponse outcome)
        {
            if (request.callback != null) request.callback(outcome);
            request.callback = null;
        }

        public void StartLoadingScene(SceneChangeScriptableObject sceneChangeScriptableObject)
        {
            if (sceneChangeScriptableObject != null)
            {
                Loading.LoadingSceneRequest request = new Loading.LoadingSceneRequest();
                request.waitForSeconds = 2;
                request.sceneChangeScriptableObject = sceneChangeScriptableObject;

                StartCoroutine(StartLoadingSceneCourotine(request));
            }
        }

        private IEnumerator StartLoadingSceneCourotine(Loading.LoadingSceneRequest request)
        {
            yield return new WaitForSeconds(request.waitForSeconds);

            Loading.LoadingSceneComponent.LoadScene(request, (outcome) => { }, LoadSceneMode.Single);

            loaded = false;
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
    public class MainMenuSceneRequest
    {
        public System.Action<MainMenuSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
    }

    public class MainMenuSceneResponse
    {

    }
}
