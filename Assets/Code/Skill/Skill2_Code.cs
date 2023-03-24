using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2_Code : MonoBehaviour
{
    float Damage=5f;
    float CCTiming=1f;

    void Start()
    {
        Destroy(gameObject, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EvilMobs"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Vector3 EnemyPosition = enemy.transform.position;
            enemy.BeingHit(Damage);
            EnemyAI enemyAI = collision.gameObject.GetComponent<EnemyAI>();
            enemyAI.BeingCCInSec(CCTiming);
        }
    }
}
