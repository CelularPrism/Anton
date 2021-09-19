using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocalizerUI : MonoBehaviour
{
    TextMeshProUGUI textField;

    public string key;

    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
        string value = LocalizationSystem
    }
}
