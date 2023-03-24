using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelPort : MonoBehaviour
{
    public GameObject Portal;
    Vector3 ToPortal;
    public Vector3 Distance;
    float NextUse;
    void Start()
    {
        ToPortal = Portal.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time > NextUse)
            {
                collision.gameObject.transform.position = ToPortal + Distance;
                NextUse = Time.time + 2;

            }
        }
    }
}
