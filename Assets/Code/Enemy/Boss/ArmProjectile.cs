using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rg2d;
    public float Flip;
    void Start()
    {
        rg2d = gameObject.GetComponent<Rigidbody2D>();
        rg2d.AddForce(new Vector2(Flip * 4, 0), ForceMode2D.Impulse);
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().BeingHit(30);
        }
        if (collision.gameObject.CompareTag("Ball Energy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
