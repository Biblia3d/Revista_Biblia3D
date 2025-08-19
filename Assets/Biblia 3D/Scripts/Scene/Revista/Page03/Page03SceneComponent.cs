using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Trabalhar com os recursos da Pagina 3
 */
namespace Biblia3D.Scene.Revista.Page03
{
    /**
     * Serve para o gerenciamento da scene
     */
    public class Page03SceneComponent : MonoBehaviour
    {
        private const string SceneName = "Scene 3";

        private static Page03SceneRequest loadSceneRegister = null;

        [Header("Informacoes basicas")]
        public Page03SceneRequest request = null;

        public static void LoadScene(Page03SceneRequest request, System.Action<Page03SceneResponse> callback)
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

        public void EndScene(Page03SceneResponse outcome)
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
    public class Page03SceneRequest
    {
        public System.Action<Page03SceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
    }

    public class Page03SceneResponse
    {

    }
}