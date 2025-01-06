using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] float movementSpeed;
    [SerializeField] float gravity;
    [SerializeField] float CameraSpeed;

    Vector2 Inputs;

    public CharacterController controller;

    [SerializeField] GameObject playerCamera;
    [SerializeField] GameObject playerHead;    
 
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();        
    }

    private void PlayerMovement()
    {
        float xValue = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float zValue = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        Inputs = new Vector2(xValue, zValue);

        Vector3 movement = new Vector3(xValue, gravity, zValue);
        movement = Quaternion.Euler(0, playerCamera.transform.eulerAngles.z, 0) * movement;
        controller.Move(movement * movementSpeed * Time.deltaTime);
    }
}
