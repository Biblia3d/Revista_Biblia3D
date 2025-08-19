using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Trabalhar com os recursos da Moeda
 */
namespace Biblia3D.Scene.Revista.Moeda
{
    public class MoedaSceneComponent : MonoBehaviour
    {
        private const string SceneName = "Moeda";

        public static bool loaded = false;

        private static MoedaSceneRequest loadSceneRegister = null;

        [Header("Informacoes basicas")]
        public MoedaSceneRequest request = null;

        public static void LoadScene(MoedaSceneRequest request, System.Action<MoedaSceneResponse> callback)
        {
            if (loaded)
                return;

            loaded = true;
            loadSceneRegister = request;
            request.callback = callback;
            SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        }

        public static void UnloadScene()
        {
            if (!loaded)
                return;

            loaded = false;
            SceneManager.UnloadSceneAsync(SceneName);
        }

        public void CloseScene()
        {
            StartCoroutine(CloseSceneCourotine());
        }

        private IEnumerator CloseSceneCourotine()
        {
            yield return new WaitForSeconds(request.waitForSeconds);

            loaded = false;
            SceneManager.UnloadSceneAsync(SceneName);
        }

        public void Awake()
        {
            if (loadSceneRegister != null) request = loadSceneRegister;
            loadSceneRegister = null;
        }

        public void EndScene(MoedaSceneResponse outcome)
        {
            if (request.callback != null) request.callback(outcome);
            request.callback = null;
        }

        // Start is called before the first frame update
        void Start()
        {
            if (request != null)
            {
                int moedas = PlayerPrefs.GetInt("moedas", 0);
                moedas += request.quantidade;
                PlayerPrefs.SetInt("moedas", moedas);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    [System.Serializable]
    public class MoedaSceneRequest
    {
        public System.Action<MoedaSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
        public int quantidade;
    }

    public class MoedaSceneResponse
    {

    }
}
