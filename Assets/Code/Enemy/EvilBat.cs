using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EvilBat : MonoBehaviour
{
    // Start is called before the first frame update
    Animator Ani;
    EnemyAI enemyAI;
    float speed;
    Player player;
    Vector3 FirstPos;
    Vector3 ToPos;
    void Start()
    {
        Ani = gameObject.GetComponent<Animator>();
        enemyAI = gameObject.GetComponent<EnemyAI>();
        gameObject.GetComponent<EnemyAI>().move = MovingMechanic;
        speed = gameObject.GetComponent<EnemyAI>().speed;

        FirstPos = transform.position;
        ToPos = FirstPos;

    }

    // Update is called once per frame
    void Update()
    {
        if (ToPos.x > transform.position.x)
        {
            FlipBody(-1);
        }
        else if(ToPos.x < transform.position.x)
        {
            FlipBody(1);
        }
        if (transform.position == FirstPos)
            Ani.Play("Bat Idle");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Player>();
            ToPos = player.transform.position;
            Ani.Play("Bat Fly");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ToPos = player.transform.position;
            Ani.Play("Bat Fly");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ToPos = FirstPos;
        }
    }
    
    void MovingMechanic()
    {
        transform.position = Vector3.MoveTowards(transform.position, ToPos, speed * Time.deltaTime);
    }
    void FlipBody(float side)
    {
        Vector3 scale = transform.localScale;
        scale.x = Math.Abs(scale.x)* side;
        transform.localScale = scale;
    }
}
