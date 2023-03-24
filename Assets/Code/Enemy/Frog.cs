using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public Sprite FrogJump;
    public Sprite FrogFall;
    Animator Ani;

    EnemyAI enemyAI;
    Rigidbody2D rg2d;

    float NextJump;
    float speed;

    bool OnGround;
    float Flip;

    int times=0;

    void Start()
    {
        Ani = gameObject.GetComponent<Animator>();
        enemyAI = gameObject.GetComponent<EnemyAI>();
        rg2d = gameObject.GetComponent<Rigidbody2D>();
        gameObject.GetComponent<EnemyAI>().move = MovingMechanic;
        speed = gameObject.GetComponent<EnemyAI>().speed;

        NextJump = 1;
        OnGround = true;
    }

    void Update()
    {
        Flip = transform.localScale.x;
        Flip /= Mathf.Abs(Flip);

        if (rg2d.velocity.y < -0.01) // falling
            gameObject.GetComponent<SpriteRenderer>().sprite = FrogFall;
        else if (rg2d.velocity.y > 0.01)
            gameObject.GetComponent<SpriteRenderer>().sprite = FrogJump;
    }

    void MovingMechanic()
    {
        if(Time.time > NextJump + 2) //after 1s continue jumping
        {
            rg2d.AddForce(new Vector2(-speed*Flip, speed*2),ForceMode2D.Impulse);
            NextJump = Time.time;
            Ani.enabled = false;

            OnGround = false;

            times++;

        }
        else if(OnGround)
        {
            Ani.enabled = true;
            rg2d.velocity = new Vector2(0, 0);

            if (times >= 2)
            {
                FlipBody();
                times = 0;
            }

        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            OnGround = true;
        }
    }
    void FlipBody()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
