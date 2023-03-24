using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill9_Code : MonoBehaviour
{
    // Start is called before the first frame update
    Player player;
    GameObject Clone;
    float PlayerCurrentHealth;
    //float Duration;
    float Return;
    void Start()
    {
        Return = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Clone")
        {
            Clone = collision.gameObject;
        }
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Player>();
            PlayerCurrentHealth = player.CurrentHealth;
            player.speed += 5;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Player>();
            float flip = player.transform.localScale.x / Mathf.Abs(player.transform.localScale.x);
            transform.localScale = new Vector3(1.8f, 2.5f*flip, 1f);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position+new Vector3(-1.8f * flip, -0.16f, 0f), 50 * Time.deltaTime);

            if(Time.time > Return+5)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, Clone.transform.position, 20 * Time.deltaTime);
                if (player.transform.position == Clone.transform.position)
                {
                    Destroy(Clone);
                    Destroy(gameObject);
                    player.CurrentHealth = PlayerCurrentHealth;
                    player.speed -= 5;
                }

            }
        }
    }
}
