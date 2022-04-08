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
    public GameObject abilityMenu;
    private Rigidbody rb;

    //Ability Checkers
    public bool reversedControl = false;
    public bool abilityJump = false;

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
        abilityMenu.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown("left shift"))
        {
            movementSpeed = 10;
        }

        if (Input.GetKeyUp("left shift"))
        {
            movementSpeed = 5;
        }

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

        if (other.gameObject.tag == "AbilityBox")
        {
            isCollided = true;
            abilityMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        else if (other.gameObject.tag == "Bullet")
        {

        }
    }
    void OnCollisionExit(Collision other)
    {

    }
    
    //ABILITY VOIDS

    public void Jump2xAbility()
    {
        maxJumps = 2.0f;
        abilityJump = true;
        abilityMenu.SetActive(false);
    }

    public void SwitchControlsAbility()
    {
        if(reversedControl == false)
        {
            reversedControl = true;
            abilityMenu.SetActive(false);
        }

        else
        {
            reversedControl = false;
            abilityMenu.SetActive(false);
        }
    }

    public void SpeedAbility()
    {
        movementSpeed = 10;
        abilityMenu.SetActive(false);
    }
}

