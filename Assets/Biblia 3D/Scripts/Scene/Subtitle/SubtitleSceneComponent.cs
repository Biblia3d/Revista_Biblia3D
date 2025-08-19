using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameToolkit.Localization;
using Simple.SRT;

namespace Biblia3D.Scene.Subtitle
{
    public class SubtitleSceneComponent : MonoBehaviour
    {
        private const string SceneName = "Subtitle";

        private static bool loaded = false;

        [Header("Informacoes fixas")]
        public LocalizedTextAssetBehaviour LocalizedTextAssetBehaviour;
        public LocalizedAudioClipBehaviour LocalizedAudioClipBehaviour;
        public GameObject SubtitleDisplayerGameObject;
        public GameObject AudioSourceGameObject;
        public AudioSource AudioSource;

        public static bool IsLoaded
        {
            get
            {
                return loaded;
            }
        }

        private static SubtitleSceneRequest loadSceneRegister = null;

        public SubtitleSceneRequest request = null;

        public static void LoadScene(SubtitleSceneRequest request, System.Action<SubtitleSceneResponse> callback)
        {
            loadSceneRegister = request;
            request.callback = callback;
            SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
            loaded = true;
        }

        public static void UnloadScene()
        {
            SceneManager.UnloadSceneAsync(SceneName);
        }

        public static void CloseSceneLoaded()
        {
            SceneManager.UnloadSceneAsync(SceneName);
            loaded = false;
        }

        public static UnityEngine.SceneManagement.Scene GetScene()
        {
            return SceneManager.GetSceneByName(SceneName);
        }

        public void CloseScene()
        {
            StartCoroutine(CloseSceneCourotine());
        }

        private IEnumerator CloseSceneCourotine()
        {
            yield return new WaitForSeconds(request.waitForSeconds);

            SceneManager.UnloadSceneAsync(SceneName);

            loaded = false;
        }

        public void Awake()
        {
            if (loadSceneRegister != null) request = loadSceneRegister;
            loadSceneRegister = null;
        }

        public void EndScene(SubtitleSceneResponse outcome)
        {
            if (request.callback != null) request.callback(outcome);
            request.callback = null;
        }

        // Start is called before the first frame update
        void Start()
        {
            if (request != null)
            {
                if (request.subtitleScriptableObject != null)
                {
                    if (LocalizedAudioClipBehaviour != null) LocalizedAudioClipBehaviour.LocalizedAsset = request.subtitleScriptableObject.localizedAudioClip;
                    if (LocalizedTextAssetBehaviour != null) LocalizedTextAssetBehaviour.LocalizedAsset = request.subtitleScriptableObject.localizedTextAsset;
                    if (SubtitleDisplayerGameObject != null && request.subtitleScriptableObject.localizedTextAsset != null && request.showSubtitle) SubtitleDisplayerGameObject.SetActive(true);
                    if (AudioSourceGameObject != null && request.subtitleScriptableObject.localizedAudioClip != null) AudioSourceGameObject.SetActive(true);
                    if (AudioSource != null && request.subtitleScriptableObject.localizedAudioClip != null) AudioSource.Play();
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (AudioSource != null && !AudioSource.isPlaying) CloseScene(); 
        }
    }

    [System.Serializable]
    public class SubtitleSceneRequest
    {
        public System.Action<SubtitleSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
        public SubtitleScriptableObject subtitleScriptableObject;
        public bool showSubtitle = true;
    }

    public class SubtitleSceneResponse
    {

    }
}