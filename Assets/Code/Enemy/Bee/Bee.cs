using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bee : MonoBehaviour
{
    // Start is called before the first frame update
    float Damage;
    [SerializeField] GameObject Bullet;
    float Reload = 1.5f;
    float Next;
    Animator ani;
    void Start()
    {
        Damage = gameObject.GetComponent<Enemy>().Damage;
        Next = Time.time;
        Bullet.gameObject.GetComponent<BeeBullet>().SetDamage(Damage);
        ani = gameObject.GetComponent<Animator>();

       
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Time.time > Next + Reload)
            {
                ani.Play("Bee Attack");
                Next = Time.time;
                Instantiate(Bullet, transform.position - new Vector3(0f, 0.2f, 0f), transform.rotation);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Time.time > Next + Reload)
            {
                ani.Play("Bee Attack");
                Next = Time.time;
                Instantiate(Bullet, transform.position - new Vector3(0f, 0.2f, 0), transform.rotation);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            ani.Play("Bee Idle");
    }
}
