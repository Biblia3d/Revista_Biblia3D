using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Trabalhar com os recursos da Card
 */
namespace Biblia3D.Scene.Card
{
    public class CardSceneComponent : MonoBehaviour
    {
        private const string SceneName = "Card";

        private static CardSceneRequest loadSceneRegister = null;

        [Header("Informacoes basicas")]
        public CardSceneRequest request = null;

        public Menu.MenuSceneRequest menuSceneRequest;

        public static void LoadScene(CardSceneRequest request, System.Action<CardSceneResponse> callback)
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

        public void EndScene(CardSceneResponse outcome)
        {
            if (request.callback != null) request.callback(outcome);
            request.callback = null;
        }

        // Start is called before the first frame update
        void Start()
        {
            if (menuSceneRequest != null)
            {
                Menu.MenuSceneComponent.LoadScene(menuSceneRequest, (outcome) =>
                {

                });
            }
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
    public class CardSceneRequest
    {
        public System.Action<CardSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
    }

    public class CardSceneResponse
    {

    }
}
