using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathFx : MonoBehaviour
{
    
    void Start()
    {
        Destroy(gameObject, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
