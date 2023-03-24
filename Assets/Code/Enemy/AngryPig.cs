using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPig : MonoBehaviour
{
    Animator Ani;

    EnemyAI enemyAI;
    Enemy enemy;

    float TurnMark;
    bool IsChange;

    void Start()
    {
        Ani = gameObject.GetComponent<Animator>();
        enemyAI = gameObject.GetComponent<EnemyAI>();
        enemy = gameObject.GetComponent<Enemy>();

        IsChange = false;

    }

    void Update()
    {
        if(enemy.CurrentAndMax(2) && !IsChange) //if current health <= max health / 2
        {
            TurnMark = Time.time;
            IsChange = true;
            Ani.Play("Turn in Angry");
            enemy.Heal(10);
            enemy.AddDamge(10);
            gameObject.GetComponent<EnemyAI>().AddSpeed(2);

        }
        if(IsChange && Time.time>TurnMark+1)
        {
            Ani.Play("Angry Run");
        }
    }
}
