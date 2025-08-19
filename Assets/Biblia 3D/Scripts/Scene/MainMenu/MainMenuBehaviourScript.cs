using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Para o menu principal do jogo que tras consigo as funcoes para poder
 * relacionar alguns outros recursos
 */
namespace Biblia3D.Scene.MainMenu
{
    public class MainMenuBehaviourScript : MonoBehaviour
    {
        public MainMenuSceneRequest request;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LoadScene()
        {
            MainMenuSceneComponent.LoadScene(request, (outcome) => { });
        }
    }
}