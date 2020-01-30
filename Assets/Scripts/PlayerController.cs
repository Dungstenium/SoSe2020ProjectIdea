using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] float speed = 0.2f;
    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        moveDirection = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        InputManager();
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
        rigidBody.velocity = moveDirection.normalized * speed;
        //transform.SetPositionAndRotation(transform.position, new Quaternion(transform.rotation.x, Camera.main.transform.rotation.y, transform.rotation.z,transform.rotation.w));
        //transform.rotation = new Quaternion(transform.rotation.x, Camera.main.transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }
    void InputManager()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            MoveLeft();
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            MoveRight();
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            StopMovingSides();
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            MoveForward();
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            MoveBackward();
        }
        else if (Input.GetAxis("Vertical") == 0)
        {
            StopMovingForward();
        }
    }
    private void StopMovingForward()
    {
        moveDirection.z = Mathf.Lerp(moveDirection.z, 0.0f, 0.4f);
    }
    private void StopMovingSides()
    {
        moveDirection.x = Mathf.Lerp(moveDirection.x, 0.0f, 0.4f);
    }
    private void MoveForward()
    {
        moveDirection += transform.forward;
    }
    private void MoveBackward()
    {
        moveDirection += -transform.forward;
    }
    private void MoveRight()
    {
        moveDirection += transform.right;
    }
    private void MoveLeft()
    {
        moveDirection += -transform.right;
    }
}
