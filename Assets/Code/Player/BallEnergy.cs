using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnergy : MonoBehaviour
{
    Rigidbody2D Body;
    public GameObject Explosion;

    public float Speed;
    public float AliveTime;
    public float EnergyBallDamage;

    void Start()
    {
        Body = GetComponent<Rigidbody2D>();


        if (transform.localRotation.z < 0)
            Body.AddForce(new Vector2(-1, 0) * Speed, ForceMode2D.Impulse);
        else Body.AddForce(new Vector2(1, 0) * Speed, ForceMode2D.Impulse);

        Destroy(gameObject, AliveTime);
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("EvilMobs"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.BeingHit(EnergyBallDamage);

            enemy.SetColorInTime(new Color(255f/255,120f/255,120f/255),0.5f);
        }

        //RemoveForce();
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void RemoveForce()
    {
        Body.velocity = new Vector2(0, 0);
    }

    //public void SetDamage(float Damage)
    //{
    //    EnergyBallDamage = 20;
    //}
    
}
