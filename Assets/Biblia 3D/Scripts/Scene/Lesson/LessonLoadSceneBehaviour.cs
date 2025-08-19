using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Serve para exibir as mensagens da licao
 */
namespace Biblia3D.Scene.Lesson
{
    public class LessonLoadSceneBehaviour : MonoBehaviour
    {
        public LessonSceneRequest request;
        public System.Action<LessonSceneResponse> callback;

        // Start is called before the first frame update
        void Start()
        {
            if (request != null)
            {
                LessonSceneComponent.LoadScene(request, callback);
            }

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnDestroy()
        {
            LessonSceneComponent.UnloadScene();
        }
    }
}