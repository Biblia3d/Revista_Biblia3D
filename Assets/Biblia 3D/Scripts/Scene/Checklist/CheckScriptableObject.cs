using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameToolkit.Localization;

/**
 * Serve para trabalhar com o checklist para que possa exibir em caso de as mesmas estarem satisfeitas
 */
namespace Biblia3D.Scene.Checklist
{
    [CreateAssetMenu(fileName = "CheckData", menuName = "Biblia3D/Check Data")]
    public class CheckScriptableObject : ScriptableObject
    {
        [Header("Informacoes basicas")]
        public CheckItemScriptableObject[] checkItemScriptableObjects;
        public int score = 10;
        public LocalizedText message;

        public bool IsCheck
        {
            get
            {
                foreach (CheckItemScriptableObject item in checkItemScriptableObjects)
                {
                    if (!item.IsCheck) return false;
                }

                return true;
            }
        }
    }
}