using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    public float cameraSmoothing = 1.0f;
    public float lookDown = 60.0f;
    public float lookUp = -60.0f;
    public Transform player;
    public bool canMove = true;
    private Quaternion camRotation;

    void Start()
    {
        if (canMove == true)
        {
            camRotation = transform.localRotation;
        }
    }

    void Update()
    {
        if (canMove == true)
        {
            camRotation.x += Input.GetAxis("Mouse Y") * cameraSmoothing * (-1);
            player.Rotate(Vector3.up * Input.GetAxis("Mouse X") * cameraSmoothing);
            camRotation.x = Mathf.Clamp(camRotation.x, lookUp, lookDown);
            transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
            
        }
    }
}
