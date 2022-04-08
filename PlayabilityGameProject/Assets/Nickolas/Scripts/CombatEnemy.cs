using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemy : MonoBehaviour
{
    public Transform player;
    public float range = 20.0f;
    public float bulletImpulse = 40.0f;

    private bool onRange = false;
    public Rigidbody projectile;

    void Start()
    {
        float random = Random.Range(2.0f, 3.0f);
        InvokeRepeating("Shoot", 2, random);
    }

    void Shoot()
    {
        if (onRange)
        {
            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + new Vector3(0,1,0) + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);
            Destroy(bullet.gameObject, 2);
        }
    }

    void Update()
    {
        onRange = Vector3.Distance(transform.position, player.position) < range;

        if (onRange) transform.LookAt(player);
    }
}
