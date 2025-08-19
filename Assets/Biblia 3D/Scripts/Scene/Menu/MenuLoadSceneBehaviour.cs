using Biblia3D.Scene.Shop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Area de controle de menus para ser usado na scene
 */
namespace Biblia3D.Scene.Menu
{
    public class MenuLoadSceneBehaviour : MonoBehaviour
    {
        public MenuSceneRequest request;
        public ShopSceneRequest shopRequest;
        public System.Action<MenuSceneResponse> callback;
        public System.Action<ShopSceneResponse> shopCallback;

        // Start is called before the first frame update
        void Start()
        {
            if (request != null)
            {
                MenuSceneComponent.LoadScene(request, callback);
                ShopSceneComponent.LoadScene(shopRequest, shopCallback);
            }

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnDestroy()
        {
            MenuSceneComponent.UnloadScene();
            ShopSceneComponent.UnloadScene();
        }
    }
}