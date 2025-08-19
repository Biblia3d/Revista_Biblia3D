using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Serve para trabalhar com as scenes
 */
namespace Biblia3D.Scene
{
    /**
     * Serve para gerenciar as scenes que estao marcadas para serem registradas e serem eliminadas
     */
    public class SceneRegisterManager
    {
        private static Queue<string> queue = new Queue<string>();

        internal static void Register(string scene)
        {
            queue.Enqueue(scene);
        }

        public static void Clear()
        {
            queue.Clear();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void UnloadRegisterScene()
        {
            try {
                foreach (string scene in queue)
                {
                    SceneManager.UnloadSceneAsync(scene, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
                }
            } catch(Exception e)
            {
            }
            queue.Clear();

            Resources.UnloadUnusedAssets();
        }
    }
}