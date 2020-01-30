using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CameraFollow : MonoBehaviour
{
    const string mouseXInputName = "Mouse X";
    const string mouseYInputName = "Mouse Y";
    [SerializeField] float mouseSensitivity;
    float xAxisClamp;
    Transform playerBodyTransform;
    void Awake()
    {
        LockCursorToScreenCenter();
        xAxisClamp = 0.0f;

        if (playerBodyTransform == null)
        {
            playerBodyTransform = GetComponentInParent<PlayerController>().transform;
        }
    }
    void Update()
    {
        CameraRotation();
    }
    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 80.0f)
        {
            xAxisClamp = 80.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValues(270.0f);
        }
        else if (xAxisClamp < -70.0f)
        {
            xAxisClamp = -70.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValues(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBodyTransform.Rotate(Vector3.up * mouseX);
    }
    void ClampXAxisRotationToValues(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
    void LockCursorToScreenCenter()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}