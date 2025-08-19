using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameToolkit.Localization;

/**
 * Serve para trabalhar com o checklist para que possa exibir em caso de as mesmas estarem satisfeitas
 */
namespace Biblia3D.Scene.Checklist
{
    public class ChecklistSceneComponent : MonoBehaviour
    {
        private const string SceneName = "Checklist";

        private static ChecklistSceneRequest loadSceneRegister = null;

        [Header("Informacoes basicas")]
        public ChecklistSceneRequest request = null;

        [Header("Informacoes fixas")]
        public GameObject checklist;
        public GameObject checkbox1;
        public GameObject checkbox2;
        public GameObject checkbox3;
        public GameObject tick1;
        public GameObject tick2;
        public GameObject tick3;
        public LocalizedTextBehaviour text1;
        public LocalizedTextBehaviour text2;
        public LocalizedTextBehaviour text3;
        public GameObject congratulations;

        public bool execute;

        private bool isShowChecklist1 = true;
        private bool isShowChecklist2 = true;
        private bool isShowChecklist3 = true;

        public static void LoadScene(ChecklistSceneRequest request, System.Action<ChecklistSceneResponse> callback)
        {
            try
            {
                SceneManager.UnloadSceneAsync(SceneName);

            }
            catch (Exception e)
            {

            }
            loadSceneRegister = request;
            request.callback = callback;
            SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        }

        public static void UnloadScene()
        {
            try
            {
                SceneManager.UnloadSceneAsync(SceneName);

            } catch (Exception e)
            {

            }
        }

        public void CloseScene()
        {
            StartCoroutine(CloseSceneCourotine());
        }

        private IEnumerator CloseSceneCourotine()
        {
            yield return new WaitForSeconds(request.waitForSeconds);

            SceneManager.UnloadSceneAsync(SceneName);
        }

        public void Awake()
        {
            if (loadSceneRegister != null) request = loadSceneRegister;
            loadSceneRegister = null;
        }

        public void EndScene(ChecklistSceneResponse outcome)
        {
            if (request.callback != null) request.callback(outcome);
            request.callback = null;
        }

        // Start is called before the first frame update
        void Start()
        {
            if (request != null)
            {
                string checks = "";
                string oks = "";
                checkbox1.SetActive(request.check1 != null);
                if (request.check1 != null)
                {
                    text1.LocalizedAsset = request.check1.message;
                    tick1.SetActive(request.check1.IsCheck);
                    checks += "1";
                    if (request.check1.IsCheck)
                    {
                        isShowChecklist1 = false;
                        oks += "1";
                    }
                }

                checkbox2.SetActive(request.check2 != null);
                if (request.check2 != null)
                {
                    text2.LocalizedAsset = request.check2.message;
                    tick2.SetActive(request.check2.IsCheck);
                    checks += "1";
                    if (request.check1.IsCheck)
                    {
                        isShowChecklist2 = false;
                        oks += "1";
                    }
                }

                checkbox3.SetActive(request.check3 != null);
                if (request.check3 != null)
                {
                    text3.LocalizedAsset = request.check3.message;
                    tick3.SetActive(request.check3.IsCheck);
                    checks += "1";
                    if (request.check1.IsCheck)
                    {
                        isShowChecklist3 = false;
                        oks += "1";
                    }
                }

                execute = !checks.Equals(oks);

                //checklist.SetActive(!checks.Equals(""));
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (request != null)
            {
                if (execute)
                {
                    if (isShowChecklist1 && request.check1 != null && request.check1.IsCheck)
                    {
                        checklist.SetActive(true);
                        isShowChecklist1 = false;
                        StartCoroutine(CloseChecklistCourotine());
                    }
                    if (isShowChecklist2 && request.check2 != null && request.check2.IsCheck)
                    {
                        checklist.SetActive(true);
                        isShowChecklist2 = false;
                        StartCoroutine(CloseChecklistCourotine());
                    }
                    if (isShowChecklist3 && request.check3 != null && request.check3.IsCheck)
                    {
                        checklist.SetActive(true);
                        isShowChecklist3 = false;
                        StartCoroutine(CloseChecklistCourotine());
                    }

                    tick1.SetActive(request.check1 != null && request.check1.IsCheck);
                    tick2.SetActive(request.check2 != null && request.check2.IsCheck);
                    tick3.SetActive(request.check3 != null && request.check3.IsCheck);

                    string checks = "";
                    string oks = "";

                    if (checkbox1.activeSelf) checks += "1";
                    if (checkbox2.activeSelf) checks += "1";
                    if (checkbox3.activeSelf) checks += "1";

                    if (tick1.activeSelf) oks += "1";
                    if (tick2.activeSelf) oks += "1";
                    if (tick3.activeSelf) oks += "1";

                    execute = true;

                    congratulations.SetActive(!execute);
                    
                    string number = SceneManager.GetActiveScene().name;
                    PlayerPrefs.SetInt("CompleteScene"+ number.Substring(number.Length-1), 1);
                }
            }
        }

        private IEnumerator CloseChecklistCourotine()
        {
            yield return new WaitForSeconds(request.waitForCloseChecklist);

            if (execute)
            {
                checklist.SetActive(false);
            }
        }
    }

    [System.Serializable]
    public class ChecklistSceneRequest
    {
        public System.Action<ChecklistSceneResponse> callback;
        [Header("Informacoes gerais")]
        public float waitForSeconds = 0.5f;
        public float waitForCloseChecklist = 3;
        public CheckScriptableObject check1;
        public CheckScriptableObject check2;
        public CheckScriptableObject check3;
    }

    public class ChecklistSceneResponse
    {

    }
}