using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerVsBoss : MonoBehaviour
{

    public GameObject Player;
    public GameObject Boss;
    public GameObject TheEnd;

    public GameObject TelPort1;
    public GameObject TelPort2;
    public GameObject cam;
    float PlayerInTime;

    bool BossActive=false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            Boss.GetComponent<Enemy>().GetCurrentHealth();
        }
        catch (Exception) { TheEnd.SetActive(true); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerInTime = Time.time;
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cam.GetComponent<Cam>().SetCamMove(false);
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(39, 20, -10), Time.deltaTime * 3);

            if (Time.time > PlayerInTime+3)
            {
                if(Camera.main.orthographicSize < 6.7)
                    Camera.main.orthographicSize += 0.005f;
                
                TelPort1.SetActive(true);
                TelPort2.SetActive(true);
                try
                {
                    Boss.SetActive(true);
                }
                catch (Exception) {
                    TheEnd.SetActive(true);
                    TelPort1.SetActive(false);
                    TelPort2.SetActive(false);
                }
            }
        }
    }
}
