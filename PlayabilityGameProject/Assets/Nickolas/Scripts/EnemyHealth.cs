using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    PlayerHealth playerHealth;
    public GameObject mainPlayer;
    void Awake()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
        mainPlayer.GetComponent<PlayerHealth>();
    }
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHealth = playerHealth;
        }
    }
    void OnCollisionExit(Collision other)
    {

    }
}
