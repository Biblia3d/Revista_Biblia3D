using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameToolkit.Localization;

/**
 * Area de controle de loading para ser usado na scene
 */
namespace Biblia3D.Scene.Loading
{
    /**
     * Serve para controle de scene de carregando
     */
    public class LoadingSceneComponent : MonoBehaviour
    {
        private const string SceneName = "Loading";

        private static bool loaded = false;

        public static bool IsLoaded
        {
            get
            {
                return loaded;
            }
        }

        private static LoadingSceneRequest loadSceneRegister = null;

        [Header("Informacoes basicas")]
        public LoadingSceneRequest request = null;
        public string sceneReturnDefault = "Scene";

        [Header("Componentes imutaveis")]
        public Image backgroundImage;
        public GameObject foregroundImage;
        public GameObject smallForegroundImage;
        public GameObject davi;
        public GameObject hand;
        public GameObject info;
        public LocalizedTextBehaviour tips;
        public GameObject text;
        public GameObject centerText;
        public GameObject buttonLoad;
        public GameObject arrow;
        public GameObject page;
        public LocalizedTextBehaviour pageText;
        public AudioSource voice;
        public AudioSource backgroundMusic;
        public GameObject mainCamera;
        public Canvas canvas;

        private AsyncOperation nextScene;

        public static void LoadScene(LoadingSceneRequest request, System.Action<LoadingSceneResponse> callback)
        {
            LoadScene(request, callback, LoadSceneMode.Additive);
        }

        public static void LoadScene(LoadingSceneRequest request, System.Action<LoadingSceneResponse> callback, LoadSceneMode mode)
        {
            loadSceneRegister = request;
            request.callback = callback;

            SceneManager.LoadSceneAsync(SceneName, mode);
            loaded = true;
        }

        public static void CloseSceneLoaded()
        {
            SceneManager.UnloadSceneAsync(SceneName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            loaded = false;
        }

        public void CloseScene()
        {
            StartCoroutine(CloseSceneCourotine());
        }

        /**
         * Serve para poder cancelar e retornar a scene anterior
         */
        public void ReturnScene()
        {
            string sceneName = sceneReturnDefault;
            if (request != null && request.sceneChangeScriptableObject != null && request.sceneChangeScriptableObject.sceneReturn != null && request.sceneChangeScriptableObject.sceneReturn.Trim().Length > 0)
            {
                sceneName = request.sceneChangeScriptableObject.sceneReturn;
            }
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            loaded = false;
        }

        private IEnumerator CloseSceneCourotine()
        {
            yield return new WaitForSeconds(request.waitForSeconds);

            if (nextScene != null)
            {
                nextScene.allowSceneActivation = true;

                nextScene = null;
            }

            SceneManager.UnloadSceneAsync(SceneName);

            loaded = false;
        }

        public void Awake()
        {
            if (loadSceneRegister != null) request = loadSceneRegister;
            loadSceneRegister = null;
        }

        public void EndScene(LoadingSceneResponse outcome)
        {
            if (request.callback != null) request.callback(outcome);
            request.callback = null;
        }

        // Start is called before the first frame update
        void Start()
        {
            if (request != null && request.sceneChangeScriptableObject != null)
            {
                buttonLoad.SetActive(false);
                davi.SetActive(request.sceneChangeScriptableObject.davi3D);
                hand.SetActive(request.sceneChangeScriptableObject.hand);
                backgroundImage.sprite = request.sceneChangeScriptableObject.backgroundLoading;
                backgroundImage.color = request.sceneChangeScriptableObject.backgroundColor;
                foregroundImage.SetActive(request.sceneChangeScriptableObject.foregroundLoading != null);
                foregroundImage.GetComponent<Image>().sprite = request.sceneChangeScriptableObject.foregroundLoading;
                if (request.sceneChangeScriptableObject.foregroundLoadingRight)
                {
                    RectTransform rectTransform = foregroundImage.GetComponent<RectTransform>();
                    rectTransform.offsetMin = new Vector2(320, 0);
                    rectTransform.offsetMax = new Vector2(0, 0);
                }
                smallForegroundImage.GetComponent<Image>().sprite = request.sceneChangeScriptableObject.smallForegroundLoading;
                smallForegroundImage.SetActive(request.sceneChangeScriptableObject.smallForegroundLoading != null);
                centerText.GetComponent<LocalizedTextBehaviour>().LocalizedAsset = request.sceneChangeScriptableObject.centerLocalizedText;
                centerText.SetActive(request.sceneChangeScriptableObject.centerLocalizedText != null);
                info.SetActive(request.sceneChangeScriptableObject.localizedText != null);
                tips.LocalizedAsset = request.sceneChangeScriptableObject.localizedText;
                backgroundMusic.clip = request.sceneChangeScriptableObject.loadingMusic;
                if (request.sceneChangeScriptableObject.localizedAudioClip != null) voice.PlayOneShot(request.sceneChangeScriptableObject.localizedAudioClip);
                page.SetActive(request.sceneChangeScriptableObject.localizedPageText != null);
                pageText.LocalizedAsset = request.sceneChangeScriptableObject.localizedPageText;
                mainCamera.SetActive(request.mainCamera);
                
                if (request.sceneChangeScriptableObject.subtitleScriptableObject != null)
                {
                    Subtitle.SubtitleSceneRequest requestSubtitle = new Subtitle.SubtitleSceneRequest();
                    requestSubtitle.subtitleScriptableObject = request.sceneChangeScriptableObject.subtitleScriptableObject;
                    requestSubtitle.showSubtitle = request.sceneChangeScriptableObject.showSubtitle;
                    Subtitle.SubtitleSceneComponent.LoadScene(requestSubtitle, (outcome) => { });
                }

                if (request.mainCamera == false)
                {
                    canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                }

                StartCoroutine(AsyncChange(request.sceneChangeScriptableObject.sceneName));
            } else
            {
                Debug.LogError("request and sceneChangeScriptableObject are required");
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnDestroy()
        {
            if (Subtitle.SubtitleSceneComponent.IsLoaded) Subtitle.SubtitleSceneComponent.CloseSceneLoaded();
        }

        IEnumerator AsyncChange(string scene)
        {
            //yield return new WaitForSeconds (1);
            nextScene = GetNextScene(scene, request.sceneChangeScriptableObject.loadSceneAsyncAdditive);
            nextScene.allowSceneActivation = false;
            while (nextScene.progress < 0.9f)
            {
                yield return null;
            }

            if (!scene.Equals("Revista"))
                buttonLoad.SetActive(true);
            else
                Invoke("ExecuteNextScene",5f);

            if (scene.Equals("Capa") || scene.Equals("Scene 2"))
            {
                arrow.SetActive(true);
            }
        }

        public void ExecuteNextScene()
        {
            if (nextScene != null)
            {
                nextScene.allowSceneActivation = true;

                nextScene = null;
            }

            SceneManager.UnloadSceneAsync(SceneName);

            loaded = false;
        }

        private static AsyncOperation GetNextScene(string scene, bool additive)
        {
            if (additive)
            {
                return SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            }

            return SceneManager.LoadSceneAsync(scene);
        }
    }

    [System.Serializable]
    public class LoadingSceneRequest
    {
        public System.Action<LoadingSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.1f;
        public bool mainCamera = true;
        public SceneChangeScriptableObject sceneChangeScriptableObject;
    }

    public class LoadingSceneResponse
    {

    }
}
