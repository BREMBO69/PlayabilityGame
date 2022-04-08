using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float range = 10.0f;
    public float speed;
    public float stoppingDistance;
    public float retreatedDistnace;

    //Important shooting timing
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject projectile;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBetweenShots = startTimeBetweenShots;
    }
    void Update()
    {
        if (player.position.x <= range)
        {
            if (timeBetweenShots <= 0)
            {
                Instantiate(projectile, transform.position + new Vector3(0,0,2), Quaternion.identity);
                timeBetweenShots = startTimeBetweenShots;
            }

            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }
    }
}
