using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameToolkit.Localization;

/**
 * Serve para trabalhar com as scenes
 */
namespace Biblia3D.Scene
{
    [CreateAssetMenu(fileName = "SceneChangeData", menuName = "Biblia3D/Scene Change Data")]
    public class SceneChangeScriptableObject : ScriptableObject
    {
        [Header("Informacoes basicas")]
        public string sceneName;

        [Header("Informacoes do Loading")]
        public string sceneReturn;
        public Sprite backgroundLoading;
        public Color backgroundColor = Color.white;
        public bool foregroundLoadingRight;
        public Sprite foregroundLoading;
        public Sprite smallForegroundLoading;
        public LocalizedText localizedPageText;
        public LocalizedText localizedText;
        public LocalizedText centerLocalizedText;
        public LocalizedAudioClip localizedAudioClip;
        public Subtitle.SubtitleScriptableObject subtitleScriptableObject;
        public AudioClip loadingMusic;
        public bool davi3D;
        public bool hand;
        public bool loadSceneAsyncAdditive;
        public bool showSubtitle = true;
    }
}