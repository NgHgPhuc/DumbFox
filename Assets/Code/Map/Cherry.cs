using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public GameObject CherryFx;

    void Start()
    {

    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(CherryFx, transform.position, transform.rotation);
            Player player = collision.gameObject.GetComponent<Player>();
            player.PlayerHeal(20f);
        }
    }
}
