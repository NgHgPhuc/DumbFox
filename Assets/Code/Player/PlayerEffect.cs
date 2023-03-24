using System;
using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Tilemaps;
//using UnityEngine.UI;

//public class PlayerEffect : MonoBehaviour
//{
//    //Color effect
//    bool CanbeHit = true;
//    float BeHitTime;

//    public Vector2 EtnVelocity;


//    void Start()
//    {
//    }

//    private void Update()
//    {
//        BeingHitEffect(); // change color back after being hit
//    }

//    public void BeingHit(float damage) // change color when being hit
//    {
//        if (CanbeHit)
//        {
//            BeHitTime = Time.time;
//            gameObject.GetComponent<SpriteRenderer>().color = new Color(255f / 255, 120f / 255, 120f / 255);
//            CanbeHit = false;
//        }
//    }
//    void BeingHitEffect() // change color back
//    {
//        if (Time.time > BeHitTime + 0.5)
//        {
//            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
//            CanbeHit = true;
//        }
//    }
//}
