using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill7_Poison : MonoBehaviour // Poison make damage
{
    float Next;
    float Damage;
    void Start()
    {
        Destroy(gameObject, 2f);
        Damage = 5f;
        Next = Time.time;
    }

    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Time.time > Next+1)
            {
                Next = Time.time;
                Player player = collision.gameObject.GetComponent<Player>();
                player.BeingHit(Damage);
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("EvilMobs"))
        {
            if (Time.time > Next+1) // stay more than 1s get damage
            {
                Next = Time.time; // every 1s get damage
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.BeingHit(Damage);
                enemy.SetColorInTime(new Color(97f / 255, 253f / 255, 128f / 255), 1);
                EnemyAI enemyAI = collision.gameObject.GetComponent<EnemyAI>();
                enemyAI.BeingSlowInSec(10, 1);
            }
        }

    }
}
