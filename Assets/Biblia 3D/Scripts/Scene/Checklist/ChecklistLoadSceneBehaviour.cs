using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Serve para trabalhar com o checklist para que possa exibir em caso de as mesmas estarem satisfeitas
 */
namespace Biblia3D.Scene.Checklist
{
    public class ChecklistLoadSceneBehaviour : MonoBehaviour
    {
        public ChecklistSceneRequest request;
        public System.Action<ChecklistSceneResponse> callback;

        // Start is called before the first frame update
        void Start()
        {
            if (request != null)
            {
                ChecklistSceneComponent.LoadScene(request, callback);
            }

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnDestroy()
        {
            ChecklistSceneComponent.UnloadScene();
        }
    }
}