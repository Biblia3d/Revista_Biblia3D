using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Serve para trabalhar com o checklist para que possa exibir em caso de as mesmas estarem satisfeitas
 */
namespace Biblia3D.Scene.Status
{
    public class StatusBehaviourScript : MonoBehaviour
    {
        [Header("Configuracao opcional para forcar uma scene a ser redirecionada")]
        public string scene;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Show()
        {
            StatusSceneRequest request = new StatusSceneRequest();
            if (scene == null || scene.Trim().Equals(""))
            {
                request.sceneNameReturn = SceneManager.GetActiveScene().name;
            } 
            else
            {
                request.sceneNameReturn = scene;
            }
            StatusSceneComponent.LoadScene(request, (outcome) => { });
        }
    }
}