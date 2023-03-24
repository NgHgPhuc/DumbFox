using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillChosen : MonoBehaviour
{
    public string SkillUsingName;
    public Sprite SkillUsingSprite;
    public Image SkillUsingImage;
    public Image SkillUsingButton;
    public delegate void Mydelegate();
    public Mydelegate SkillUsing;
    public float Cooldown;
    float NextUsingTime;
    void Start()
    {
        NextUsingTime = Time.time;
    }
    void Update()
    {
    }
    public void SetSpriteSkill()
    {
        SkillUsingImage.sprite = SkillUsingSprite;
        SkillUsingButton.sprite = SkillUsingSprite;

        NextUsingTime = Time.time;
    }

    public void UsingSkill()
    {
        try
        {
            if (Time.time > NextUsingTime)
            {
                SkillUsing();
                NextUsingTime = Time.time + Cooldown;
            }
            else Debug.Log("Skill isn't already, just wait "+Math.Round((NextUsingTime-Time.time),1)+"sec");
        }
        catch (Exception) { Debug.Log("UnChoose Skill"); }
    }
}
