using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class SettingMenu : MonoBehaviour
{
    // Start is called before the first frame update
    bool IsOn; // active of setting menu
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI VolMount;
    void Start()
    {
        IsOn = false;
        slider.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        VolMount.SetText(((int)(slider.value)).ToString());
    }

    public void TurnSettingMenu()
    {
        gameObject.SetActive(!IsOn);
        IsOn = !IsOn;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public float GetVolMount()
    {
        return slider.value/100;
    }
}
