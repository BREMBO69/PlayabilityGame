using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM : MonoBehaviour
{
    public GameObject player;
    private Transform playerPosition;
    private Vector3 currentPosition;
    public float distance;
    public float enemySpeed;

    void Start()
    {
        playerPosition = player.GetComponent<Transform>();
        currentPosition = GetComponent<Transform>().position;
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, playerPosition.position) <= distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, enemySpeed * Time.deltaTime);
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPosition, enemySpeed * Time.deltaTime);
        }
    }
}
