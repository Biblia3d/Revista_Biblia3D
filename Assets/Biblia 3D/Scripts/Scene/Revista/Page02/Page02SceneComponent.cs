using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Trabalhar com os recursos da Pagina 2
 */
namespace Biblia3D.Scene.Revista.Page02
{
    /**
     * Serve para o gerenciamento da scene
     */
    public class Page02SceneComponent : MonoBehaviour
    {
        private const string SceneName = "Scene 2";

        private static Page02SceneRequest loadSceneRegister = null;

        public GameObject buttonRock;

        [Header("Informacoes basicas")]
        public Page02SceneRequest request = null;

        public static void LoadScene(Page02SceneRequest request, System.Action<Page02SceneResponse> callback)
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

        public void EndScene(Page02SceneResponse outcome)
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
            if (PlayerPrefs.GetString("RockMusicEnabled").Equals("true"))
            {
                buttonRock.SetActive(true);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnDestroy()
        {
        }
    }

    [System.Serializable]
    public class Page02SceneRequest
    {
        public System.Action<Page02SceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
    }

    public class Page02SceneResponse
    {

    }
}