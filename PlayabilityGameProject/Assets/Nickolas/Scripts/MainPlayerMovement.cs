using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{
    //WASD Movement
    private float vertical;
    private float horizontal;
    private Vector3 move;
    public float movementSpeed = 5.0f;
    //Jump
    public float jumpHeight = 7.0f;
    public float numberOfJumps = 0.0f;
    public float maxJumps = 1.0f;
    public bool limitJumps;
    private Rigidbody rb;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        move.x = horizontal;
        move.z = vertical;

        GetComponent<Transform>().Translate(move * movementSpeed * Time.deltaTime);

        if (numberOfJumps > maxJumps - 1)
        {
            limitJumps = false;
        }

        if (limitJumps)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = (Vector3.up * jumpHeight);
                numberOfJumps += 1;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        limitJumps = true;
        numberOfJumps = 0;
    }
    void OnCollisionExit(Collision other)
    {

    }
}

