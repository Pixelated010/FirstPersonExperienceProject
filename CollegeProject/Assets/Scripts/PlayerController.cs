using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float sprintSpeed;
    public float ogSpeed;
    public float crouchSpeedRemover;
    public float gravity;
    public float gravityLimit;
    public float jumpforce;
    public float camSpeed;  

    Vector2 inputs;

    Vector3 playerSize = new Vector3(1, 1, 1);
    Vector3 crouchingSize = new Vector3(1, 0.6f, 1);

    public CharacterController controller;

    public GameObject playerCam;
    public GameObject playerHead;

    bool crouchCheck = true;
    bool sprintCheck = true;

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
        crouching();
    }


    private void Movement()
    {
        //inputs is a vector2 which gets the horizontal and vertical inputs, which is then put in a vector3, which as inputs.x, for the horizontal axis, 
        //gravity, for the y axis and finally inputs.y for the final axis
        
        //idk what the last 2 bits of code does so i need to research thast before putting a comment here
        inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 movement = new Vector3(inputs.x, gravity, inputs.y);

        movement = Quaternion.Euler(0, playerCam.transform.eulerAngles.y, 0) * movement;
        controller.Move(movement * moveSpeed * Time.deltaTime);
    }

    private void Rotation()
    {
        playerHead.transform.rotation = Quaternion.Slerp(playerHead.transform.rotation, playerCam.transform.rotation, camSpeed * Time.deltaTime);
        // moves the player head with the playercam at the camera speed by using quaternion.slerp, which quaternion is used for rotation
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
        if(sprintCheck)
        {
        makePlayerSprint();
        }
    }

    private void crouching()
    {
        if(crouchCheck)
        {
            makePlayerCrouch();
        }
    }

    private void makePlayerSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            crouchCheck = false;
            moveSpeed *= sprintSpeed;//when the player presses the shift key the movement speed is times by the sprint speed
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            crouchCheck = true;
            moveSpeed = ogSpeed;//when the player lets go of the shift key, the movement is set back to 10
        }
    }

        private void makePlayerCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //the transform.local scale makes the player the size of a vector3 called crouchingsize, next transform.potition makes the position of the y decrease
            //which allows the player character to appear to move lower for the player, finally some movespeed is removed by the crouchspeedremover
            //which makes the player move slower
            sprintCheck = false;
            transform.localScale = crouchingSize;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
            moveSpeed -= crouchSpeedRemover;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            //when the player presses off the left control key the player's size the players size gets set to the player size, which is the original height of the character
            //then the player position is raised in order to not be in the ground when the player uncrouches, finally i set the movement speed back to the original speed 
            //it was set at
            sprintCheck = true;
            transform.localScale = playerSize;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
            moveSpeed = ogSpeed;
        }
    }
}
