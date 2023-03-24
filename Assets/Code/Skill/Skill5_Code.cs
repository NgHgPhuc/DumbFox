using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill5_Code : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject NuclearExplosion;
    void Start()
    {
        Destroy(gameObject, 10f);
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
            enemy.BeingHit(20f);
            EnemyAI enemyAI = collision.gameObject.GetComponent<EnemyAI>();
            enemyAI.BeingSlowInSec(30, 1f);
            Destroy(Instantiate(NuclearExplosion, transform.position + new Vector3(0f, 0.24f, 0f), transform.rotation), 0.9f);

            Destroy(gameObject);

        }
    }
}
