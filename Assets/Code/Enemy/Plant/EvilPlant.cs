using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EvilPlant : MonoBehaviour
{
    // Start is called before the first frame update
    float Damage;
    [SerializeField] GameObject Bullet;
    float Reload=2f;
    float Next;
    Animator ani;
    void Start()
    {
        Damage = gameObject.GetComponent<Enemy>().Damage;
        Next = Time.time;
        Bullet.gameObject.GetComponent<PlantBullet>().SetDamage(Damage);
        ani = gameObject.GetComponent<Animator>();
        //Bullet.transform.localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ani.Play("Plant Attack");
            if (Time.time > Next + Reload)
            {
                Next = Time.time;
                Instantiate(Bullet, transform.position - new Vector3(0.6f, -0.27f, 0), transform.rotation);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ani.Play("Plant Attack");
            if (Time.time > Next + Reload)
            {
                Next = Time.time;
                Instantiate(Bullet, transform.position - new Vector3(0.7f, -0.27f, 0), transform.rotation);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ani.Play("Plant");
        }
    }
}
