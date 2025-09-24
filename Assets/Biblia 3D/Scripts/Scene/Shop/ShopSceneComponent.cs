using Biblia3D.Scene.Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Serve para trabalhar com o checklist para que possa exibir em caso de as mesmas estarem satisfeitas
 */
namespace Biblia3D.Scene.Shop
{
    public class ShopSceneComponent : MonoBehaviour
    {
        private const string SceneName = "Shop";

        private static ShopSceneRequest loadSceneRegister = null;

        [Header("Informacoes basicas")]
        public ShopSceneRequest request = null;

        public static void LoadScene(ShopSceneRequest request, System.Action<ShopSceneResponse> callback)
        {
            loadSceneRegister = request;
            request.callback = callback;
           // SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        }

        
        public static void UnloadScene()
        {
            string sceneNameToUnload = "Shop"; // nome da Scene da loja
            if (UnityEngine.SceneManagement.SceneManager.GetSceneByName(sceneNameToUnload).isLoaded)
            {
                UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneNameToUnload);
            }
            else
            {
                Debug.LogWarning($"A cena '{sceneNameToUnload}' não está carregada e não pode ser descarregada.");
            }
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

        public void EndScene(ShopSceneResponse outcome)
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

        public void ClearAll()
        {
            PlayerPrefs.DeleteAll();
        }

        public void Exit()
        {
            if (request != null && request.sceneNameReturn != null)
            {
                SceneManager.LoadScene(request.sceneNameReturn);
            }
        }
    }

    [System.Serializable]
    public class ShopSceneRequest
    {
        public System.Action<ShopSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
        public string sceneNameReturn;
    }

    public class ShopSceneResponse
    {

    }
}