using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Area de controle de menus para ser usado na scene
 */
namespace Biblia3D.Scene.Menu
{
    public class SwitchScrollMenuSceneBehaviour : MonoBehaviour
    {
        public ScrollMenuSceneRequest request;
        public System.Action<ScrollMenuSceneResponse> callback;

        public void SwitchScrollMenu()
        {
            if (request != null)
            {
                if (!ScrollMenuSceneComponent.IsLoaded)
                {
                    ScrollMenuSceneComponent.LoadScene(request, callback);
                }
                else
                {
                    ScrollMenuSceneComponent.CloseSceneLoaded();
                }
            }
        }

        public void CloseScrollMenu()
        {
            if (request != null)
            {
                if (ScrollMenuSceneComponent.IsLoaded)
                {
                    ScrollMenuSceneComponent.CloseSceneLoaded();
                }
            }
        }
    }
}