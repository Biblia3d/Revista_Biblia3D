using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

/**
 * Serve para trabalhar com o Tutorial
 */
namespace Biblia3D.Scene.Tutorial
{
    public class VideoBackBehaviourScript : MonoBehaviour
    {
        public VideoPlayer videoPlayer;

        private bool startCheck = false;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(CloseWhenEndVideo());
        }

        // Update is called once per frame
        void Update()
        {
            if (startCheck)
            {
                if (videoPlayer.isPlaying) return;
                string scene = gameObject.scene.name;
                SceneManager.LoadSceneAsync(scene);
            }
        }

        private IEnumerator CloseWhenEndVideo()
        {
            yield return new WaitForSeconds(5f);

            startCheck = true;
        }
    }
}