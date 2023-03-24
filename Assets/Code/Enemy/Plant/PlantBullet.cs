using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlantBullet : MonoBehaviour
{
    [SerializeField] float Damage;
    void Start()
    {
        float side = -transform.localScale.x/Mathf.Abs(transform.localScale.x);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(side * 2, 0),ForceMode2D.Impulse);
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.BeingHit(Damage);
            
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ball Energy"))
            Destroy(gameObject);
    }

    public void SetDamage(float mount)
    {
        Damage = mount;
    }
}
