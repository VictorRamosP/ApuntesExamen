using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    public static HealthText Instance;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = "0";
    }

    public void ShowResult(HealthPotion potion)
    {
        _text.text = potion.GetHealth().ToString();
    }
}
