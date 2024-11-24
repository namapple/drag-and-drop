using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using I2.Loc;
using TMPro;

public class I18nManager : SingletonPersistent<I18nManager>
{

    public string GetCurrentLanguage()
    {
        return I2.Loc.LocalizationManager.CurrentLanguage;
    }

    public void ChangeLanguage(string NewLanguage)
    {
        I2.Loc.LocalizationManager.CurrentLanguage = NewLanguage;
    }

    public string GetTextI18n(string term, Dictionary<string, string> paramValues = null)
    {

        string termText = I2.Loc.LocalizationManager.GetTranslation(term);
        if (string.IsNullOrEmpty(termText))
        {
            return term;
        }

        if (paramValues != null && paramValues.Count > 0)
        {
            foreach (string key in paramValues.Keys)
            {
                termText = termText.Replace("{[" + key + "]}", paramValues[key]);
            }
        }
        return termText;
    }

    public bool CheckTermExist(string term)
    {
        return I2.Loc.LocalizationManager.GetTermData(term) != null;
    }

    public void SetLabelTerm(Text label, string newTerm, Dictionary<string, string> paramValues = null, bool disableBestFit = false)
    {
        bool termExisted = false;
        if (!string.IsNullOrEmpty(newTerm))
        {
            termExisted = CheckTermExist(newTerm);
        }
        Localize localize = label.GetComponent<I2.Loc.Localize>();

        if (!termExisted)
        {
            if (!string.IsNullOrEmpty(newTerm))
            {
                Debug.LogError("Term not Existed : " + newTerm);
            }
            if (localize != null)
            {
                Destroy(localize);
            }
            label.text = newTerm;
            return;
        }

        if (localize == null)
        {
            localize = label.gameObject.AddComponent<I2.Loc.Localize>();
        }

        localize.DisableBestFit = disableBestFit;

        localize.SetTerm(newTerm);

        if (paramValues == null || paramValues.Count == 0)
        {
            return;
        }

        var paramsComponent = label.GetComponent<LocalizationParamsManager>();
        if (paramsComponent == null)
        {
            paramsComponent = label.gameObject.AddComponent<I2.Loc.LocalizationParamsManager>();
        }

        foreach (string key in paramValues.Keys)
        {
            paramsComponent.SetParameterValue(key, paramValues[key]);
        }
    }

    public void SetLabelTermTMP(TextMeshProUGUI label, string newTerm, Dictionary<string, string> paramValues = null, bool disableBestFit = false)
    {
        bool termExisted = false;
        if (!string.IsNullOrEmpty(newTerm))
        {
            termExisted = CheckTermExist(newTerm);
        }
        Localize localize = label.GetComponent<I2.Loc.Localize>();

        if (!termExisted)
        {
            if (!string.IsNullOrEmpty(newTerm))
            {
                Debug.LogError("Term not Existed : " + newTerm);
            }
            if (localize != null)
            {
                Destroy(localize);
            }
            label.text = newTerm;
            return;
        }

        if (localize == null)
        {
            localize = label.gameObject.AddComponent<I2.Loc.Localize>();
        }

        localize.DisableBestFit = disableBestFit;

        localize.SetTerm(newTerm);

        if (paramValues == null || paramValues.Count == 0)
        {
            return;
        }

        var paramsComponent = label.GetComponent<LocalizationParamsManager>();
        if (paramsComponent == null)
        {
            paramsComponent = label.gameObject.AddComponent<I2.Loc.LocalizationParamsManager>();
        }

        foreach (string key in paramValues.Keys)
        {
            paramsComponent.SetParameterValue(key, paramValues[key]);
        }
    }

}
