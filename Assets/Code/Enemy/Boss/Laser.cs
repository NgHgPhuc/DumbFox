using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().BeingHit(30);
        }
        if (collision.gameObject.CompareTag("Ball Energy"))
        {
            Destroy(collision.gameObject);
        }
    }
    public void FlipBody(float side)
    {
        Vector3 scale = transform.localScale;
        scale.x = Math.Abs(scale.x) * side;
        transform.localScale = scale;
    }
}
