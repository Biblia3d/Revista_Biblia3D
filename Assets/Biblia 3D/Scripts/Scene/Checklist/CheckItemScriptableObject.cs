using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Serve para trabalhar com o checklist para que possa exibir em caso de as mesmas estarem satisfeitas
 */
namespace Biblia3D.Scene.Checklist
{

    [CreateAssetMenu(fileName = "CheckItemData", menuName = "Biblia3D/Check Item Data")]
    public class CheckItemScriptableObject : ScriptableObject
    {
        [Header("Informacoes basicas")] 
        public string check;
        public int greaterThanOrEqualTo = 1;

        public bool IsCheck
        {
            get
            {
                return PlayerPrefs.GetInt(check) >= greaterThanOrEqualTo;
            }
        }

        public void Confirm()
        {
            PlayerPrefs.SetInt(check, 1);
        }
    }
}