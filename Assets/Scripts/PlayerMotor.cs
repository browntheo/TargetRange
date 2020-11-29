using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camRotation = Vector3.zero;
    private Vector3 thrusterForce = Vector3.zero;
    private Rigidbody rb;

    [SerializeField]
    private Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }


    //updates each physics tick
    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }


    //perform movement based on velocity input
    private void PerformMovement()
    {
        if( velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
        if(thrusterForce != Vector3.zero)
        {
            rb.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

    //get a force vector for the thrusters
    public void ApplyThruster(Vector3 _thrusterForce)
    {
        thrusterForce = _thrusterForce;
    }


    //gets rotational vector
    internal void RotatePlayer(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //gets rotational vector for the camera
    internal void RotateCamera(Vector3 _camRotation)
    {
        camRotation = _camRotation;
    }

    //perform rotation
    private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            cam.transform.Rotate(-camRotation);
        }
    }

}

