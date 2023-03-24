using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    float SpeedInFirst;
    public float Distance;
    Vector3 start;
    Vector3 end;

    int SlowPercent;
    float SlowInTime;
    float StartTimeSlow;

    float CCInTime;
    float StartTimeCC;

    public delegate void Move();
    public Move move;

    void Start()
    {
        start = transform.position;
        end = start - new Vector3(Distance,0f,0f);

        SpeedInFirst = speed;
    }

    void Update()
    {
        if (transform.position == end)
        {
            Vector3 trans = start;
            start = end;
            end = trans;
            Flip();
        }

        Effect(); // move around in this function : transform.position = Vector3.MoveTowards(transform.position, end, speed * Time.deltaTime);

    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    public void BeingSlowInSec(int SlowPercent, float SlowInTime)
    {
        this.SlowPercent = SlowPercent;
        this.SlowInTime = SlowInTime;
        this.StartTimeSlow = Time.time;

        speed -= speed * (float)SlowPercent / 100f;

    }

    public void BeingCCInSec(float CCInTime)
    {
        this.CCInTime = CCInTime;
        this.StartTimeCC = Time.time;

    }

    public void AddSpeed(float mount)
    {
        speed += mount;
        SpeedInFirst = speed;
    }

    void Effect()
    {
        if (Time.time > StartTimeSlow + SlowInTime)
        {
            speed = SpeedInFirst;
        }
        if (Time.time > StartTimeCC + CCInTime)
        {
            try
            {
                move();
            }
            catch (Exception) { transform.position = Vector3.MoveTowards(transform.position, end, speed * Time.deltaTime); }
        }
    }
}
