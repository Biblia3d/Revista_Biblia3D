using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Area de controle de menus para ser usado na scene
 */
namespace Biblia3D.Scene.Menu
{
    public class ScrollMenuLoadSceneBehaviour : MonoBehaviour
    {
        public ScrollMenuSceneRequest request;
        public System.Action<ScrollMenuSceneResponse> callback;

        // Start is called before the first frame update
        void Start()
        {
            if (request != null)
            {
                ScrollMenuSceneComponent.LoadScene(request, callback);
            }

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnDestroy()
        {
            ScrollMenuSceneComponent.UnloadScene();
        }
    }
}