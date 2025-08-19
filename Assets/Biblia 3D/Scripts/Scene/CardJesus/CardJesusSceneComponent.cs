using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Trabalhar com os recursos da Capa
 */
namespace Biblia3D.Scene.CardJesus
{
    public class CardJesusSceneComponent : MonoBehaviour
    {
        private const string SceneName = "Card Jesus";

        private static CardJesusSceneRequest loadSceneRegister = null;

        [Header("Informacoes basicas")]
        public CardJesusSceneRequest request = null;

        public Menu.MenuSceneRequest menuSceneRequest;

        public static void LoadScene(CardJesusSceneRequest request, System.Action<CardJesusSceneResponse> callback)
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

        public void EndScene(CardJesusSceneResponse outcome)
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
    public class CardJesusSceneRequest
    {
        public System.Action<CardJesusSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
    }

    public class CardJesusSceneResponse
    {

    }
}