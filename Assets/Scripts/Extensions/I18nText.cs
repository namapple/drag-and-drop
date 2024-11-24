using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum KVValueType {
    INT,
    FLOAT,
    STRING
}

[System.Serializable]
public class KeyValueObj {
    public string key;
    public string value;

    public KVValueType type;
    
}

public class I18nText : MonoBehaviour
{
    public string key;
    public List<KeyValueObj> i18n_params;

    public Dictionary<string, string> ListToDict(List<KeyValueObj> xi18n_params) {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        foreach (KeyValueObj kv in xi18n_params) {
            dict[kv.key] = kv.value;
        }
        return dict;
    }

    void Start()
    {
      SingletonPersistent<I18nManager>.Instance.SetLabelTerm(gameObject.GetComponent<Text>(), key, ListToDict(i18n_params));
    }
}
