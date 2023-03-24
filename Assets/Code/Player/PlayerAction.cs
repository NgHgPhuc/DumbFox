//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Tilemaps;
//using UnityEngine.UI;

//public class PlayerAction : MonoBehaviour //Fire - Skill - Heal
//{
//    //Initial Fire variables
//    public BallEnergy ballEnergy;
//    public float CoolDown;
//    float NextTime;

//    //Skill
//    public Transform SkillChoose;
//    SkillChosen ss;
//    float StarMount;

//    PlayerMoving playerMoving;
//    PlayerStats playerStats;

//    void Start()
//    {
//        //Skill
//        ss = SkillChoose.GetComponent<SkillChosen>();

//        playerMoving = gameObject.GetComponent<PlayerMoving>();
//        playerStats = gameObject.GetComponent<PlayerStats>();
//    }

//    private void Update()
//    {
//        if (Input.GetKeyUp(KeyCode.V))//Use skill - v
//        {
//            ss.UsingSkill();
//        }
//    }

//    void PlayerFire()
//    {
//        if (Time.time > NextTime)
//        {
//            NextTime = Time.time + CoolDown;
//            FireEnergyBall();
//        }
//    }

//    void FireEnergyBall()
//    {
//        Vector2 FirePosition;
//        float angle;
//        if (playerMoving.right())
//        {
//            FirePosition = playerMoving.body().position + new Vector2(0.9f, -0.3f);
//            angle = 0;
//        }
//        else
//        {
//            FirePosition = playerMoving.body().position + new Vector2(-0.9f, -0.3f);
//            angle = -180;
//        }

//        Instantiate(ballEnergy, FirePosition, Quaternion.Euler(new Vector3(0, 0, angle)));
//    }

//    public void SetStarMount(float mount)
//    {
//        StarMount += mount;
//    }
//    public float GetStarMount()
//    {
//        return StarMount;
//    }

//    public void Heal(float HealingMount)
//    {
//        playerStats.Heal(HealingMount);
//    }
//}
