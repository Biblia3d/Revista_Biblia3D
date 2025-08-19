using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Serve para trabalhar com as scenes
 */
namespace Biblia3D.Scene
{
    /**
     * Serve para poder mudar de scene ao detectar, com o objetivo de simplificar o processo de visualizacao dos dados
     */
    public class SceneChangeTrackableEventHandler : DefaultTrackableEventHandler
    {
        [Header("Informacoes basicas")]
        /**
         * Nome da scene que sera executada
         */
        public SceneChangeScriptableObject sceneChangeScriptableObject = null;

        /**
         * Scene da qual sera usada para realizar o refresh do posicionamento do vuforia, enquanto nao 
         * eh conhecida uma forma de fazer isso no proprio componente
         */
        public SceneChangeScriptableObject sceneChangeScriptableObjectParent = null;

        /**
         * Tempo caso esteja ocioso para reiniciar a scene
         */
        public float waitForSecondsForParent = 2;

        /**
         * Para usar a scene de loading para exibicao de outras informacoes
         */
        public bool showLoadingScene = true;

        /**
         * Objeto de foco para ser exibido caso nao seja encontrado no tracking
         */
        public GameObject foco;

        public bool isChange = false;

        public bool isFound = false;

        private static string sceneLoaded = null;

        private static string lastSceneLoaded = null;

        protected override void OnTrackingFound()
        {
            if (!Loading.LoadingSceneComponent.IsLoaded)
            {
                if (foco != null)
                    foco.SetActive(false);

                if (sceneChangeScriptableObject.sceneName.Equals(sceneLoaded)&& !SceneManager.GetSceneByName("Revista").isLoaded)
                {
                    return;
                }

                SceneRegisterManager.UnloadRegisterScene();

                if (sceneLoaded != null)
                {
                    lastSceneLoaded = sceneLoaded;
                    //SceneManager.UnloadSceneAsync(sceneLoaded, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects); //mexi aqui para testar se resolve o problema de não carregar uma nova ´página da revista
                    Resources.UnloadUnusedAssets();
                }

                sceneLoaded = sceneChangeScriptableObject.sceneName;

                if (!showLoadingScene || (lastSceneLoaded != null && lastSceneLoaded.Equals(sceneLoaded)))
                {
                    if (sceneChangeScriptableObject.loadSceneAsyncAdditive)
                    {
                        SceneManager.LoadSceneAsync(sceneLoaded, LoadSceneMode.Additive);
                    } else
                    {
                        SceneManager.LoadSceneAsync(sceneLoaded);
                    }

                    //GetNextScene(sceneLoaded);

                    //StartCoroutine(AsyncChange(sceneLoaded));
                }
                else
                {
                    lastSceneLoaded = null;
                    Loading.LoadingSceneRequest request = new Loading.LoadingSceneRequest();
                    request.mainCamera = false;
                    request.waitForSeconds = 2;
                    request.sceneChangeScriptableObject = sceneChangeScriptableObject;

                    Loading.LoadingSceneComponent.LoadScene(request, (outcome) => { });
                }

                isChange = true;
                isFound = true;
            }

            base.OnTrackingFound();
        }

        protected override void OnTrackingLost()
        {
            if (!Loading.LoadingSceneComponent.IsLoaded)
            {
                if (sceneChangeScriptableObjectParent == null)
                    return;

                if (sceneLoaded != null)
                {
                    if (sceneLoaded == sceneChangeScriptableObjectParent.sceneName)
                    {
                        return;
                    }

                    if (foco != null)
                        foco.SetActive(true);

                    lastSceneLoaded = sceneLoaded;

                    SceneRegisterManager.UnloadRegisterScene();

                    //SceneManager.UnloadSceneAsync(sceneLoaded, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
                    //Resources.UnloadUnusedAssets();

                    sceneLoaded = null;
                }

                if (isChange && sceneChangeScriptableObjectParent != null && this.gameObject.activeInHierarchy)
                {
                    StartCoroutine(LoadScene());
                }

                isFound = false;
            }

            base.OnTrackingLost();
        }

        IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(waitForSecondsForParent);

            if (isChange && sceneChangeScriptableObjectParent != null && !isFound)
                SceneManager.LoadSceneAsync(sceneChangeScriptableObjectParent.sceneName);
        }
    }
}
