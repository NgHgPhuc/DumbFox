using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill6_Code : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.8f);
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
            enemy.BeingHit(50f);
        }
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.BeingHit(30f);
        }
    }
}
