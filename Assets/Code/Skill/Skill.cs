using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public string SkillName;
    public Transform SkillChoose;
    SkillChosen ss;
    public GameObject player;
    int StarMount;

    public GameObject Infoskill;
    InfoSkill iS;

    public GameObject Skill1_Object;
    float Skill1_Cooldown=10f;

    public GameObject Skill2_Object;
    float Skill2_Cooldown=15f;

    public GameObject Skill3_Object;
    float Skill3_Cooldown=15f;

    public GameObject Skill4_Object;
    float Skill4_Cooldown=2.5f;

    public GameObject Skill5_Object;
    float Skill5_Cooldown=5f;

    public GameObject Skill6_Object;
    float Skill6_Cooldown=10f;

    public GameObject Skill7_Object;
    bool Skill7_OnOff;
    GameObject Skill7_ObjectClone;
    float Skill7_Cooldown=1f;

    public GameObject Skill8_Object;
    float Skill8_Cooldown=20f;

    public GameObject Skill9_Object;
    public GameObject Skill9_Clone;
    float Skill9_Cooldown=20f;

    public bool Learn;
    public int LV;

    void Start()
    {
        ss = SkillChoose.gameObject.GetComponent<SkillChosen>();
        iS = Infoskill.GetComponent<InfoSkill>();

        Learn = false;
        LV = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StarMount = player.GetComponent<Player>().GetStarMount();
        iS.SetMountMaterial(StarMount.ToString(), "5");

        if (!Learn) gameObject.GetComponent<Image>().color = new Color(89f/255, 89f / 255, 89f / 255);
        else gameObject.GetComponent<Image>().color = Color.white;

    }
    public void BeChosen()
    {
        ss.SkillUsingName = SkillName;
        ss.SkillUsingSprite = GetComponent<Image>().sprite;

        iS.SetImage(GetComponent<Image>().sprite);
        iS.skill = gameObject.GetComponent<Skill>();

        switch(ss.SkillUsingName)
        {
            case "Lightning Explosion":
                iS.SetName(SkillName, Skill1_Cooldown, "None", LV.ToString());
                iS.SetDescription("Explode a mobs front player, if it die, continuious explode another mobs,deal 30 damage");
                if (Learn) ss.SkillUsing = Skill1; else ss.SkillUsing = null;
                break;
            case "Lightning Thunder":
                iS.SetName(SkillName, Skill1_Cooldown, "None", LV.ToString());
                iS.SetDescription("Summon 6 lightning thunder and stun mobs,deal 5 damage each 1 lightning");
                if (Learn) ss.SkillUsing = Skill2; else ss.SkillUsing = null;
                break;
            case "Lightning Ball":
                iS.SetName(SkillName, Skill1_Cooldown, "None", LV.ToString());
                iS.SetDescription("Upgrade player, increase fire speed, speed run, and heal a little");
                if (Learn) ss.SkillUsing = Skill3; else ss.SkillUsing = null;
                break;
            case "Fire":
                iS.SetName(SkillName, Skill1_Cooldown, "None", LV.ToString());
                iS.SetDescription("Throw a fire, bigger when fell on ground,deal 5 damage each 1s (even player gets)");
                if (Learn) ss.SkillUsing = Skill4; else ss.SkillUsing = null;
                break;
            case "Nuclear Explosion":
                iS.SetName(SkillName, Skill1_Cooldown, "None", LV.ToString());
                iS.SetDescription("Set up a bomb on a ground, explode when step on, deal 20 damage and slow 30% in 1s");
                if (Learn) ss.SkillUsing = Skill5; else ss.SkillUsing = null;
                break;
            case "Self Destruction":
                iS.SetName(SkillName, Skill1_Cooldown, "None", LV.ToString());
                iS.SetDescription("Using player health to explode, 30hp to deal 50 damage to all");
                if (Learn) ss.SkillUsing = Skill6; else ss.SkillUsing = null;
                break;
            case "Poison Gas":
                iS.SetName(SkillName, Skill1_Cooldown, "None", LV.ToString());
                iS.SetDescription("Discharge a toxic flow behind player, 5 damage each 1s");
                if (Learn) ss.SkillUsing = Skill7; else ss.SkillUsing = null;
                break;
            case "Poison Entity":
                iS.SetName(SkillName, Skill1_Cooldown, "None", LV.ToString());
                iS.SetDescription("Summon a toxic pet exist in 10 sec, shoot every mobs around player deal 10 damage");
                if (Learn) ss.SkillUsing = Skill8; else ss.SkillUsing = null;
                break;
            case "Light Speed Flow":
                iS.SetName(SkillName, Skill1_Cooldown, "None", LV.ToString());
                iS.SetDescription("Using Player soul, can do everything like player and increase speed run");
                if (Learn) ss.SkillUsing = Skill9; else ss.SkillUsing = null;
                break;
                
            default:break;
        }
        ss.SetSpriteSkill();
        while (SkillChoose.position != transform.position)
            SkillChoose.position = Vector3.MoveTowards(SkillChoose.position, transform.position, 5 * Time.deltaTime);
    }
    void Skill1()
    {
        ss.Cooldown = Skill1_Cooldown;
        float flip = player.transform.localScale.x/Mathf.Abs(player.transform.localScale.x);
        Instantiate(Skill1_Object, player.transform.position + new Vector3(3f, 0f, 0f)*flip, player.transform.rotation);
    }
    void Skill2()
    {
        ss.Cooldown = Skill2_Cooldown;
        float flip = player.transform.localScale.x / Mathf.Abs(player.transform.localScale.x);
        Vector3 nextPos = new Vector3(player.transform.position.x + flip, 0.8f, 0);
        float Next = Time.time;
        for(int i=0;i<6;i++)
        {
            Instantiate(Skill2_Object, nextPos, player.transform.rotation);
            nextPos += new Vector3(1f, 0f, 0f) * flip;
        }
    }
    void Skill3()
    {
        ss.Cooldown = Skill3_Cooldown;
        Instantiate(Skill3_Object, player.transform.position, player.transform.rotation);
    }
    void Skill4()
    {
        ss.Cooldown = Skill4_Cooldown;
        float flip = player.transform.localScale.x / Mathf.Abs(player.transform.localScale.x);
        Skill4_Object.gameObject.GetComponent<Skill4_Code>().flip = flip;
        Instantiate(Skill4_Object, player.transform.position + new Vector3(0.7f * flip,0.3f,0), player.transform.rotation);
    }
    void Skill5()
    {
        ss.Cooldown = Skill5_Cooldown;
        Instantiate(Skill5_Object, player.transform.position + new Vector3(0f, -0.44f, 0), player.transform.rotation);
    }
    void Skill6()
    {
        ss.Cooldown = Skill6_Cooldown;
        Instantiate(Skill6_Object, player.transform.position, transform.rotation);//35.153
    }
    void Skill7()
    {
        ss.Cooldown = Skill7_Cooldown;
        if (Skill7_OnOff == true) //on
        {
            Destroy(Skill7_ObjectClone);
            Skill7_OnOff = false;
        }
        else if(Skill7_OnOff != true) // off
        {
            float flip = player.transform.localScale.x / Mathf.Abs(player.transform.localScale.x);
            Skill7_ObjectClone = Instantiate(Skill7_Object, player.transform.position + new Vector3(-0.33f, 0f, 0f) * flip, Quaternion.Euler(new Vector3(0, 0, 35.153f * flip)));
            Skill7_OnOff = true;
        }
    }
    void Skill8()
    {
        ss.Cooldown = Skill8_Cooldown;
        float flip = player.transform.localScale.x / Mathf.Abs(player.transform.localScale.x);
        Instantiate(Skill8_Object, player.transform.position + new Vector3(-1f * flip, 1.67f, 0f), Quaternion.Euler(new Vector3(0, 0, 35.153f * flip)));
    }
    void Skill9()
    {
        ss.Cooldown = Skill9_Cooldown;
        float flip = player.transform.localScale.x / Mathf.Abs(player.transform.localScale.x);
        Skill9_Object.transform.localScale = new Vector3(2f, 2*flip, 1f);

        Instantiate(Skill9_Clone, player.transform.position, player.transform.rotation);//player clone
        Instantiate(Skill9_Object, player.transform.position + new Vector3(-1.8f * flip, -0.16f, 0f), Skill9_Object.transform.rotation);
    }

    public void UpgradeCost(int mount)
    {
        player.GetComponent<Player>().SetStarMount(mount);
    }
}
