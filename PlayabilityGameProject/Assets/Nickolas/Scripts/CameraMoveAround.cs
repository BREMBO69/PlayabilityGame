using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveAround : MonoBehaviour
{
    [Header("Sensivity & Smoothness")]
    public float _smoothTime = 0.2f;
    private Vector3 _smoothVelocity = Vector3.zero;
    public float _mouseSensitivity = 6.0f;

    private float _rotationY;
    private float _rotationX;
    private Vector3 _currentRotation;

    public Vector2 _rotationXMinMax = new Vector2(20, 80);

    void Start()
    {
        _rotationX = 80;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        _rotationY += mouseX;
        _rotationX -= mouseY;

        // Apply clamping for x rotation 
        _rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

        Vector3 nextRotation = new Vector3(_rotationX, _rotationY);

        // Apply damping between rotation changes
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = _currentRotation;

        // Substract forward vector of the GameObject to point its forward vector to the target
    }
}
