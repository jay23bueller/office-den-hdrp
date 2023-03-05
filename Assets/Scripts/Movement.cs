using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private Transform _cameraTransform;

    [Header("Mouse Sensitivity")]
    [Range(5f, 200f)]
    [SerializeField]
    private float _mouseXSensitivity;
    [Range(5f, 200f)]
    [SerializeField]
    private float _mouseYSensitivity;

    [Header("Movement")]
    [Range(2f,25f)]
    [SerializeField]
    private float _speed;

    [Header("Rotation")]
    [Range(-90f, 0f)]
    [SerializeField]
    private float _minPitchAngle;
    [Range(0f, 90f)]
    [SerializeField]
    private float _maxPitchAngle;
    private float _currentPitch;
    private float _currentYaw;

    private void Awake()
    {
        Quaternion currentRotation = transform.rotation;

        _currentPitch = currentRotation.eulerAngles.x;
        _currentYaw = currentRotation.eulerAngles.y;
    }



    private void Update()
    {
        Vector3 directionInput = Vector3.zero;
        directionInput.x = Input.GetAxis("Horizontal");
        directionInput.z = Input.GetAxis("Vertical");

        directionInput = directionInput.normalized * Time.deltaTime * _speed;

        float worldUpInput = 0f;

        if (Input.GetKey(KeyCode.Q))
            worldUpInput = 1f;
        else if (Input.GetKey(KeyCode.E))
            worldUpInput = -1f;

        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        mouseInput.x *= _mouseXSensitivity;
        mouseInput.y *= -_mouseYSensitivity;

        mouseInput *= Time.deltaTime;

        _currentPitch = Mathf.Clamp(mouseInput.y + _currentPitch, _minPitchAngle, _maxPitchAngle);

        _currentYaw += mouseInput.x;

        transform.rotation = Quaternion.Euler(_currentPitch, _currentYaw, 0f);

        transform.Translate(directionInput, Space.Self);
        transform.Translate(worldUpInput * Vector3.up * _speed * Time.deltaTime, Space.World);




    }

    private void LateUpdate()
    {
        _cameraTransform.position = transform.position;
        _cameraTransform.rotation = transform.rotation;
    }
}
