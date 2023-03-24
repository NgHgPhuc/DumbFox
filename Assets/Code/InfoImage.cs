using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoImage : MonoBehaviour
{
    int IDItem;

    string NameItem;

    int AmountItem;

    public TextMeshProUGUI text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetII(Items items)
    {
        IDItem = items.IDItem;
        NameItem = items.NameItem;
        AmountItem = items.AmountItem;
    }

    public void SetText()
    {
        text.text = NameItem;
    }
}
