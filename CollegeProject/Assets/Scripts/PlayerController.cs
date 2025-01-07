using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float sprint;
    public float gravity;
    public float gravityLimit;
    public float jumpforce;
    public float camSpeed;

    Vector2 inputs;

    public CharacterController controller;

    public GameObject playerCam;
    public GameObject playerHead;

    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;    
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
        jump();
        PlayerSprint();
    }


    private void Movement()
    {
        inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 movement = new Vector3(inputs.x, gravity, inputs.y);

        movement = Quaternion.Euler(0, playerCam.transform.eulerAngles.y, 0) * movement;
        controller.Move(movement * moveSpeed * Time.deltaTime);
    }

    private void Rotation()
    {
        playerHead.transform.rotation = Quaternion.Slerp(playerHead.transform.rotation, playerCam.transform.rotation, camSpeed * Time.deltaTime);
        // movs the player head with the playercam at the camera speed by using quaternion.slerp, which quaternion is used for rotation
    }

    private void jump()
    {
        if(gravity < gravityLimit)
        {
            gravity = gravityLimit;
        }
        else
        {
            gravity -= Time.deltaTime;
        }

        if(controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            gravity = Mathf.Sqrt(jumpforce);
        }
    }

    private void PlayerSprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= sprint;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 10;
        }
    }
}
