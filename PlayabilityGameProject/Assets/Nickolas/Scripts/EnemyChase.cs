using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public int moveSpeed = 4;
    public int maxDist = 10;
    public int minDist = 5;
    void Start()
    {

    }

    void Update()
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
}
