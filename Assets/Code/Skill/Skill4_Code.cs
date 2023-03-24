using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4_Code : MonoBehaviour
{
    Rigidbody2D rg2d;
    CircleCollider2D cc2d;
    Animator Anim;

    float Next;

    public float flip;

    public float Damage;

    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CircleCollider2D>();
        Anim = GetComponent<Animator>();

        rg2d.AddForce(new Vector2(3, 3) * new Vector2(flip,1) , ForceMode2D.Impulse);

        Destroy(gameObject, 10f);
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground")) // Animation
        {
            rg2d.gravityScale = 0;
            cc2d.isTrigger = true;
            cc2d.radius = 0.25f;
            transform.position += new Vector3(0, 0.38f, 0);
            rg2d.velocity = new Vector2(0, 0);
            Anim.Play("Fire");

            Destroy(gameObject,6f);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(Time.time>Next+1)
            {
                Next = Time.time;
                Player player = collision.gameObject.GetComponent<Player>();
                player.BeingHit(5f);
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("EvilMobs"))
        {
            if (Time.time > Next + 1)
            {
                Next = Time.time;
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.BeingHit(5f);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Next = Time.time;
            Player player = collision.gameObject.GetComponent<Player>();
            player.BeingHit(5f);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("EvilMobs"))
        {
            if (Time.time > Next + 1)
            {
                Next = Time.time;
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.BeingHit(5f);
            }
        }
    }
}
