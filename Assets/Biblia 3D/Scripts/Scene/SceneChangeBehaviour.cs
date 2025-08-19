using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Serve para trabalhar com as scenes
 */
namespace Biblia3D.Scene
{
    /**
     * Serve para mudar de scene
     */
    public class SceneChangeBehaviour : MonoBehaviour
    {
        /**
         * Inicia a scene com base de uma tela de loading
         */
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

            Loading.LoadingSceneComponent.LoadScene(request, (outcome) => { }, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}