using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BeeBullet : MonoBehaviour
{
    [SerializeField] float Damage;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -2), ForceMode2D.Impulse);
        Destroy(gameObject, 2f);
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
