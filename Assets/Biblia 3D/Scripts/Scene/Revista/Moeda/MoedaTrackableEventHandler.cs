using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Trabalhar com os recursos da Moeda
 */
namespace Biblia3D.Scene.Revista.Moeda
{
    public class MoedaTrackableEventHandler : DefaultTrackableEventHandler
    {

        /**
         * Tempo caso esteja ocioso para reiniciar a scene
         */
        public float waitForSecondsForParent = 2;

        public MoedaSceneRequest request;

        //private bool sceneLoaded = false;

        protected override void OnTrackingFound()
        {
            //if (sceneLoaded)
            //    return;

            MoedaSceneComponent.LoadScene(request, (response) => { });
            //sceneLoaded = true;
        }

        protected override void OnTrackingLost()
        {
            MoedaSceneComponent.UnloadScene();
            /*if (!sceneLoaded)
                return;

            SceneRegisterManager.UnloadRegisterScene();*/
        }
    }
}