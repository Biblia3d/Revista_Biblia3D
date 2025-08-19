using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameToolkit.Localization;

public class TranslateChange : MonoBehaviour {

    public GameObject br, usa, br1, usa1;
   
    public void Br()
    {
        PlayerPrefs.SetString("Language", "Portuguese");
        Localization.Instance.CurrentLanguage = LocalizationSettings.Instance.AvailableLanguages[0];

    }
    public void Usa()
    {
        PlayerPrefs.SetString("Language", "English");
        Localization.Instance.CurrentLanguage = LocalizationSettings.Instance.AvailableLanguages[1];
    }

    private void Update()
    {
        if (LocalizationSettings.Instance.AvailableLanguages.IndexOf(Localization.Instance.CurrentLanguage) == 0/*PlayerPrefs.GetString("Language")=="Portuguese"*/)
        {
            br.SetActive(true);
            usa.SetActive(false);
            br1.SetActive(false);
            usa1.SetActive(true);

        }else
        {
            br.SetActive(false);
            usa.SetActive(true);
            br1.SetActive(true);
            usa1.SetActive(false);

        }
    }
}
