using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameToolkit.Localization;

namespace Biblia3D.Scene.Subtitle
{
    [CreateAssetMenu(fileName = "SubtitleData", menuName = "Biblia3D/Subtitle Data")]
    public class SubtitleScriptableObject : ScriptableObject
    {
        [Header("Informacoes basicas")]
        public LocalizedAudioClip localizedAudioClip;
        public LocalizedTextAsset localizedTextAsset;
    }
}