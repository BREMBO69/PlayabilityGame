using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHP = 100;
    public int timesDied = 0;
    public GameObject respawnPoint;
    void Start()
    {
        
    }

    void Update()
    {
        if(playerHP <= 0)
        {
            playerHP = 100;
            //Destroy(GameObject.FindGameObjectWithTag("Player"));
            transform.position = respawnPoint.transform.position;
            timesDied++;
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
