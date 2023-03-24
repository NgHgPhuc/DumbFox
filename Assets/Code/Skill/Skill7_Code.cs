using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill7_Code : MonoBehaviour // Poison bottle discharged Poison
{
    float Next;
    float NextDischarge;
    public GameObject Poison;
    float flip;
    void Start()
    {
        Next = Time.time;
        NextDischarge = Time.time;

    }

    void Update()
    {
        if (Time.time >= NextDischarge + 0.25)
        {
            NextDischarge = Time.time;
            Instantiate(Poison, transform.position + new Vector3(-0.87f * flip, -0.25f,0f), transform.rotation);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            flip = player.transform.localScale.x / Mathf.Abs(player.transform.localScale.x);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(-0.33f, 0f, 0f)*flip, 20*Time.deltaTime);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 35.153f * flip));
            if (Time.time > Next + 2)
            {
                Next = Time.time;
                player.BeingHit(5f);
            }
        }
    }
}
