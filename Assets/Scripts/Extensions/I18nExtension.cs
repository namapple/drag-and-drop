using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public static class I18nExtension
{
    public static void SetTextI18n(this Text label, string key, Dictionary<string, string> paramValues = null, bool disableBestFit = false)
    {
        SingletonPersistent<I18nManager>.Instance.SetLabelTerm(label, key, paramValues, disableBestFit);
    }

    public static string GetTextI18n(this string term, Dictionary<string, string> paramValues = null)
    {
        return SingletonPersistent<I18nManager>.Instance.GetTextI18n(term, paramValues);
    }
    
    public static void SetTextNumber(this Text label, int number)
    {
        string key = "empty_i2";
        Dictionary<string, string> paramValues = new Dictionary<string, string>();
        paramValues["VALUE"] = number+"";
        SingletonPersistent<I18nManager>.Instance.SetLabelTerm(label, key, paramValues, false);
    }
    public static void SetTextString(this Text label, string value)
    {
        string key = "empty_i2";
        Dictionary<string, string> paramValues = new Dictionary<string, string>();
        paramValues["VALUE"] = value;
        SingletonPersistent<I18nManager>.Instance.SetLabelTerm(label, key, paramValues, false);
    }
    
    public static void SetTextMeshProI18n(this TextMeshProUGUI label, string key, Dictionary<string, string> paramValues = null, bool disableBestFit = false)
    {
        SingletonPersistent<I18nManager>.Instance.SetLabelTermTMP(label, key, paramValues, disableBestFit);
    }
}