using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public int moveSpeed = 4;
    public int maxDist = 10;
    public int minDist = 5;
    public int test = 1;

    public bool chaseIsActive = true;

    public int enemyHealth = 100;
    void Start()
    {
        chaseIsActive = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            test = 2;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            test = 1;
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }


        if (chaseIsActive == true && test == 1)
        {
            EnemyChaseActive();
        }

        else if(chaseIsActive == false && test > 1)
        {
           
        }
    }

    void EnemyChaseActive()
    {
        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) >= minDist)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, player.position) <= minDist && Vector3.Distance(transform.position, player.position) < maxDist)
        {
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            enemyHealth = enemyHealth - 5;
        }
    }
    void OnCollisionExit(Collision other)
    {

    }
}
