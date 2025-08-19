using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Area de controle de menus para ser usado na scene
 */
namespace Biblia3D.Scene.Menu
{
    public class MenuSceneComponent : MonoBehaviour
    {
        private const string SceneName = "Menu";
        
        private static bool loaded = false;

        [Header("Informacoes fixas")]
        public GameObject exit;
        public GameObject clearProgress;
        public GameObject mute;
        public GameObject card;
        public GameObject revista;
        public GameObject stats;
        public GameObject loja;

        public GameObject goToButton;

        public static bool IsLoaded
        {
            get
            {
                return loaded;
            }
        }

        private static MenuSceneRequest loadSceneRegister = null;

        public MenuSceneRequest request = null;

        public static void LoadScene(MenuSceneRequest request, System.Action<MenuSceneResponse> callback)
        {
            loadSceneRegister = request;
            request.callback = callback;
            SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
            loaded = true;
        }

        public static void UnloadScene()
        {
            SceneManager.UnloadSceneAsync(SceneName);
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

        public void EndScene(MenuSceneResponse outcome)
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
                if (exit != null) exit.SetActive(request.showExit);
                if (clearProgress != null) clearProgress.SetActive(request.showClearProgress);
                if (mute != null) mute.SetActive(request.showMute);
                if (card != null) card.SetActive(request.showCard);
                if (revista != null) revista.SetActive(request.showRevista);
                if (stats != null) stats.SetActive(request.showStats);
                if (loja != null) loja.SetActive(request.showLoja);
                if (goToButton != null) goToButton.SetActive(request.showGoToButton);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    [System.Serializable]
    public class MenuSceneRequest
    {
        public System.Action<MenuSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
        public bool showExit = true;
        public bool showClearProgress = true;
        public bool showMute = true;
        public bool showCard = true;
        public bool showRevista = true;
        public bool showStats = true;
        public bool showLoja = true;
        public bool showGoToButton = true;
    }

    public class MenuSceneResponse
    {

    }

}
