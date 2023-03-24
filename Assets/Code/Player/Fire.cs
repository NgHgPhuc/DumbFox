using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float Speed;
    public float AliveTime;

    Rigidbody2D Body;

    private void Awake()
    {
        Body = GetComponent<Rigidbody2D>();

        if (transform.localRotation.z < 0)
            Body.AddForce(new Vector2(-1, 0) * Speed, ForceMode2D.Impulse);
        else Body.AddForce(new Vector2(1, 0) * Speed, ForceMode2D.Impulse);

        Destroy(gameObject, AliveTime);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RemoveForce()
    {
        Body.velocity = new Vector2(0, 0);
    }
}
