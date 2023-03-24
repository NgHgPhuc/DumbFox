using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform Player;
    Vector3 distance;
    bool camMove;
    void Start()
    {
        transform.position = Player.transform.position + new Vector3(0, 2f, -10f);
        distance = transform.position - Player.position;
        camMove = true;

        GetComponent<AudioSource>().Play();
    }

    void FixedUpdate()
    {
        CamMove();
        if(!camMove)
        GetComponent<AudioSource>().Stop();
    }

    void CamMove()
    {
        if(camMove)
            if (Player != null)
                transform.position = Player.position + distance;
    }
    public void SetCamMove(bool SetTo)
    {
        camMove = SetTo;
    }
}
