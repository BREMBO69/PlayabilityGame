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
    public float sprintStamina = 3.0f;
    //Jump
    public float jumpHeight = 3.0f;
    public float numberOfJumps = 0.0f;
    public float maxJumps = 1.0f;
    public bool limitJumps;
    public GameObject abilityMenu;
    private Rigidbody rb;

    //Ability Checkers
    [Header("Abilities")]
    public bool reversedControlAbility = false;
    public bool jumpHeightAbility = false;
    public bool doubleJumpAbility = false;
    public bool speedAbility = false;
    public bool sprintAbility = false;

    public GameObject ability1;
    public GameObject ability2;
    public GameObject ability3;
    public GameObject ability4;
    public GameObject ability5;

    [Header("Player Health")]
    public int playerHP = 100;
    public int timesDied = 0;
    public GameObject respawnPoint;

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
        if (Input.GetKeyDown("left shift") && sprintAbility == true && speedAbility == true && sprintStamina > 0)
        {
            movementSpeed = 15;
            sprintStamina = sprintStamina -= 1 * Time.deltaTime;
            if(sprintStamina <= 0)
            {
                sprintStamina += 1 * Time.deltaTime;
            }
        }

        if (Input.GetKeyDown("left shift") && sprintAbility == true && speedAbility == false)
        {
            movementSpeed = 10;
            sprintStamina = sprintStamina -= 1 * Time.deltaTime;
            if (sprintStamina <= 0)
            {
                sprintStamina += 1 * Time.deltaTime;
            }
        }

        if (Input.GetKeyUp("left shift") && sprintAbility == true && speedAbility == true)
        {
            movementSpeed = 10;
            sprintStamina = sprintStamina += 1 * Time.deltaTime;
            if (sprintStamina > 3.01f)
            {
                sprintStamina = 3;
            }
        }

        if (Input.GetKeyUp("left shift") && sprintAbility == true && speedAbility == false)
        {
            movementSpeed = 5;
            sprintStamina = sprintStamina += 1 * Time.deltaTime;
            if (sprintStamina > 3.01f)
            {
                sprintStamina = 3;
            }
        }

            if (reversedControlAbility == false)
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

        if (reversedControlAbility== false && Input.GetKeyDown(KeyCode.R))
        {
            print("Control Reversed");
            reversedControlAbility = true;
        }

        else if (reversedControlAbility == true && Input.GetKeyDown(KeyCode.R))
        {
            print("Control Reversed Back");
            reversedControlAbility = false;
        }

        if (playerHP <= 0)
        {
            playerHP = 100;
            transform.position = respawnPoint.transform.position;
            timesDied++;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        limitJumps = true;
        numberOfJumps = 0;

        if (other.gameObject.tag == "Bullet")
        {
            playerHP = playerHP - 5;
        }

        if (other.gameObject.tag == "AbilityBox" && timesDied == 0)
        {
            isCollided = true;
            abilityMenu.SetActive(true);
            ability1.SetActive(true);
            ability2.SetActive(true);
            ability3.SetActive(true);
            ability4.SetActive(false);
            ability5.SetActive(false);

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
        doubleJumpAbility = true;
        maxJumps = 2.0f;
        abilityMenu.SetActive(false);
    }

    public void SwitchControlsAbility()
    {
        if(reversedControlAbility == false)
        {
            reversedControlAbility = true;
            abilityMenu.SetActive(false);
        }

        else
        {
            reversedControlAbility = false;
            abilityMenu.SetActive(false);
        }
    }

    public void SpeedAbility()
    {
        speedAbility = true;
        movementSpeed = 10;
        abilityMenu.SetActive(false);
    }

    public void JumpHeight()
    {
        jumpHeightAbility = true;
        jumpHeight = 7.0f;
        abilityMenu.SetActive(false);
    }

    public void SprintAbility()
    {
        sprintAbility = true;
        abilityMenu.SetActive(false);
    }
}

