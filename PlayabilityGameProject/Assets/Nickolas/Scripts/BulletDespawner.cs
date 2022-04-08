using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawner : MonoBehaviour
{
    public float timer = 3.0f;
    public float multiply = 1.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - multiply * Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
