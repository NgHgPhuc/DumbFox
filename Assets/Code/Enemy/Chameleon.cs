using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chameleon : MonoBehaviour
{
    Animator animator;
    float NextAttack;
    float InvisibleMark; //time start invi
    bool Change;
    void Start()
    {
        animator = GetComponent<Animator>();
        InvisibleMark = 1f;
        Change = true;

    }

    void Update()
    {
        if(Time.time > InvisibleMark + 1)
        {
            Change = !Change;
            GetComponent<Enemy>().enemyHealthBar().SetActive(Change);
            GetComponent<SpriteRenderer>().enabled = Change;
            InvisibleMark = Time.time;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball Energy"))
        {
            GetComponent<EnemyAI>().AddSpeed(1);
        }
    }
}
