using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    public TextMeshProUGUI txtText;


    private void Start()
    {
        SetText();
    }

    public void SetText()
    {
        txtText.SetTextMeshProI18n("btn_upgrade", null, true);
    }
}
