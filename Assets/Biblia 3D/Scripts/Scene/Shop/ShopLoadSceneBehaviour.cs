using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Area de controle de menus para ser usado na scene
 */
namespace Biblia3D.Scene.Shop
{
    public class ShopLoadSceneBehaviour : MonoBehaviour
    {
        public ShopSceneRequest request;
        public System.Action<ShopSceneResponse> callback;

        // Start is called before the first frame update
        void Start()
        {
            if (request != null)
            {
                //ShopSceneComponent.LoadScene(request, callback);
            }

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnDestroy()
        {
            ShopSceneComponent.UnloadScene();
        }
    }
}