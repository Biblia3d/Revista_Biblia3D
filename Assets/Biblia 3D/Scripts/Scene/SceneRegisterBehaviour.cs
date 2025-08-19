using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Serve para trabalhar com as scenes
 */
namespace Biblia3D.Scene
{
    /**
     * Registra a scene que fora carregada para posteriormente remover
     * Esta classe foi criada com o fim de evitar problema de scenes
     * duplicadas caso se queira que sejam unicas
     */
    public class SceneRegisterBehaviour : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SceneRegisterManager.Register(this.gameObject.scene.name);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}