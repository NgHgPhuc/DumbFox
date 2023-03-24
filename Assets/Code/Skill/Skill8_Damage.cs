using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Skill8_Damage : MonoBehaviour
{
    // Start is called before the first frame update
    public Enemy enemy;
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, 10 * Time.deltaTime);
        }
        catch (Exception) { Destroy(gameObject); }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("EvilMobs"))
        {
            enemy.BeingHit(10f);
            Destroy(gameObject);
        }
    }
}
