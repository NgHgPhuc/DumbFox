using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1_Code : MonoBehaviour
{
    public float Damage;

    void Start()
    {
        Destroy(gameObject, 0.8f);
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EvilMobs"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Vector3 EnemyPosition = enemy.transform.position;
            if (enemy.BeingHitToDie(Damage))
            {
                Instantiate(gameObject, EnemyPosition, transform.rotation);
            }
        }
    }
}
