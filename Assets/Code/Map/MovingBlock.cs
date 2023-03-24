using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public Vector3 MoveDistance;
    public float Speed;
    Vector3 From;
    Vector3 To;

    bool PlayerOn=false;
    void Start()
    {
        From = transform.position;
        To = From + MoveDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerOn && transform.position != To)
        {
            transform.position = Vector3.MoveTowards(transform.position, To, Speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerOn = true;
        }
    }
}
