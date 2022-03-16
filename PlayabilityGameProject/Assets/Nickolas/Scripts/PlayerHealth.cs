using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHP = 100;
    void Start()
    {
        
    }

    void Update()
    {
        if(playerHP <= 0)
        {
            playerHP = 0;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            playerHP = playerHP - 5;
        }
    }
    void OnCollisionExit(Collision other)
    {

    }
}
