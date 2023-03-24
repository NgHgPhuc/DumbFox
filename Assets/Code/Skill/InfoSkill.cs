using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoSkill : MonoBehaviour
{
    Image ImageInfoSkill;
    TextMeshProUGUI NameInfoSkill;
    TextMeshProUGUI Description;
    TextMeshProUGUI MountMaterial;
    Button Upgrade;
    TextMeshProUGUI TextInButton;
    Transform MessageBar;
    TextMeshProUGUI TextMessage;

    public Skill skill;


    int Have;
    int Need;

    int LV;


    void Start()
    {
        ImageInfoSkill = transform.Find("ImageInfoSkill").GetComponent<Image>();
        NameInfoSkill = transform.Find("NameInfoSkill").GetComponent<TextMeshProUGUI>();
        Description = transform.Find("Description").GetComponent<TextMeshProUGUI>();
        MountMaterial = transform.Find("MountMaterial").GetComponent<TextMeshProUGUI>();
        Upgrade = transform.Find("Upgrade").GetComponent<Button>();
        MessageBar = transform.Find("MessageBar").GetComponent<Transform>();
        TextMessage = MessageBar.Find("Text").GetComponent<TextMeshProUGUI>();
        TextInButton = Upgrade.transform.Find("TextInButton").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        int Have = Convert.ToInt16(MountMaterial.text.Split("/")[0]);
        int Need = Convert.ToInt16(MountMaterial.text.Split("/")[1]);
        if (Have < Need) MountMaterial.color = Color.red;
        else MountMaterial.color = Color.green;
    }

    public void SetImage(Sprite sprite)
    {
        ImageInfoSkill.sprite = sprite;
    }

    public void SetName(string name,float cooldown,string cost,string lv)
    {
        this.LV = Convert.ToInt32(lv);
        string s = name + "\n" + "Cooldown: " + cooldown.ToString() + "\n" + "Cost:" + cost +"\n" +"LV:"+lv;
        NameInfoSkill.SetText(s);
        if (lv == "None" || Convert.ToInt16(lv) == 0)
            TextInButton.SetText("Learn");
        else TextInButton.SetText("Upgrade");
    }

    public void SetDescription(string description)
    {
        Description.SetText(description);
    }

    public void SetMountMaterial(string Have,string Need)
    {
        this.Have = Convert.ToInt32(Have);
        this.Need = Convert.ToInt32(Need);
        MountMaterial.SetText(Have + "/" + Need);
    }

    public void upgrade()
    {

        try
        {
            if (Have >= Need)
            {
                Have -= Need;
                if (LV == 0)
                {
                    skill.Learn = true;
                    messageBar(0, "Learned successly skill", Color.green);
                }
                else messageBar(0, "Upgraded successly skill", Color.green);
                skill.LV += 1;
                skill.UpgradeCost(-Need);
                skill.BeChosen(); // set lai skill sau khi up

            }
            else messageBar(0, "Don't enough star", Color.red);
        }
        catch (Exception) { messageBar(0, "Error",Color.white); }
    }

    void messageBar(float time,string mes,Color color)
    {
        TextMessage.color = color;
        TextMessage.SetText(mes);
    }

}
