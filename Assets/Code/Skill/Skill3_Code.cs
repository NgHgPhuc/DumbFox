using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3_Code : MonoBehaviour
{
    Player player;

    void Start()
    {
        Destroy(gameObject,6.0f);
    }
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Player>();
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 20*Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Player>();
            player.PlayerHeal(10f);
            player.Ball_Energy.Speed += 5;
            player.CoolDown /= 2;
        }
    }
    private void OnDestroy()
    {
        player.Ball_Energy.Speed -= 5;
        player.CoolDown *= 2;

    }
}
