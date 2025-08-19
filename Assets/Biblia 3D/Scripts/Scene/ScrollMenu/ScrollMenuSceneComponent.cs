using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Area de controle de menus para ser usado na scene
 */
namespace Biblia3D.Scene.Menu
{
    public class ScrollMenuSceneComponent : MonoBehaviour
    {
        private const string SceneName = "ScrollMenu";

        private static bool loaded = false;

        public static bool IsLoaded {
            get
            {
                return loaded;
            }
        }

        private static ScrollMenuSceneRequest loadSceneRegister = null;

        public ScrollMenuSceneRequest request = null;

        public static void LoadScene(ScrollMenuSceneRequest request, System.Action<ScrollMenuSceneResponse> callback)
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

        public void EndScene(ScrollMenuSceneResponse outcome)
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
            loaded = false;
        }
    }

    [System.Serializable]
    public class ScrollMenuSceneRequest
    {
        public System.Action<ScrollMenuSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
    }

    public class ScrollMenuSceneResponse
    {

    }
}