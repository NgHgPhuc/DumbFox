using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill8_Object : MonoBehaviour
{
    float flip;
    float Next;
    public GameObject Skill8_Damage;
    GameObject a;

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
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            flip = player.transform.localScale.x / Mathf.Abs(player.transform.localScale.x);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(-1f * flip, 1.67f, 0f), 5* Time.deltaTime);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("EvilMobs"))
        {
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            if (Time.time > Next)
            {
                Next = Time.time + 0.5f;
                Instantiate(Skill8_Damage, transform.position, transform.rotation).gameObject.GetComponent<Skill8_Damage>().enemy = e;
            }
        }
    }
}
