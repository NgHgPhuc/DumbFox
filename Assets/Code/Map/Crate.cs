using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public GameObject CrateExplosion;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball Energy")
        {
            Destroy(gameObject);
            Destroy(Instantiate(CrateExplosion, transform.position, transform.rotation),0.5f);
        }
    }
}
