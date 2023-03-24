using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromMove : MonoBehaviour
{
    public Vector3 MoveDistance;
    public float Speed;
    Vector3 From;
    Vector3 To;

    public GameObject Crank;
    

    void Start()
    {
        From = transform.position;
        To = From + MoveDistance;
    }

    void Update()
    {
        if(Crank.GetComponent<Crank>().GetUsed())
        {
            if (transform.position == To)
            {
                Vector3 trans = To;
                To = From;
                From = trans;
            }
            transform.position = Vector3.MoveTowards(transform.position, To, Speed * Time.deltaTime);
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        Player player = collision.gameObject.GetComponent<Player>();
            
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Crank.GetComponent<Crank>().GetUsed())
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.EtnVelocity = new Vector2(Speed, 0f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.EtnVelocity = new Vector2(0f, 0f);
        }
    }
}
