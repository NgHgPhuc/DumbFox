using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crank : MonoBehaviour
{
    public Sprite CrankDown;
    Sprite CrankUp;
    bool Used;//Up = false ; down = true;

    void Start()
    {
        CrankUp = GetComponent<SpriteRenderer>().sprite;
    }

    void Update()
    {    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball Energy")
        {
            Used = !Used;
            if (Used) GetComponent<SpriteRenderer>().sprite = CrankDown;
            else GetComponent<SpriteRenderer>().sprite = CrankUp;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.tag == "Player")
        //{
        //    if (Input.GetKeyDown(KeyCode.F))
        //    {
        //        Used = !Used;
        //        if (Used) GetComponent<SpriteRenderer>().sprite = CrankDown;
        //        else GetComponent<SpriteRenderer>().sprite = CrankUp;
        //    }
        //}
    }

    public bool GetUsed()
    {
        return Used;
    }
}
