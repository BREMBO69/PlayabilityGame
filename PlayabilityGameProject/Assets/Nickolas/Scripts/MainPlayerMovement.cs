using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject buttonAbility;
    private Rigidbody rb;

    public bool reversedControl = false;

    private bool isCollided;

    public bool IsCollided
    {
        get { return isCollided; }
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        buttonAbility.SetActive(false);
    }


    void Update()
    {
        if (reversedControl == false)
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");

            move.x = horizontal;
            move.z = vertical;

            GetComponent<Transform>().Translate(move * movementSpeed * Time.deltaTime);
        }

        else
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");

            move.z = horizontal;
            move.x = vertical;

            GetComponent<Transform>().Translate(move * movementSpeed * Time.deltaTime);
        }

        if (numberOfJumps > maxJumps - 1)
        {
            limitJumps = false;
        }

        if (limitJumps)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector3.up * jumpHeight;
                numberOfJumps += 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            maxJumps = 2.0f;
        }

        if (reversedControl== false && Input.GetKeyDown(KeyCode.R))
        {
            print("Control Reversed");
            reversedControl = true;
        }

        else if (reversedControl == true && Input.GetKeyDown(KeyCode.R))
        {
            print("Control Reversed Back");
            reversedControl = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        limitJumps = true;
        numberOfJumps = 0;

        if (other.gameObject.tag == "ResetAbility")
        {
            isCollided = true;
            buttonAbility.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
    void OnCollisionExit(Collision other)
    {

    }
    public void JumpVoid()
    {
        maxJumps = 1.0f;
        buttonAbility.SetActive(false);
    }
}

