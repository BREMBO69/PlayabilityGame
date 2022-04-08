using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;

    public Animator gunAnim;
    public bool isShooting;
    
    public void Start() 
    {
        gunAnim = GetComponentInParent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Reload")) 
        {
            gunAnim.SetTrigger("ReloadTrigger");
        }
        
            if (Input.GetButtonDown("Fire1")) {
                gunAnim.SetTrigger("FireTrigger");
                GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
                ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, launchVelocity));
            }
        
        

        
    }
}
