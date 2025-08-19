using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Trabalhar com os recursos da Capa
 */
namespace Biblia3D.Scene.Revista.Capa
{
    /**
     * Serve para o gerenciamento da scene
     */
    public class CapaSceneComponent : MonoBehaviour
    {
        private const string SceneName = "Capa";

        private static CapaSceneRequest loadSceneRegister = null;

        [Header("Informacoes basicas")]
        public CapaSceneRequest request = null;

        public static void LoadScene(CapaSceneRequest request, System.Action<CapaSceneResponse> callback)
        {
            loadSceneRegister = request;
            request.callback = callback;
            SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
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

        public void EndScene(CapaSceneResponse outcome)
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
    public class CapaSceneRequest
    {
        public System.Action<CapaSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
    }

    public class CapaSceneResponse
    {

    }
}